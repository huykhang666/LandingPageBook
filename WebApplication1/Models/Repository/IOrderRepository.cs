using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Repository
{
    public interface IOrderRepository : IRepository<OrderForm>
    {
        Task<IEnumerable<OrderForm>> GetOrdersWithDetailsAsync();
        Task<OrderForm?> GetOrderWithDetailsByIdAsync(int id);
    }
}
