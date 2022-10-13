
using FluentMigrator.Runner;
using MachDatum.Entitites;
using MachDatum.Repository;
using System.Reflection;

namespace MachDatum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string connectionString = "User Id=postgres;Password=MachDatum.1;Host=localhost;Database=machdatum";
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddFluentMigratorCore()
                .ConfigureRunner(c =>
                {
                    c.AddPostgres()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(Assembly.GetExecutingAssembly()).For.All();
                });

            builder.Services.AddScoped<UserRepository>();
            builder.Services.AddScoped<TeamsRepository>();

            var app = builder.Build();

            using IServiceScope scope = app.Services.CreateScope();
            IMigrationRunner migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
            migrator.MigrateUp();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Run();
        }
    }
}