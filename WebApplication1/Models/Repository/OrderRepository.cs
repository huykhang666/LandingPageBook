using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Repository
{
    public class OrderRepository : Repository<OrderForm>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<OrderForm>> GetOrdersWithDetailsAsync()
        {
            return await _dbSet
                .Include(o => o.Book)
                .Include(o => o.Status)
                .OrderByDescending(o => o.OrderTime)
                .ToListAsync();
        }

        public async Task<OrderForm?> GetOrderWithDetailsByIdAsync(int id)
        {
            return await _dbSet
                .Include(o => o.Book)
                .Include(o => o.Status)
                .FirstOrDefaultAsync(o => o.OrderFormId == id);
        }
    }
}
