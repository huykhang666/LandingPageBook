using WebApplication1.Models.DTOs;

namespace WebApplication1.Models.Service
{
    public interface IOrderService
    {
        Task<ApiResponse<OrderResponseDto>> CreateOrderAsync(CreateOrderDto dto);
        Task<ApiResponse<OrderResponseDto>> GetOrderByIdAsync(int id);
        Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetAllOrdersAsync();
        Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetUserOrdersAsync(string phone);
        Task<ApiResponse<bool>> UpdateOrderStatusAsync(int orderId, int statusId, decimal? newTotalPrice = null);

        // Đặc quyền Admin: Xem thống kê & Xem các thông báo đồng bộ
        Task<ApiResponse<DashboardStatisticDto>> GetDashboardStatisticsAsync();
        Task<ApiResponse<IEnumerable<AdminNotificationDto>>> GetAdminNotificationsAsync();
        Task<ApiResponse<bool>> MarkNotificationAsReadAsync(int notificationId);
    }
}
