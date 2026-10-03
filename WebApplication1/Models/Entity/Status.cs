namespace WebApplication1.Models.Entity
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
