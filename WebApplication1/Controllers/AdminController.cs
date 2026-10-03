using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")] 
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AdminController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// [ĐẶC QUYỀN ADMIN] Xem bảng điều khiển và số liệu thống kê (Doanh thu, số đơn, trạng thái)
        /// </summary>
        [HttpGet("dashboard")]
        public async Task<IActionResult> GetDashboardStatistics()
        {
            var result = await _orderService.GetDashboardStatisticsAsync();
            return Ok(result);
        }

        /// <summary>
        /// [ĐẶC QUYỀN ADMIN] Lấy danh sách các thông báo đơn hàng mới được đồng bộ từ Landing Page
        /// </summary>
        [HttpGet("notifications")]
        public async Task<IActionResult> GetNotifications()
        {
            var result = await _orderService.GetAdminNotificationsAsync();
            return Ok(result);
        }

        /// <summary>
        /// [ĐẶC QUYỀN ADMIN] Đánh dấu thông báo đã đọc
        /// </summary>
        [HttpPut("notifications/{id}/read")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            var result = await _orderService.MarkNotificationAsReadAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }
            return Ok(result);
        }
    }
}
