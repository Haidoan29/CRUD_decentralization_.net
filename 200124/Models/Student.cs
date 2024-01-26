using System.ComponentModel.DataAnnotations.Schema;

namespace _200124.Models
{
    public class Student :Base
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? StudentCode { get; set; }

        public int ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class? Classs { get; set; }
    }
}
