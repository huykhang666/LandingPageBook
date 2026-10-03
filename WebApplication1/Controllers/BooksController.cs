using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Service;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// [User & Khách] Lấy toàn bộ danh sách sách
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(ApiResponse<IEnumerable<BookDto>>.Ok(books));
        }

        /// <summary>
        /// [User & Khách] Lấy chi tiết sách theo Id
        /// </summary>
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound(ApiResponse<BookDto>.Fail("Không tìm thấy sách."));
            }
            return Ok(ApiResponse<BookDto>.Ok(book));
        }

        /// <summary>
        /// [User & Khách] Lấy sách nổi bật dành cho Landing Page
        /// </summary>
        [HttpGet("featured")]
        [AllowAnonymous]
        public async Task<IActionResult> GetFeatured()
        {
            var book = await _bookService.GetFeaturedBookAsync();
            if (book == null)
            {
                return NotFound(ApiResponse<BookDto>.Fail("Chưa có sách nổi bật nào."));
            }
            return Ok(ApiResponse<BookDto>.Ok(book));
        }

        /// <summary>
        /// [ĐẶC QUYỀN ADMIN] Thêm sách mới vào hệ thống
        /// </summary>
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(ApiResponse<BookDto>.Fail(errors));
            }

            var result = await _bookService.CreateBookAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Data?.BookId }, result);
        }

        /// <summary>
        /// [ĐẶC QUYỀN ADMIN] Cập nhật thông tin sách và thay đổi giá bán
        /// </summary>
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
                return BadRequest(ApiResponse<BookDto>.Fail(errors));
            }

            var result = await _bookService.UpdateBookAsync(id, dto);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

        /// <summary>
        /// [ĐẶC QUYỀN ADMIN] Xóa sách khỏi hệ thống
        /// </summary>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);
            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
