namespace WebApiService.Models.Entities
{
    public class Employees
    {
        public int empid { get; set; }
        public string lastname { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string titleofcourtesy { get; set; } = string.Empty;
        public DateTime birthdate { get; set; }
        public DateTime hiredate { get; set; }
        public string address { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string region { get; set; } = string.Empty;
        public string postalcode { get; set; } = string.Empty;
        public string country { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public int mgrid { get; set; }
    }
}
