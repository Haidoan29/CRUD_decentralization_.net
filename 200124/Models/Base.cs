namespace _200124.Models
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string? CreatedBy { get; set; } = "";
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; } = "";

        public bool? IsDeleted { get; set; } = null;
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
