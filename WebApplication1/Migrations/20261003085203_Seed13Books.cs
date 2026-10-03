using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Seed13Books : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookInfomations",
                columns: new[] { "BookId", "BookName", "Category", "DetailAuthor", "ImageUrl", "InformationAuthor", "Price", "Subtitle", "Title", "TitleReview" },
                values: new object[,]
                {
                    { 2, "Đắc Nhân Tâm (How to Win Friends)", "Kỹ năng sống", "Dale Carnegie - Chuyên gia phát triển nhân cách và nghệ thuật giao tiếp hàng đầu nước Mỹ.", "/images/dac-nhan-tam.png", "Nhà sáng lập Viện Đào tạo Dale Carnegie toàn cầu.", 86000m, "Cuốn sách hay nhất của mọi thời đại đưa bạn đến thành công và hạnh phúc đích thực.", "Nghệ Thuật Thu Phục Lòng Người & Đối Nhân Xử Thế", "Tác phẩm bán chạy nhất mọi thời đại với hơn 30 triệu bản in trên toàn cầu." },
                    { 3, "Nghĩ Giàu Và Làm Giàu (Think & Grow Rich)", "Kinh tế & Làm giàu", "Napoleon Hill - Cố vấn cho hai đời Tổng thống Hoa Kỳ Woodrow Wilson và Franklin D. Roosevelt.", "/images/nghi-giau-lam-giau.png", "Tác giả truyền cảm hứng thành công vĩ đại nhất thế kỷ 20.", 92000m, "Bản đồ tư duy tài chính được đúc kết từ 500 nhân vật giàu có và quyền lực nhất lịch sử.", "13 Nguyên Tắc Nghĩ Giàu Làm Giàu Bất Biến", "Cẩm nang làm giàu kinh điển làm thay đổi tư duy tài chính của hàng triệu triệu phú." },
                    { 4, "Quẳng Gánh Lo Đi & Vui Sống", "Tâm lý & Cuộc sống", "Dale Carnegie - Tác giả huyền thoại của phong trào phát triển bản thân.", "/images/quang-ganh-lo-di.png", "Bậc thầy về truyền cảm hứng và tâm lý học ứng dụng.", 84000m, "Sống trọn vẹn trong từng khoảnh khắc hiện tại và đánh thức nguồn năng lượng tích cực.", "Bí Quyết Làm Chủ Tâm Trí & Giải Tỏa Lo Âu", "Liều thuốc an thần tuyệt vời giúp bạn vượt qua áp lực, căng thẳng của cuộc sống hiện đại." },
                    { 5, "Ai Lấy Miếng Pho Mát Của Tôi?", "Kỹ năng sống", "Spencer Johnson, M.D. - Tiến sĩ y khoa, diễn giả và tác giả sách bán chạy số 1 New York Times.", "/images/ai-lay-mieng-pho-mat.png", "Chuyên gia hàng đầu về tâm lý học và quản trị hành vi con người.", 65000m, "Câu chuyện ngụ ngôn sâu sắc về sự thay đổi nơi công sở và cuộc sống.", "Nghệ Thuật Thích Nghi Với Mọi Biến Động Cuộc Đời", "Cuốn sách nhỏ làm bừng tỉnh tư duy đổi mới của các tập đoàn hàng đầu thế giới." },
                    { 6, "Ngày Xưa Có Một Con Bò...", "Phát triển bản thân", "Camilo Cruz, Ph.D - Tiến sĩ khoa học, tác giả nổi tiếng quốc tế về nghệ thuật tạo động lực.", "/images/ngay-xua-co-mot-con-bo.png", "Diễn giả truyền cảm hứng được săn đón tại hơn 30 quốc gia.", 75000m, "Bài học ngụ ngôn thức tỉnh bạn từ bỏ thói quen đổ lỗi và sự tầm thường.", "Phá Bỏ Mọi Lời Biện Hộ Để Bứt Phá Giới Hạn", "Cuốn sách dí dỏm nhưng sắc bén giúp bạn chặt đứt xiềng xích của sự lười biếng và trì hoãn." },
                    { 7, "Tư Duy Tích Cực Tạo Thành Công", "Phát triển bản thân", "Napoleon Hill & W. Clement Stone - Sự kết hợp của hai bậc thầy tư duy xuất sắc nhất thế giới.", "/images/tu-duy-tich-cuc.png", "Những nhà kiến tạo triết lý thành công hiện đại.", 89000m, "Chìa khóa vàng mở cánh cửa thành công và thịnh vượng bền vững.", "Sức Mạnh Của Thái Độ Sống Tích Cực (PMA)", "Khẳng định rằng bạn chính là người nắm quyền làm chủ hoàn toàn số phận của mình." },
                    { 8, "Chiếc Lexus Và Cây Ô Liu", "Kinh tế & Xã hội", "Thomas L. Friedman - Nhà báo giành 3 giải thưởng báo chí danh giá Pulitzer.", "/images/chiec-lexus-va-cay-o-liu.png", "Cây bút bình luận đối ngoại hàng đầu của báo The New York Times.", 115000m, "Sự giằng co giữa khát vọng hiện đại hóa công nghệ và gìn giữ bản sắc cội nguồn.", "Bức Tranh Toàn Cảnh Về Kỷ Nguyên Toàn Cầu Hóa", "Tác phẩm kinh điển về kinh tế thế giới được giảng dạy tại các trường đại học hàng đầu." },
                    { 9, "Chiến Thắng Con Quỷ Trong Bạn", "Tâm lý & Cuộc sống", "Napoleon Hill - Tác giả của cuốn sách huyền thoại Think and Grow Rich.", "/images/chien-thang-con-quy.png", "Cuốn sách từng bị cấm phát hành suốt hơn 70 năm vì tư tưởng quá đột phá.", 95000m, "Cuộc đối thoại kịch tính giữa tác giả và thực thể ma quỷ giam cầm tiềm năng con người.", "Bí Quyết Vượt Qua Nỗi Sợ Hãi Và Tự Do Đích Thực", "Cuốn sách giúp bạn nhận diện những cạm bẫy tâm lý và thức tỉnh sức mạnh vô biên." },
                    { 10, "Con Đường Phía Trước (The Road Ahead)", "Công nghệ thông tin", "Bill Gates - Tỷ phú sáng lập tập đoàn công nghệ Microsoft, nhà từ thiện vĩ đại.", "/images/con-duong-phia-truoc.png", "Một trong những bộ óc công nghệ có tầm ảnh hưởng lớn nhất lịch sử.", 110000m, "Dự báo chuẩn xác về kỷ nguyên số, trí tuệ nhân tạo và internet của nhà sáng lập Microsoft.", "Tầm Nhìn Công Nghệ Làm Thay Đổi Tương Lai Nhân Loại", "Góc nhìn tiên phong về cách mạng số và công nghệ định hình thế kỷ 21." },
                    { 11, "Dám Nghĩ Lớn (The Magic of Thinking Big)", "Phát triển bản thân", "David J. Schwartz, Ph.D - Giáo sư tại Đại học Georgia, chuyên gia huấn luyện lãnh đạo.", "/images/dam-nghi-lon.png", "Cố vấn phát triển tư duy cho hàng ngàn tập đoàn quốc tế.", 98000m, "Hãy nâng tầm ước mơ và mở rộng chân trời suy nghĩ để gặt hái thành công vượt trội.", "Phép Màu Của Tư Duy Đột Phá Không Giới Hạn", "Cuốn sách mở khóa năng lực tiềm ẩn, chứng minh tư duy quyết định tầm vóc cuộc đời." },
                    { 12, "Đánh Cắp Ý Tưởng (Steal These Ideas!)", "Kinh tế & Làm giàu", "Steve Cone - Chuyên gia marketing hàng đầu của các tập đoàn Citigroup, Fidelity.", "/images/danh-cap-y-tuong.png", "Chiến lược gia truyền thông và xây dựng thương hiệu lừng danh.", 88000m, "Kho tàng các ý tưởng kinh doanh và tiếp thị đắt giá áp dụng ngay trong thực tế.", "Bí Mật Marketing Và Sáng Tạo Làm Nên Thành Công", "Cẩm nang thực chiến dành cho mọi người làm kinh doanh và khởi nghiệp sáng tạo." },
                    { 13, "Dám Chấp Nhận", "Tâm lý & Cuộc sống", "Ernie Carwile - Cây bút truyền cảm hứng sâu sắc của tủ sách Hạt Giống Tâm Hồn.", "/images/dam-chap-nhan.png", "Nhà văn chữa lành tâm hồn với hàng triệu độc giả yêu mến.", 72000m, "Những câu chuyện dung dị nhưng thấm đẫm tình yêu thương và sự kiên cường.", "Nghị Lực Vượt Lên Nghịch Cảnh & Trưởng Thành", "Gieo vào lòng người đọc niềm tin son sắt vào cuộc sống và sức mạnh của lòng vị tha." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BookInfomations",
                keyColumn: "BookId",
                keyValue: 13);
        }
    }
}
