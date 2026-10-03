using WebApplication1.Models.Entity;

namespace WebApplication1.Models.Repository
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> GetByUsernameAsync(string username);
        Task<bool> IsUsernameTakenAsync(string username);
    }
}
