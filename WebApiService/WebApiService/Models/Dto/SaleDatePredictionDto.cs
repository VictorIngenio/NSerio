namespace WebApiService.Models.Dto
{
    public class SaleDatePredictionDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string LastOrderDate { get; set; } = string.Empty;
        public string NextPredictedOrder { get; set; } = string.Empty;
    }
}
