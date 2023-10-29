using DataEditTool.Commands;
using DataEditTool.Models;
using DataEditTool.ViewModels;
using Libs;
using Libs.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Windows;

namespace DataEditTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true);
            Configuration = builder.Build();

            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            var window = provider.GetRequiredService<MainWindow>();
            window.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder => {
                builder.AddConfiguration(Configuration.GetSection("Logging"));
                builder.AddLog4Net();
            });
            services.AddDbContext<AppDbContext>(option => {
                option.UseSqlServer(Configuration.GetConnectionString("ConnString"));
                option.EnableSensitiveDataLogging();
            });

            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(EditorViewModel));

            services.AddSingleton<ITodoList, TodoList>();
            services.AddSingleton<ITodoRepository, TodoRepository>();
            services.AddSingleton<IDelItemCmd, DelItemCmd>();
        }
    }
}
