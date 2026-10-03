using Microsoft.AspNetCore.SignalR;

namespace WebApplication1.Hubs
{
    public class NotificationHub : Hub
    {
        // Hub cho phép admin kết nối và nhận thông báo thời gian thực khi có đơn hàng mới
        public async Task JoinAdminGroup()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "AdminGroup");
        }

        public async Task LeaveAdminGroup()
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "AdminGroup");
        }
    }
}
