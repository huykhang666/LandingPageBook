using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entity
{
    public class AdminNotification
    {
        [Key]
        public int NotificationId { get; set; }
        public int OrderFormId { get; set; }
        public string Title { get; set; } = "Đơn hàng mới";
        public string Message { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual OrderForm? Order { get; set; }
    }
}
