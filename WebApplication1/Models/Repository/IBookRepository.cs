using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Repository
{
    public interface IBookRepository : IRepository<BookInfomation>
    {
        Task<BookInfomation?> GetFeaturedBookAsync();
    }
}
