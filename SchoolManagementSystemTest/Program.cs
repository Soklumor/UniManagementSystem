using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Windows.Forms;
using SchoolManagementSystemTest.Forms;
using SchoolManagementSystemTest.Services;
using SchoolManagementSystemTest.Data;

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
            services.AddSingleton<LoginForm>();
            services.AddSingleton<UserService>(); 
            services.AddDbContext<AppDbContext>();
        }
    }
}
