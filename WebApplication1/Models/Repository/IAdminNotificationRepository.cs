using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Repository
{
    public interface IAdminNotificationRepository : IRepository<AdminNotification>
    {
        Task<IEnumerable<AdminNotification>> GetRecentNotificationsAsync(int take = 20);
        Task<bool> MarkAsReadAsync(int notificationId);
        Task<int> GetUnreadCountAsync();
    }
}
