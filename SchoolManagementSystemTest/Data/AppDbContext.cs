using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystemTest.Models;

namespace SchoolManagementSystemTest.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=TOLASEYHA\SQLEXPRESS;Database=sms;Trusted_Connection=True;TrustServerCertificate=True");

        }

    }
}
