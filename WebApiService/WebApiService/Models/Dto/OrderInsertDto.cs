namespace WebApiService.Models.Dto
{
    public class OrderInsertDto
    {
        public int custid { get; set; }
        public int empid { get; set; }
        public string orderdate { get; set; } = string.Empty;
        public string requireddate { get; set; } = string.Empty;
        public string? shippeddate { get; set; }
        public int shipperid { get; set; }
        public decimal freight { get; set; }
        public string shipname { get; set; } = string.Empty;
        public string shipaddress { get; set; } = string.Empty;
        public string shipcity { get; set; } = string.Empty;
        public string shipcountry { get; set; } = string.Empty;
        public int productid { get; set; }
        public decimal unitprice { get; set; }
        public int qty { get; set; }
        public decimal discount { get; set; }
    }
}
