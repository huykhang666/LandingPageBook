using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookToNhaGiaKim : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "BookName", "Category", "DetailAuthor", "ImageUrl", "InformationAuthor", "Price", "Subtitle", "Title", "TitleReview" },
                values: new object[] { "Nhà Giả Kim (The Alchemist)", "Văn học kinh điển", "Paulo Coelho - Nhà văn huyền thoại người Brazil, Sứ giả hòa bình của Liên Hợp Quốc.", "/images/nha-gia-kim.png", "Tác giả có sách được dịch ra nhiều thứ tiếng nhất lịch sử (Kỷ lục Guinness thế giới).", 79000m, "Khi bạn thực sự khao khát một điều gì, toàn thể vũ trụ sẽ hợp lực giúp bạn đạt được điều đó.", "Hành Trình Đi Tìm Vận Mệnh & Giấc Mơ", "Kiệt tác văn học kinh điển toàn cầu đã lay động hơn 150 triệu độc giả trên 170 quốc gia." });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 1,
                columns: new[] { "BookName", "Category", "DetailAuthor", "ImageUrl", "InformationAuthor", "Price", "Subtitle", "Title", "TitleReview" },
                values: new object[] { "Lập Trình C# Toàn Tập", "Công nghệ thông tin", "Tác giả có hơn 10 năm kinh nghiệm phát triển phần mềm doanh nghiệp.", "/images/book-csharp.jpg", "Chuyên gia Microsoft MVP", 189000m, "Từ cơ bản đến chuyên sâu", "Kỹ Năng Lập Trình Hiện Đại Với C# và .NET", "Cuốn sách gối đầu giường dành cho mọi lập trình viên .NET." });
        }
    }
}
