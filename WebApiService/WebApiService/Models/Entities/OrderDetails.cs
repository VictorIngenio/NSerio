namespace WebApiService.Models.Entities
{
    public class OrderDetails
    {
        public int orderid { get; set; }
        public int productid { get; set; }
        public int unitprice { get; set; }
        public int qty { get; set; }
        public int discount { get; set; }
    }
}
