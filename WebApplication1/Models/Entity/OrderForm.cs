namespace WebApplication1.Models.Entity
{
    public class OrderForm
    {
        public int OrderFormId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime OrderTime { get; set; } = DateTime.UtcNow;

        // Foreign keys
        public int BookId { get; set; }
        public virtual BookInfomation? Book { get; set; }

        public int StatusId { get; set; }
        public virtual Status? Status { get; set; }
    }
}
