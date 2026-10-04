using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                });

            migrationBuilder.CreateTable(
                name: "BookInfomations",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookName = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Subtitle = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    DetailAuthor = table.Column<string>(type: "text", nullable: true),
                    InformationAuthor = table.Column<string>(type: "text", nullable: true),
                    TitleReview = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInfomations", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StatusName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "OrderForms",
                columns: table => new
                {
                    OrderFormId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    OrderTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    StatusId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderForms", x => x.OrderFormId);
                    table.ForeignKey(
                        name: "FK_OrderForms_BookInfomations_BookId",
                        column: x => x.BookId,
                        principalTable: "BookInfomations",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderForms_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookInfomations",
                columns: new[] { "BookId", "BookName", "Category", "DetailAuthor", "ImageUrl", "InformationAuthor", "Price", "Subtitle", "Title", "TitleReview" },
                values: new object[] { 1, "Lập Trình C# Toàn Tập", "Công nghệ thông tin", "Tác giả có hơn 10 năm kinh nghiệm phát triển phần mềm doanh nghiệp.", "/images/book-csharp.jpg", "Chuyên gia Microsoft MVP", 189000m, "Từ cơ bản đến chuyên sâu", "Kỹ Năng Lập Trình Hiện Đại Với C# và .NET", "Cuốn sách gối đầu giường dành cho mọi lập trình viên .NET." });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Description", "StatusName" },
                values: new object[,]
                {
                    { 1, "Đơn hàng mới tạo", "Chờ xác nhận" },
                    { 2, "Đơn hàng đang trên đường giao", "Đang giao" },
                    { 3, "Đã giao thành công", "Hoàn thành" },
                    { 4, "Đơn hàng đã bị hủy", "Đã hủy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderForms_BookId",
                table: "OrderForms",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderForms_StatusId",
                table: "OrderForms",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "OrderForms");

            migrationBuilder.DropTable(
                name: "BookInfomations");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
