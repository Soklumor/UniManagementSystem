using SchoolManagementSystemTest.Models;
using System.Linq;

namespace SchoolManagementSystemTest.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context) => _context = context;

        public User Authenticate(string username, string password)
        {
            Console.WriteLine($"Login attempt: username='{username}', password='{password}'");

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            var user = _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            Console.WriteLine(user != null ? "✅ User found" : "❌ User not found");

            return user;
        }
    }
}

