namespace WebApiService.Models.Entities
{
    public class Orders
    {
        public int orderid { get; set; }
        public int? custid { get; set; }
        public int empid { get; set; }
        public DateTime orderdate { get; set; }
        public DateTime requireddate { get; set; }
        public DateTime? shippeddate { get; set; }
        public int shipperid { get; set; }
        public decimal freight { get; set; }
        public string shipname { get; set; } = string.Empty;
        public string shipaddress { get; set; } = string.Empty;
        public string shipcity { get; set; } = string.Empty;
        public string? shipregion { get; set; } = string.Empty;
        public string? shippostalcode { get; set; } = string.Empty;
        public string shipcountry { get; set; } = string.Empty;
    }
}
