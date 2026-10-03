using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(MapToDto);
        }

        public async Task<BookDto?> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book != null ? MapToDto(book) : null;
        }

        public async Task<BookDto?> GetFeaturedBookAsync()
        {
            var book = await _bookRepository.GetFeaturedBookAsync();
            return book != null ? MapToDto(book) : null;
        }

        // Quyền Admin: Thêm sách mới
        public async Task<ApiResponse<BookDto>> CreateBookAsync(CreateBookDto dto)
        {
            var book = new BookInfomation
            {
                BookName = dto.BookName.Trim(),
                Category = dto.Category,
                Title = dto.Title,
                Subtitle = dto.Subtitle,
                Price = dto.Price,
                ImageUrl = dto.ImageUrl ?? "/images/nha-gia-kim.png",
                DetailAuthor = dto.DetailAuthor,
                InformationAuthor = dto.InformationAuthor,
                TitleReview = dto.TitleReview
            };

            await _bookRepository.AddAsync(book);
            await _bookRepository.SaveAsync();

            return ApiResponse<BookDto>.Ok(MapToDto(book), "Thêm sách mới thành công!");
        }

        // Quyền Admin: Sửa thông tin & cập nhật giá sách
        public async Task<ApiResponse<BookDto>> UpdateBookAsync(int id, UpdateBookDto dto)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return ApiResponse<BookDto>.Fail("Không tìm thấy sách cần cập nhật.");
            }

            book.BookName = dto.BookName.Trim();
            book.Category = dto.Category;
            book.Title = dto.Title;
            book.Subtitle = dto.Subtitle;
            book.Price = dto.Price; // Cập nhật giá
            if (!string.IsNullOrEmpty(dto.ImageUrl)) book.ImageUrl = dto.ImageUrl;
            book.DetailAuthor = dto.DetailAuthor;
            book.InformationAuthor = dto.InformationAuthor;
            book.TitleReview = dto.TitleReview;

            _bookRepository.Update(book);
            await _bookRepository.SaveAsync();

            return ApiResponse<BookDto>.Ok(MapToDto(book), "Cập nhật thông tin và giá sách thành công!");
        }

        // Quyền Admin: Xóa sách
        public async Task<ApiResponse<bool>> DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null)
            {
                return ApiResponse<bool>.Fail("Không tìm thấy sách cần xóa.");
            }

            _bookRepository.Delete(book);
            await _bookRepository.SaveAsync();

            return ApiResponse<bool>.Ok(true, "Xóa sách thành công!");
        }

        private static BookDto MapToDto(BookInfomation b) => new BookDto
        {
            BookId = b.BookId,
            BookName = b.BookName,
            Category = b.Category,
            Title = b.Title,
            Subtitle = b.Subtitle,
            Price = b.Price,
            ImageUrl = b.ImageUrl,
            DetailAuthor = b.DetailAuthor,
            InformationAuthor = b.InformationAuthor,
            TitleReview = b.TitleReview
        };
    }
}
