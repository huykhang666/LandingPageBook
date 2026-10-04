namespace WebApplication1.Models.DTOs
{
    public class OrderResponseDto
    {
        public int OrderFormId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime OrderTime { get; set; }

        public int BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}
