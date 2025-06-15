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

            while (true)
            {
                var loginForm = serviceProvider.GetRequiredService<LoginForm>();
                var loginResult = loginForm.ShowDialog();

                if (loginResult == DialogResult.OK)
                {
                    var mainForm = serviceProvider.GetRequiredService<FormResult>();
                    Application.Run(mainForm);  // Blocks until mainForm is closed (e.g., by Logout)
                }
                else
                {
                    break;  // Exit app
                }
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<LoginForm>();      // Use Transient for fresh login form each time
            services.AddTransient<FormResult>();     // Main form (can use Singleton if you want to persist state)
            services.AddSingleton<UserService>();
            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(HandleConnection.ConnectionString));
        }
    }
}

