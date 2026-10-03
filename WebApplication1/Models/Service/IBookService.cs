using WebApplication1.Models.DTOs;

namespace WebApplication1.Models.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetAllBooksAsync();
        Task<BookDto?> GetBookByIdAsync(int id);
        Task<BookDto?> GetFeaturedBookAsync();

        // Quyền Admin: Thêm, sửa, đổi giá, xóa sách
        Task<ApiResponse<BookDto>> CreateBookAsync(CreateBookDto dto);
        Task<ApiResponse<BookDto>> UpdateBookAsync(int id, UpdateBookDto dto);
        Task<ApiResponse<bool>> DeleteBookAsync(int id);
    }
}
