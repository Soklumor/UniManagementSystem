using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagementSystemTest.Models
{
    public class ExamResult
    {
        [Key]
        public int ExamID { get; set; }

        [ForeignKey("Student")]
        [MaxLength(14)]
        public string StudentID { get; set; }
        public virtual Student Student { get; set; }

        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }

        [ForeignKey("Department")]
        public int? DepartmentID { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("Class")]
        public int? ClassID { get; set; }
        public virtual Class Class { get; set; }

        public DateTime ExamDate { get; set; }

        [Range(0, 100)]
        public decimal Score { get; set; }

        [MaxLength(2)]
        public string Grade { get; set; }

        [MaxLength(20)]
        public string Remark { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
