using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Repository
{
    public class BookRepository : Repository<BookInfomation>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<BookInfomation?> GetFeaturedBookAsync()
        {
            return await _dbSet.FirstOrDefaultAsync();
        }
    }
}
