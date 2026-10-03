using Microsoft.AspNetCore.SignalR;
using WebApplication1.Hubs;
using WebApplication1.Models.DTOs;
using WebApplication1.Models.Entity;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IRepository<Status> _statusRepository;
        private readonly IAdminNotificationRepository _notificationRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public OrderService(
            IOrderRepository orderRepository,
            IBookRepository bookRepository,
            IRepository<Status> statusRepository,
            IAdminNotificationRepository notificationRepository,
            IAccountRepository accountRepository,
            IHubContext<NotificationHub> hubContext)
        {
            _orderRepository = orderRepository;
            _bookRepository = bookRepository;
            _statusRepository = statusRepository;
            _notificationRepository = notificationRepository;
            _accountRepository = accountRepository;
            _hubContext = hubContext;
        }

        public async Task<ApiResponse<OrderResponseDto>> CreateOrderAsync(CreateOrderDto dto)
        {
            // 1. Kiểm tra sách có tồn tại không
            var book = await _bookRepository.GetByIdAsync(dto.BookId);
            if (book == null)
            {
                return ApiResponse<OrderResponseDto>.Fail("Sách được chọn không tồn tại trên hệ thống.");
            }

            // 2. Khởi tạo đơn hàng mới với trạng thái mặc định (1: Chờ xác nhận)
            var order = new OrderForm
            {
                CustomerName = dto.CustomerName.Trim(),
                Phone = dto.Phone.Trim(),
                Address = dto.Address.Trim(),
                Quantity = dto.Quantity,
                PaymentMethod = dto.PaymentMethod,
                BookId = dto.BookId,
                StatusId = 1, // Mặc định: Chờ xác nhận
                OrderTime = DateTime.UtcNow
            };

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveAsync();

            var totalPrice = book.Price * order.Quantity;

            // 3. Tự động lưu thông báo cho Admin vào Database
            var notification = new AdminNotification
            {
                OrderFormId = order.OrderFormId,
                Title = "Đơn hàng mới từ Landing Page",
                Message = $"Khách hàng {order.CustomerName} vừa đặt mua {order.Quantity} cuốn '{book.BookName}'.",
                CustomerName = order.CustomerName,
                Phone = order.Phone,
                Address = order.Address,
                PaymentMethod = order.PaymentMethod,
                TotalPrice = totalPrice,
                IsRead = false,
                CreatedAt = DateTime.UtcNow
            };

            await _notificationRepository.AddAsync(notification);
            await _notificationRepository.SaveAsync();

            // 4. BẮN ASYNC REAL-TIME SIGNALR TỚI TÀI KHOẢN ADMIN
            var notificationDto = new AdminNotificationDto
            {
                NotificationId = notification.NotificationId,
                OrderFormId = order.OrderFormId,
                Title = notification.Title,
                Message = notification.Message,
                CustomerName = notification.CustomerName,
                Phone = notification.Phone,
                Address = notification.Address,
                PaymentMethod = notification.PaymentMethod,
                TotalPrice = notification.TotalPrice,
                IsRead = false,
                CreatedAt = notification.CreatedAt
            };

            try
            {
                // Bắn thông báo thời gian thực tới tất cả client admin đang kết nối
                await _hubContext.Clients.All.SendAsync("ReceiveNewOrderNotification", notificationDto);
            }
            catch (Exception ex)
            {
                // Ghi nhận lỗi nhưng không để ảnh hưởng tiến trình tạo đơn
                Console.WriteLine($"[SignalR Notification Error]: {ex.Message}");
            }

            // 5. Trả về thông tin đơn hàng vừa tạo cho người dùng
            var response = new OrderResponseDto
            {
                OrderFormId = order.OrderFormId,
                CustomerName = order.CustomerName,
                Phone = order.Phone,
                Address = order.Address,
                Quantity = order.Quantity,
                PaymentMethod = order.PaymentMethod,
                OrderTime = order.OrderTime,
                BookId = book.BookId,
                BookName = book.BookName,
                UnitPrice = book.Price,
                StatusId = 1,
                StatusName = "Chờ xác nhận"
            };

            return ApiResponse<OrderResponseDto>.Ok(response, "Đặt hàng thành công!");
        }

        public async Task<ApiResponse<OrderResponseDto>> GetOrderByIdAsync(int id)
        {
            var order = await _orderRepository.GetOrderWithDetailsByIdAsync(id);
            if (order == null)
            {
                return ApiResponse<OrderResponseDto>.Fail("Không tìm thấy đơn hàng.");
            }

            var response = new OrderResponseDto
            {
                OrderFormId = order.OrderFormId,
                CustomerName = order.CustomerName,
                Phone = order.Phone,
                Address = order.Address,
                Quantity = order.Quantity,
                PaymentMethod = order.PaymentMethod,
                OrderTime = order.OrderTime,
                BookId = order.BookId,
                BookName = order.Book?.BookName ?? string.Empty,
                UnitPrice = order.Book?.Price ?? 0,
                StatusId = order.StatusId,
                StatusName = order.Status?.StatusName ?? string.Empty
            };

            return ApiResponse<OrderResponseDto>.Ok(response);
        }

        public async Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetAllOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersWithDetailsAsync();

            var response = orders.Select(order => new OrderResponseDto
            {
                OrderFormId = order.OrderFormId,
                CustomerName = order.CustomerName,
                Phone = order.Phone,
                Address = order.Address,
                Quantity = order.Quantity,
                PaymentMethod = order.PaymentMethod,
                OrderTime = order.OrderTime,
                BookId = order.BookId,
                BookName = order.Book?.BookName ?? string.Empty,
                UnitPrice = order.Book?.Price ?? 0,
                StatusId = order.StatusId,
                StatusName = order.Status?.StatusName ?? string.Empty
            });

            return ApiResponse<IEnumerable<OrderResponseDto>>.Ok(response);
        }

        public async Task<ApiResponse<IEnumerable<OrderResponseDto>>> GetUserOrdersAsync(string phone)
        {
            var allOrders = await _orderRepository.GetOrdersWithDetailsAsync();
            var userOrders = allOrders
                .Where(o => o.Phone.Trim() == phone.Trim())
                .Select(order => new OrderResponseDto
                {
                    OrderFormId = order.OrderFormId,
                    CustomerName = order.CustomerName,
                    Phone = order.Phone,
                    Address = order.Address,
                    Quantity = order.Quantity,
                    PaymentMethod = order.PaymentMethod,
                    OrderTime = order.OrderTime,
                    BookId = order.BookId,
                    BookName = order.Book?.BookName ?? string.Empty,
                    UnitPrice = order.Book?.Price ?? 0,
                    StatusId = order.StatusId,
                    StatusName = order.Status?.StatusName ?? string.Empty
                });

            return ApiResponse<IEnumerable<OrderResponseDto>>.Ok(userOrders);
        }

        public async Task<ApiResponse<bool>> UpdateOrderStatusAsync(int orderId, int statusId)
        {
            var order = await _orderRepository.GetByIdAsync(orderId);
            if (order == null)
            {
                return ApiResponse<bool>.Fail("Không tìm thấy đơn hàng cần cập nhật.");
            }

            var status = await _statusRepository.GetByIdAsync(statusId);
            if (status == null)
            {
                return ApiResponse<bool>.Fail("Trạng thái không hợp lệ.");
            }

            order.StatusId = statusId;
            _orderRepository.Update(order);
            await _orderRepository.SaveAsync();

            try
            {
                // BẮN SIGNALR ASYNC THÔNG BÁO CHO USER KHI ADMIN DUYỆT / CẬP NHẬT ĐƠN HÀNG
                var updateNotice = new
                {
                    orderFormId = order.OrderFormId,
                    statusId = status.StatusId,
                    statusName = status.StatusName,
                    customerName = order.CustomerName,
                    phone = order.Phone,
                    message = $"Đơn hàng #{order.OrderFormId} của bạn đã được cập nhật sang trạng thái: '{status.StatusName}'."
                };
                await _hubContext.Clients.All.SendAsync("ReceiveOrderStatusUpdated", updateNotice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SignalR Status Update Error]: {ex.Message}");
            }

            return ApiResponse<bool>.Ok(true, "Cập nhật trạng thái đơn hàng thành công.");
        }

        // ĐẶC QUYỀN ADMIN: Xem thống kê tổng quan
        public async Task<ApiResponse<DashboardStatisticDto>> GetDashboardStatisticsAsync()
        {
            var allOrders = await _orderRepository.GetOrdersWithDetailsAsync();
            var allBooks = await _bookRepository.GetAllAsync();
            var allAccounts = await _accountRepository.GetAllAsync();

            var orderList = allOrders.ToList();
            var today = DateTime.UtcNow.Date;

            // Doanh thu từ các đơn hoàn thành (StatusId == 3)
            var totalRevenue = orderList
                .Where(o => o.StatusId == 3)
                .Sum(o => (o.Book?.Price ?? 0) * o.Quantity);

            // Doanh thu trong ngày hôm nay (từ các đơn hoàn thành hôm nay, hoặc đơn đặt hôm nay)
            var todayRevenue = orderList
                .Where(o => o.OrderTime.Date == today && o.StatusId != 4)
                .Sum(o => (o.Book?.Price ?? 0) * o.Quantity);

            var todayOrders = orderList.Count(o => o.OrderTime.Date == today);

            var stats = new DashboardStatisticDto
            {
                TotalRevenue = totalRevenue,
                TodayRevenue = todayRevenue,
                TotalOrders = orderList.Count,
                TodayOrders = todayOrders,
                PendingOrders = orderList.Count(o => o.StatusId == 1),
                CompletedOrders = orderList.Count(o => o.StatusId == 3),
                TotalBooks = allBooks.Count(),
                TotalAccounts = allAccounts.Count()
            };

            return ApiResponse<DashboardStatisticDto>.Ok(stats);
        }

        // ĐẶC QUYỀN ADMIN: Lấy danh sách thông báo đơn hàng
        public async Task<ApiResponse<IEnumerable<AdminNotificationDto>>> GetAdminNotificationsAsync()
        {
            var notifications = await _notificationRepository.GetRecentNotificationsAsync(50);
            var dtos = notifications.Select(n => new AdminNotificationDto
            {
                NotificationId = n.NotificationId,
                OrderFormId = n.OrderFormId,
                Title = n.Title,
                Message = n.Message,
                CustomerName = n.CustomerName,
                Phone = n.Phone,
                Address = n.Address,
                PaymentMethod = n.PaymentMethod,
                TotalPrice = n.TotalPrice,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt
            });

            return ApiResponse<IEnumerable<AdminNotificationDto>>.Ok(dtos);
        }

        public async Task<ApiResponse<bool>> MarkNotificationAsReadAsync(int notificationId)
        {
            var success = await _notificationRepository.MarkAsReadAsync(notificationId);
            return success
                ? ApiResponse<bool>.Ok(true, "Đã đánh dấu thông báo đã đọc.")
                : ApiResponse<bool>.Fail("Không tìm thấy thông báo.");
        }
    }
}
