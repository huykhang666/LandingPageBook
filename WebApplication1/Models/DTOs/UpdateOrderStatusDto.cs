using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models.DTOs
{
    public class UpdateOrderStatusDto
    {
        [Required(ErrorMessage = "Vui lòng chọn trạng thái mới")]
        public int StatusId { get; set; }
    }
}
