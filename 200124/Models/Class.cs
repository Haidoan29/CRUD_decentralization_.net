namespace _200124.Models
{
    public class Class :Base
    {
        public string? ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Student>? Students { get; set; }
    }
}
