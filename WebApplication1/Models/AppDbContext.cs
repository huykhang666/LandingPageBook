using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Entity;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<BookInfomation> BookInfomations { get; set; }
        public DbSet<OrderForm> OrderForms { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<AdminNotification> AdminNotifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed tài khoản Admin và User mặc định
            modelBuilder.Entity<Account>().HasData(
                new Account
                {
                    AccountId = 1,
                    Username = "admin",
                    Password = "admin123",
                    FullName = "Quản Trị Viên Hệ Thống",
                    Role = "Admin"
                },
                new Account
                {
                    AccountId = 2,
                    Username = "khachhang",
                    Password = "123456",
                    FullName = "Nguyễn Văn Khách",
                    Role = "User"
                }
            );

            // Seed dữ liệu mặc định cho trạng thái đơn hàng
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = 1, StatusName = "Chờ xác nhận", Description = "Đơn hàng mới tạo" },
                new Status { StatusId = 2, StatusName = "Đang giao", Description = "Đơn hàng đang trên đường giao" },
                new Status { StatusId = 3, StatusName = "Hoàn thành", Description = "Đã giao thành công" },
                new Status { StatusId = 4, StatusName = "Đã hủy", Description = "Đơn hàng đã bị hủy" }
            );

            // Seed 13 cuốn sách kinh điển cho cửa hàng và Landing Page
            modelBuilder.Entity<BookInfomation>().HasData(
                new BookInfomation
                {
                    BookId = 1,
                    BookName = "Nhà Giả Kim (The Alchemist)",
                    Title = "Hành Trình Đi Tìm Vận Mệnh & Giấc Mơ",
                    Subtitle = "Khi bạn thực sự khao khát một điều gì, toàn thể vũ trụ sẽ hợp lực giúp bạn đạt được điều đó.",
                    Category = "Văn học kinh điển",
                    Price = 79000,
                    ImageUrl = "/images/nha-gia-kim.png",
                    DetailAuthor = "Paulo Coelho - Nhà văn huyền thoại người Brazil, Sứ giả hòa bình của Liên Hợp Quốc.",
                    InformationAuthor = "Tác giả có sách được dịch ra nhiều thứ tiếng nhất lịch sử (Kỷ lục Guinness thế giới).",
                    TitleReview = "Kiệt tác văn học kinh điển toàn cầu đã lay động hơn 150 triệu độc giả trên 170 quốc gia."
                },
                new BookInfomation
                {
                    BookId = 2,
                    BookName = "Đắc Nhân Tâm (How to Win Friends)",
                    Title = "Nghệ Thuật Thu Phục Lòng Người & Đối Nhân Xử Thế",
                    Subtitle = "Cuốn sách hay nhất của mọi thời đại đưa bạn đến thành công và hạnh phúc đích thực.",
                    Category = "Kỹ năng sống",
                    Price = 86000,
                    ImageUrl = "/images/dac-nhan-tam.png",
                    DetailAuthor = "Dale Carnegie - Chuyên gia phát triển nhân cách và nghệ thuật giao tiếp hàng đầu nước Mỹ.",
                    InformationAuthor = "Nhà sáng lập Viện Đào tạo Dale Carnegie toàn cầu.",
                    TitleReview = "Tác phẩm bán chạy nhất mọi thời đại với hơn 30 triệu bản in trên toàn cầu."
                },
                new BookInfomation
                {
                    BookId = 3,
                    BookName = "Nghĩ Giàu Và Làm Giàu (Think & Grow Rich)",
                    Title = "13 Nguyên Tắc Nghĩ Giàu Làm Giàu Bất Biến",
                    Subtitle = "Bản đồ tư duy tài chính được đúc kết từ 500 nhân vật giàu có và quyền lực nhất lịch sử.",
                    Category = "Kinh tế & Làm giàu",
                    Price = 92000,
                    ImageUrl = "/images/nghi-giau-lam-giau.png",
                    DetailAuthor = "Napoleon Hill - Cố vấn cho hai đời Tổng thống Hoa Kỳ Woodrow Wilson và Franklin D. Roosevelt.",
                    InformationAuthor = "Tác giả truyền cảm hứng thành công vĩ đại nhất thế kỷ 20.",
                    TitleReview = "Cẩm nang làm giàu kinh điển làm thay đổi tư duy tài chính của hàng triệu triệu phú."
                },
                new BookInfomation
                {
                    BookId = 4,
                    BookName = "Quẳng Gánh Lo Đi & Vui Sống",
                    Title = "Bí Quyết Làm Chủ Tâm Trí & Giải Tỏa Lo Âu",
                    Subtitle = "Sống trọn vẹn trong từng khoảnh khắc hiện tại và đánh thức nguồn năng lượng tích cực.",
                    Category = "Tâm lý & Cuộc sống",
                    Price = 84000,
                    ImageUrl = "/images/quang-ganh-lo-di.png",
                    DetailAuthor = "Dale Carnegie - Tác giả huyền thoại của phong trào phát triển bản thân.",
                    InformationAuthor = "Bậc thầy về truyền cảm hứng và tâm lý học ứng dụng.",
                    TitleReview = "Liều thuốc an thần tuyệt vời giúp bạn vượt qua áp lực, căng thẳng của cuộc sống hiện đại."
                },
                new BookInfomation
                {
                    BookId = 5,
                    BookName = "Ai Lấy Miếng Pho Mát Của Tôi?",
                    Title = "Nghệ Thuật Thích Nghi Với Mọi Biến Động Cuộc Đời",
                    Subtitle = "Câu chuyện ngụ ngôn sâu sắc về sự thay đổi nơi công sở và cuộc sống.",
                    Category = "Kỹ năng sống",
                    Price = 65000,
                    ImageUrl = "/images/ai-lay-mieng-pho-mat.png",
                    DetailAuthor = "Spencer Johnson, M.D. - Tiến sĩ y khoa, diễn giả và tác giả sách bán chạy số 1 New York Times.",
                    InformationAuthor = "Chuyên gia hàng đầu về tâm lý học và quản trị hành vi con người.",
                    TitleReview = "Cuốn sách nhỏ làm bừng tỉnh tư duy đổi mới của các tập đoàn hàng đầu thế giới."
                },
                new BookInfomation
                {
                    BookId = 6,
                    BookName = "Ngày Xưa Có Một Con Bò...",
                    Title = "Phá Bỏ Mọi Lời Biện Hộ Để Bứt Phá Giới Hạn",
                    Subtitle = "Bài học ngụ ngôn thức tỉnh bạn từ bỏ thói quen đổ lỗi và sự tầm thường.",
                    Category = "Phát triển bản thân",
                    Price = 75000,
                    ImageUrl = "/images/ngay-xua-co-mot-con-bo.png",
                    DetailAuthor = "Camilo Cruz, Ph.D - Tiến sĩ khoa học, tác giả nổi tiếng quốc tế về nghệ thuật tạo động lực.",
                    InformationAuthor = "Diễn giả truyền cảm hứng được săn đón tại hơn 30 quốc gia.",
                    TitleReview = "Cuốn sách dí dỏm nhưng sắc bén giúp bạn chặt đứt xiềng xích của sự lười biếng và trì hoãn."
                },
                new BookInfomation
                {
                    BookId = 7,
                    BookName = "Tư Duy Tích Cực Tạo Thành Công",
                    Title = "Sức Mạnh Của Thái Độ Sống Tích Cực (PMA)",
                    Subtitle = "Chìa khóa vàng mở cánh cửa thành công và thịnh vượng bền vững.",
                    Category = "Phát triển bản thân",
                    Price = 89000,
                    ImageUrl = "/images/tu-duy-tich-cuc.png",
                    DetailAuthor = "Napoleon Hill & W. Clement Stone - Sự kết hợp của hai bậc thầy tư duy xuất sắc nhất thế giới.",
                    InformationAuthor = "Những nhà kiến tạo triết lý thành công hiện đại.",
                    TitleReview = "Khẳng định rằng bạn chính là người nắm quyền làm chủ hoàn toàn số phận của mình."
                },
                new BookInfomation
                {
                    BookId = 8,
                    BookName = "Chiếc Lexus Và Cây Ô Liu",
                    Title = "Bức Tranh Toàn Cảnh Về Kỷ Nguyên Toàn Cầu Hóa",
                    Subtitle = "Sự giằng co giữa khát vọng hiện đại hóa công nghệ và gìn giữ bản sắc cội nguồn.",
                    Category = "Kinh tế & Xã hội",
                    Price = 115000,
                    ImageUrl = "/images/chiec-lexus-va-cay-o-liu.png",
                    DetailAuthor = "Thomas L. Friedman - Nhà báo giành 3 giải thưởng báo chí danh giá Pulitzer.",
                    InformationAuthor = "Cây bút bình luận đối ngoại hàng đầu của báo The New York Times.",
                    TitleReview = "Tác phẩm kinh điển về kinh tế thế giới được giảng dạy tại các trường đại học hàng đầu."
                },
                new BookInfomation
                {
                    BookId = 9,
                    BookName = "Chiến Thắng Con Quỷ Trong Bạn",
                    Title = "Bí Quyết Vượt Qua Nỗi Sợ Hãi Và Tự Do Đích Thực",
                    Subtitle = "Cuộc đối thoại kịch tính giữa tác giả và thực thể ma quỷ giam cầm tiềm năng con người.",
                    Category = "Tâm lý & Cuộc sống",
                    Price = 95000,
                    ImageUrl = "/images/chien-thang-con-quy.png",
                    DetailAuthor = "Napoleon Hill - Tác giả của cuốn sách huyền thoại Think and Grow Rich.",
                    InformationAuthor = "Cuốn sách từng bị cấm phát hành suốt hơn 70 năm vì tư tưởng quá đột phá.",
                    TitleReview = "Cuốn sách giúp bạn nhận diện những cạm bẫy tâm lý và thức tỉnh sức mạnh vô biên."
                },
                new BookInfomation
                {
                    BookId = 10,
                    BookName = "Con Đường Phía Trước (The Road Ahead)",
                    Title = "Tầm Nhìn Công Nghệ Làm Thay Đổi Tương Lai Nhân Loại",
                    Subtitle = "Dự báo chuẩn xác về kỷ nguyên số, trí tuệ nhân tạo và internet của nhà sáng lập Microsoft.",
                    Category = "Công nghệ thông tin",
                    Price = 110000,
                    ImageUrl = "/images/con-duong-phia-truoc.png",
                    DetailAuthor = "Bill Gates - Tỷ phú sáng lập tập đoàn công nghệ Microsoft, nhà từ thiện vĩ đại.",
                    InformationAuthor = "Một trong những bộ óc công nghệ có tầm ảnh hưởng lớn nhất lịch sử.",
                    TitleReview = "Góc nhìn tiên phong về cách mạng số và công nghệ định hình thế kỷ 21."
                },
                new BookInfomation
                {
                    BookId = 11,
                    BookName = "Dám Nghĩ Lớn (The Magic of Thinking Big)",
                    Title = "Phép Màu Của Tư Duy Đột Phá Không Giới Hạn",
                    Subtitle = "Hãy nâng tầm ước mơ và mở rộng chân trời suy nghĩ để gặt hái thành công vượt trội.",
                    Category = "Phát triển bản thân",
                    Price = 98000,
                    ImageUrl = "/images/dam-nghi-lon.png",
                    DetailAuthor = "David J. Schwartz, Ph.D - Giáo sư tại Đại học Georgia, chuyên gia huấn luyện lãnh đạo.",
                    InformationAuthor = "Cố vấn phát triển tư duy cho hàng ngàn tập đoàn quốc tế.",
                    TitleReview = "Cuốn sách mở khóa năng lực tiềm ẩn, chứng minh tư duy quyết định tầm vóc cuộc đời."
                },
                new BookInfomation
                {
                    BookId = 12,
                    BookName = "Đánh Cắp Ý Tưởng (Steal These Ideas!)",
                    Title = "Bí Mật Marketing Và Sáng Tạo Làm Nên Thành Công",
                    Subtitle = "Kho tàng các ý tưởng kinh doanh và tiếp thị đắt giá áp dụng ngay trong thực tế.",
                    Category = "Kinh tế & Làm giàu",
                    Price = 88000,
                    ImageUrl = "/images/danh-cap-y-tuong.png",
                    DetailAuthor = "Steve Cone - Chuyên gia marketing hàng đầu của các tập đoàn Citigroup, Fidelity.",
                    InformationAuthor = "Chiến lược gia truyền thông và xây dựng thương hiệu lừng danh.",
                    TitleReview = "Cẩm nang thực chiến dành cho mọi người làm kinh doanh và khởi nghiệp sáng tạo."
                },
                new BookInfomation
                {
                    BookId = 13,
                    BookName = "Dám Chấp Nhận",
                    Title = "Nghị Lực Vượt Lên Nghịch Cảnh & Trưởng Thành",
                    Subtitle = "Những câu chuyện dung dị nhưng thấm đẫm tình yêu thương và sự kiên cường.",
                    Category = "Tâm lý & Cuộc sống",
                    Price = 72000,
                    ImageUrl = "/images/dam-chap-nhan.png",
                    DetailAuthor = "Ernie Carwile - Cây bút truyền cảm hứng sâu sắc của tủ sách Hạt Giống Tâm Hồn.",
                    InformationAuthor = "Nhà văn chữa lành tâm hồn với hàng triệu độc giả yêu mến.",
                    TitleReview = "Gieo vào lòng người đọc niềm tin son sắt vào cuộc sống và sức mạnh của lòng vị tha."
                }
            );
        }
    }
}

