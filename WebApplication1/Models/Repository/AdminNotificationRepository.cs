using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Repository
{
    public class AdminNotificationRepository : Repository<AdminNotification>, IAdminNotificationRepository
    {
        public AdminNotificationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AdminNotification>> GetRecentNotificationsAsync(int take = 20)
        {
            return await _dbSet
                .OrderByDescending(n => n.CreatedAt)
                .Take(take)
                .ToListAsync();
        }

        public async Task<bool> MarkAsReadAsync(int notificationId)
        {
            var notif = await _dbSet.FindAsync(notificationId);
            if (notif == null) return false;

            notif.IsRead = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetUnreadCountAsync()
        {
            return await _dbSet.CountAsync(n => !n.IsRead);
        }
    }
}
