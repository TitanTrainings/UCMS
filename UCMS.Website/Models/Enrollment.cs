using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCMS.Website.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [Required]
        public string Progress { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime LastDate { get; set; }
        public bool Status { get; set; } = true;
    }
}
