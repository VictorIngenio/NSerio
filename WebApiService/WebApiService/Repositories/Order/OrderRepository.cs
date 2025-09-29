using Microsoft.Data.SqlClient;
using WebApiService.Models.Context;
using WebApiService.Models.Dto;
using WebApiService.Models.Entities;
using WebApiService.Repositories.Customer;

namespace WebApiService.Repositories.Order
{
    public class OrderRepository(StoreContext context, IConfiguration configuration,
                                 ICustomerRepository customerRepository) : IOrderRepository
    {
        private readonly StoreContext _context = context;
        private readonly IConfiguration _configuration = configuration;
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public IEnumerable<OrdersDto> GetOrders(int custid)
        {
            try
            {
                List<OrdersDto> lista = [];

                lista = (from resp in _context.Orders where resp.custid == custid
                         select new OrdersDto
                         {
                             Orderid = resp.orderid,
                             Requireddate = resp.requireddate,
                             Shippeddate = resp.shippeddate,
                             Shipname = resp.shipname,
                             Shipaddress = resp.shipaddress,
                             Shipcity = resp.shipcity,
                         }).ToList();
                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetOrders: {mensaje}", e.Message);
                return [];
            }
        }

        public IEnumerable<SaleDatePredictionDto> GetSaleDatePredictions()
        {
            try
            {
                List<Orders> orders = [];
                List<SaleDatePredictionDto> result = [];
                SaleDatePredictionDto registro = new();
                DateTime fi, ff;
                TimeSpan dif;
                int suma = 0;

                IEnumerable<Customers> listcust = _customerRepository.GetCustomers();

                foreach (var item in listcust)
                {
                    orders = _context.Orders.Where(x => x.custid == item.custid)
                        .OrderByDescending(p => p.orderdate).ToList();

                    if (orders.Count > 0)
                    {
                        for (int i = 0; i < orders.Count; i++)
                        {
                            if (i != orders.Count - 1)
                            {
                                fi = orders[i].orderdate;
                                ff = orders[i + 1].orderdate;

                                dif = fi - ff;

                                suma = suma + dif.Days;
                            }
                        }

                        registro.CustomerId = item.custid;
                        registro.CustomerName = item.companyname;
                        registro.LastOrderDate = orders[0].orderdate.ToString();
                        registro.NextPredictedOrder = orders[0].orderdate.AddDays(suma / orders.Count).ToString();

                        result.Add(registro);
                    }

                    suma = 0;
                    orders = [];
                    registro = new();
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetSaleDatePredictions: {mensaje}", e.Message);
                return [];
            }
        }

        public IEnumerable<SaleDatePredictionDto> GetSaleDatePredictions(string custName)
        {
            try
            {
                List<Orders> orders = [];
                List<SaleDatePredictionDto> result = [];
                SaleDatePredictionDto registro = new();
                DateTime fi, ff;
                TimeSpan dif;
                int suma = 0;

                List<Customers> listcust = _customerRepository.GetCustomer(custName).ToList();

                if (listcust.Count > 0)
                {
                    foreach (var item in listcust)
                    {
                        orders = _context.Orders.Where(x => x.custid == item.custid)
                            .OrderByDescending(p => p.orderdate).ToList();

                        if (orders.Count > 0)
                        {
                            for (int i = 0; i < orders.Count; i++)
                            {
                                if (i != orders.Count - 1)
                                {
                                    fi = orders[i].orderdate;
                                    ff = orders[i + 1].orderdate;

                                    dif = fi - ff;

                                    suma = suma + dif.Days;
                                }
                            }

                            registro.CustomerId = item.custid;
                            registro.CustomerName = item.companyname;
                            registro.LastOrderDate = orders[0].orderdate.ToString();
                            registro.NextPredictedOrder = orders[0].orderdate.AddDays(suma / orders.Count).ToString();

                            result.Add(registro);
                        }

                        suma = 0;
                        orders = [];
                        registro = new();
                    }
                }

                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetSaleDatePredictionsByCustName: {mensaje}", e.Message);
                return [];
            }
        }

        public void InsertOrder(OrderInsertDto order)
        {
            try
            {
                string? cadena = _configuration.GetConnectionString("StoreConexion");

                using SqlConnection con = new(cadena);
                using SqlCommand cmd = new("InsertNewOrder", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@Custid", order.custid));
                cmd.Parameters.Add(new SqlParameter("@Empid", order.empid));
                cmd.Parameters.Add(new SqlParameter("@Shipperid", order.shipperid));
                cmd.Parameters.Add(new SqlParameter("@Shipname", order.shipname));
                cmd.Parameters.Add(new SqlParameter("@Shipaddress", order.shipaddress));
                cmd.Parameters.Add(new SqlParameter("@Shipcity", order.shipcity));
                cmd.Parameters.Add(new SqlParameter("@Orderdate", order.orderdate));
                cmd.Parameters.Add(new SqlParameter("@Requireddate", order.requireddate));
                cmd.Parameters.Add(new SqlParameter("@Shippeddate", order.shippeddate));
                cmd.Parameters.Add(new SqlParameter("@Freight", order.freight));
                cmd.Parameters.Add(new SqlParameter("@Shipcountry", order.shipcountry));
                cmd.Parameters.Add(new SqlParameter("@Productid", order.productid));
                cmd.Parameters.Add(new SqlParameter("@Unitprice", order.unitprice));
                cmd.Parameters.Add(new SqlParameter("@Qty", order.qty));
                cmd.Parameters.Add(new SqlParameter("@Discount", order.discount));

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("InsertOrder: {mensaje}", e.Message);
            }
        }
    }
}
