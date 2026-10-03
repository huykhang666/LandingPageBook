namespace WebApplication1.Models.DTOs
{
    public class DashboardStatisticDto
    {
        public decimal TotalRevenue { get; set; }           // Tổng doanh thu từ các đơn thành công
        public decimal TodayRevenue { get; set; }           // Doanh thu trong ngày hôm nay
        public int TotalOrders { get; set; }               // Tổng số đơn hàng đã đặt
        public int TodayOrders { get; set; }               // Số đơn hàng đặt trong ngày hôm nay
        public int PendingOrders { get; set; }             // Đơn hàng đang chờ xác nhận
        public int CompletedOrders { get; set; }           // Đơn hàng đã giao thành công
        public int TotalBooks { get; set; }                // Tổng số đầu sách hiện có
        public int TotalAccounts { get; set; }             // Tổng số tài khoản khách hàng
    }

    public class AdminNotificationDto
    {
        public int NotificationId { get; set; }
        public int OrderFormId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal TotalPrice { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
