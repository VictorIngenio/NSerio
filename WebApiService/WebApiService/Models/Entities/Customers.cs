namespace WebApiService.Models.Entities
{
    public class Customers
    {
        public int custid { get; set; }
        public string companyname { get; set; } = string.Empty;
        public string contactname { get; set; } = string.Empty;
        public string contacttitle { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string? region { get; set; } = string.Empty;
        public string? postalcode { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public string? fax { get; set; } = string.Empty;
    }
}
