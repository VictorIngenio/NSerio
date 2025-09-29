namespace WebApiService.Models.Dto
{
    public class OrdersDto
    {
        public int Orderid { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public string Shipname { get; set; } = string.Empty;
        public string Shipaddress { get; set; } = string.Empty;
        public string Shipcity { get; set; } = string.Empty;
    }
}
