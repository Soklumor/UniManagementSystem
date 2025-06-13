using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemTest.Models;

public class AppDbContext : DbContext
{
    // Add this constructor to accept options (required for DI)
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<ExamResult> ExamResults { get; set; }
    public DbSet<ExamResultsPivot> ExamResultsPivots { get; set; }

    // Remove OnConfiguring method if you configure via DI
    // Or keep if you want fallback configuration outside DI

    // You can keep OnModelCreating as is
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExamResultsPivot>()
            .HasNoKey()
            .ToView("vw_ExamResultsPivot");

        modelBuilder.Entity<ExamResultsPivot>()
            .ToFunction("fn_ExamResultsPivotFiltered");
    }
}
