
using Kallipr.Application.Devices;
using Kallipr.Application.TelemetryEvents;
using Kallipr.Application.Tenants;
using Kallipr.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Kallipr.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add CORS policy that allows everything
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy
                        .AllowAnyOrigin()   // Allow all origins
                        .AllowAnyHeader()   // Allow all headers
                        .AllowAnyMethod();  // Allow all HTTP methods
                });
            });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IDeviceService, DeviceService>();
            builder.Services.AddScoped<ITelemetryEventService, TelemetryEventService>();
            builder.Services.AddScoped<ICustomerIdProvider, CustomerIdProvider>();

            builder.Services.AddDbContext<KalliprDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Ensure the database is created and seed initial data. NOT for production use - in a real application, you would typically use EF Core Migrations and a more robust seeding strategy.
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<KalliprDbContext>();
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }

            app.UseCors();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<CustomerIdHeaderMiddleware>();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
