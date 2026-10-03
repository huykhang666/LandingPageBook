using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class CreateBookDto
    {
        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string BookName { get; set; } = string.Empty;

        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }

        [Range(0, 100000000, ErrorMessage = "Giá sách phải lớn hơn hoặc bằng 0")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
        public string? DetailAuthor { get; set; }
        public string? InformationAuthor { get; set; }
        public string? TitleReview { get; set; }
    }

    public class UpdateBookDto
    {
        [Required(ErrorMessage = "Tên sách không được để trống")]
        public string BookName { get; set; } = string.Empty;

        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }

        [Range(0, 100000000, ErrorMessage = "Giá sách phải lớn hơn hoặc bằng 0")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
        public string? DetailAuthor { get; set; }
        public string? InformationAuthor { get; set; }
        public string? TitleReview { get; set; }
    }
}
