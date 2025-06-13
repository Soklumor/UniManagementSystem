using System;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystemTest.Models
{
    [Keyless]
    public class ExamResultsPivot
    {
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string DepartmentName { get; set; }
        public int ClassID { get; set; }
        public int DepartmentID { get; set; }
        public decimal? DataAnalysist { get; set; }
        public decimal? Database { get; set; }
        public decimal? CSharp { get; set; }
        public decimal? Network { get; set; }
        public decimal? WebApp { get; set; }
        public decimal TotalScore { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
