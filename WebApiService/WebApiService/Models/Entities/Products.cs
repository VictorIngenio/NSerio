namespace WebApiService.Models.Entities
{
    public class Products
    {
        public int productid { get; set; }
        public string productname { get; set; } = string.Empty;
        public int supplierid { get; set; }
        public int categoryid { get; set; }
        public int unitprice { get; set; }
        public bool discontinued { get; set; }
    }
}
