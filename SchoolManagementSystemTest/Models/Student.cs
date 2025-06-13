using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystemTest.Models
{
    public class Student
    {
        [Key, MaxLength(14)]
        public string StudentID { get; set; }

        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("Male|Female")]
        public string Gender { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(50)]
        public string Email { get; set; } = "Unknown";

        [Required, MaxLength(20)]
        public string Phone { get; set; }

        [Required, MaxLength(20)]
        public string ParentPhone { get; set; }

        [Required, MaxLength(100)]
        public string BirthAddress { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(50)]
        public string MajorName { get; set; } = "Student";

        [Required, MaxLength(15)]
        public string EnterYear { get; set; }

        [Required, MaxLength(10)]
        public string Status { get; set; } = "Active";

        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
