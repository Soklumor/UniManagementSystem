using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using SchoolManagementSystemTest.Forms;
using SchoolManagementSystemTest.Services;

namespace SchoolManagementSystemTest
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            using var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            try
            {
                Application.Run(serviceProvider.GetRequiredService<LoginForm>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Register your forms and services here
            services.AddSingleton<LoginForm>();
            services.AddSingleton<FormResult>();  // Your exam/result form
            services.AddSingleton<UserService>();

            // Configure your DbContext with the connection string
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(@"Server=DESKTOP-IBQJ98S\SQLEXPRESS;Database=StudentManagement;Trusted_Connection=True;TrustServerCertificate=True"));
        }
    }
}
