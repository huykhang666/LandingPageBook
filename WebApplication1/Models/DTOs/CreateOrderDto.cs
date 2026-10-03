using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class CreateOrderDto
    {
        [Required(ErrorMessage = "Vui lòng chọn sách")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [StringLength(100, ErrorMessage = "Tên không được quá 100 ký tự")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ nhận hàng")]
        public string Address { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Số lượng phải từ 1 đến 100")]
        public int Quantity { get; set; } = 1;

        public string PaymentMethod { get; set; } = "COD"; 
    }
}
