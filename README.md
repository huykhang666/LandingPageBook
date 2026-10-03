# 📚 Huy Khang Book Shop - E-Commerce & Landing Page System

> Dự án đồ án / bài tập ứng dụng thương mại điện tử bán sách chọn lọc và phát triển bản thân, kết hợp Landing Page chi tiết và bảng điều khiển Quản trị viên (Admin Portal) thời gian thực.

---

## 🚀 Công Nghệ Sử Dụng

### 1. Backend (C# & ASP.NET Core)
* **Framework:** ASP.NET Core (.NET 10.0)
* **Database & ORM:** PostgreSQL kết hợp Entity Framework Core (Code First & DbContext)
* **Authentication:** JWT (JSON Web Token) phân quyền Admin và User
* **Realtime Communication:** SignalR Hub (đồng bộ thông báo đặt hàng và duyệt đơn 2 chiều tức thì)
* **Containerization:** Docker multi-stage build

### 2. Frontend
* **UI/UX Design:** Tailwind CSS & Responsive Mobile First
* **Icon System:** FontAwesome 6 Pro
* **Architecture:** Single Page Application (SPA) tích hợp sẵn trong `wwwroot`

### 3. CI/CD & Cloud Deployment
* **CI/CD Pipeline:** GitHub Actions (`.github/workflows/ci-cd.yml`) tự động kiểm tra biên dịch, build test và kích hoạt deploy
* **Database Cloud:** Supabase (PostgreSQL Cloud)
* **Hosting:** Render / Railway / Vercel

---

## 🌟 Các Tính Năng Nổi Bật

### 👤 Dành Cho Khách Hàng (User)
1. **Cửa Hàng Sách (Catalog):**
   * Tìm kiếm theo tên sách, tác giả, thể loại.
   * Lọc sách theo khoảng giá và danh mục.
   * Hiển thị đánh giá sao đa dạng (4.5 - 5.0 ⭐).
2. **Landing Page Chi Tiết:**
   * Bấm vào bất kỳ cuốn sách nào để xem toàn bộ Landing Page phân tích bài học cốt lõi, trích dẫn truyền cảm hứng, đánh giá của chuyên gia và ưu đãi độc quyền.
3. **Giỏ Hàng & Mua Hàng:**
   * Thêm/bớt số lượng, giỏ hàng popup trượt mượt mà.
   * Bắt buộc đăng nhập trước khi tiến hành đặt hàng (popup nhắc nhở thân thiện, không dùng alert mặc định).
4. **Theo Dõi Đơn Hàng:**
   * Xem lịch sử các đơn hàng cá nhân trong menu hồ sơ.
   * Nhận thông báo thời gian thực ngay khi Admin cập nhật trạng thái đơn sang *"Đang giao hàng"* hoặc *"Hoàn thành"*.

### 🛡️ Dành Cho Quản Trị Viên (Admin)
1. **Bảng Thống Kê & Doanh Thu (Dashboard):**
   * Số liệu thực tế lấy từ Database: Doanh thu trong ngày, doanh thu tháng, tổng đơn đã hoàn thành, đơn cần duyệt.
2. **Quản Lý & Duyệt Đơn Hàng Chi Tiết:**
   * Xem đầy đủ: Họ tên khách, SĐT, địa chỉ giao hàng, sách chọn mua, số lượng, tổng tiền và hình thức thanh toán.
   * Thao tác duyệt trạng thái đơn: *Chờ xác nhận ➔ Duyệt & Đang giao hàng ➔ Hoàn thành / Hủy đơn*.
3. **Thông Báo Đơn Hàng Thời Gian Thực (SignalR):**
   * Ngay khi khách đặt sách ở bất kỳ đâu, máy chủ tự động đẩy thông báo tức thì lên chuông thông báo và dải banner của Admin mà không cần tải lại trang.
4. **Quản Trị Kho Sách:**
   * Thêm sách mới, điều chỉnh giá bán khuyến mãi trực tiếp trên bảng.
   * Xóa sách với Popup Modal xác nhận an toàn.

---

## 🛠️ Hướng Dẫn Chạy Dự Án Local

### 1. Yêu cầu môi trường
* .NET SDK 10.x trở lên
* PostgreSQL (Local hoặc Cloud Supabase)
* Visual Studio 2022 / 2025 hoặc VS Code

### 2. Cấu hình Chuỗi Kết Nối
Mở file `WebApplication1/appsettings.json` và cập nhật thông tin PostgreSQL của bạn:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=BookLandingDb;Username=postgres;Password=YOUR_PASSWORD"
  }
}
```

### 3. Chạy Lệnh Khởi Động
```bash
# Di chuyển vào thư mục dự án
cd WebApplication1

# Cập nhật Database (nếu dùng EF Core Migration)
dotnet ef database update

# Khởi chạy dự án
dotnet run --launch-profile https
```
Truy cập trình duyệt tại: **https://localhost:7230**

### 4. Tài Khoản Mặc Định
* **Admin:** Username: `admin` | Password: `admin123`
* **User:** Có thể đăng ký tài khoản mới trực tiếp trên giao diện web.

---

## 🚀 Hướng Dẫn CI/CD & Deploy

Dự án đã tích hợp sẵn GitHub Actions tại `.github/workflows/ci-cd.yml`:
1. Mỗi khi bạn `git push` lên branch `main` hoặc `master`, GitHub Actions sẽ tự động kiểm tra code và chạy thử bản build Docker.
2. Để kết nối tự động deploy lên **Render.com**:
   * Vào **Render** ➔ Tạo **Web Service** chọn repo này ➔ Lấy **Deploy Hook URL**.
   * Vào **GitHub** ➔ **Settings** ➔ **Secrets and variables** ➔ **Actions** ➔ Thêm Secret: `RENDER_DEPLOY_HOOK_URL`.
   * Mỗi commit mới sẽ tự động kích hoạt deploy lên website thật!

---
*Dự án được xây dựng và hoàn thiện bởi Nguyễn Huy Khang.*
