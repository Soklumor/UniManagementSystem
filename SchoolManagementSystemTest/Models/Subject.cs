using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystemTest.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }

        [ForeignKey("Department")]
        public int DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("Class")]
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }

        [Required, MaxLength(30)]
        public string SubjectName { get; set; }

        public virtual ICollection<ExamResult> ExamResults { get; set; }
    }
}
