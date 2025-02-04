using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UCMS.Website.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(25)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Course detail is required.")]
        [MaxLength(100)]
        public string Detail { get; set; } = string.Empty;
        [ForeignKey("Faculty")]
        public int FacultyId { get; set; }
        public Faculty? Faculty { get; set; }
        public int Duration { get; set; }
        public bool Status { get; set; } = true;

        //Navigation Properties
        
        public List<Enrollment> Enrollments { get; set; }
    }
}
