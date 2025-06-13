using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystemTest.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required, MaxLength(50)]
        public string DepartmentName { get; set; }

        [Required, MaxLength(50)]
        public string Location { get; set; }

        [Column(TypeName = "money")]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Required, MaxLength(10)]
        public string Status { get; set; } = "Active";

        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
