using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.Entity
{
    public class BookInfomation
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; } = string.Empty;
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Subtitle { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? DetailAuthor { get; set; }
        public string? InformationAuthor { get; set; }
        public string? TitleReview { get; set; }
    }
}
