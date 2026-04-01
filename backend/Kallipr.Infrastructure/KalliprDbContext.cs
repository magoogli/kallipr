using Kallipr.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kallipr.Infrastructure
{
    public class KalliprDbContext : DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<TelemetryEvent> TelemetryEvents { get; set; }
        public DbSet<Customer> Customers { get; set; }

        private readonly ICustomerIdProvider _customerIdProvider;
        public KalliprDbContext(DbContextOptions<KalliprDbContext> options, ICustomerIdProvider customerIdProvider) : base(options)
        {
            _customerIdProvider = customerIdProvider;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KalliprDbContext).Assembly);

            modelBuilder.Entity<Device>()
                .HasQueryFilter(_ => _.CustomerId == _customerIdProvider.CustomerId);

            modelBuilder.Entity<TelemetryEvent>()
                .HasQueryFilter(_ => _.CustomerId == _customerIdProvider.CustomerId);
        }


        static void SeedData(DbContext context)
        {
            var customer1 = context.Set<Customer>().FirstOrDefault(_ => _.Id == "acme-123");
            if (customer1 == null)
            {
                context.Set<Customer>().Add(new Customer("acme-123", "Acme Corporation"));
                
                context.Set<Device>().AddRange(
                     new Device("acme-123", "dev-001", "Boiler #3", "Plant A"),
                     new Device("acme-123", "dev-002", "Chiller #1", "Plant A")
                );
                
                context.Set<TelemetryEvent>().AddRange(
                    new TelemetryEvent("acme-123", "dev-001", "evt-a1", DateTime.Parse("2025-05-04T12:34:56Z"), "temperature", 21.5, "C"),
                    new TelemetryEvent("acme-123", "dev-001", "evt-a2", DateTime.Parse("2025-05-04T12:35:30Z"), "temperature", 22.0, "C"),
                    new TelemetryEvent("acme-123", "dev-001", "evt-a0", DateTime.Parse("2025-05-04T12:30:00Z"), "temperature", 21.0, "C"),
                    new TelemetryEvent("acme-123", "dev-002", "evt-b1", DateTime.Parse("2025-05-04T12:40:00Z"), "temperature", 6.8, "C"),
                    //new TelemetryEvent("acme-123", "dev-001", "evt-a2", DateTime.Parse("2025-05-04T12:35:30Z"), "temperature", 22.0, "C"), // Duplicate resend,
                    //new TelemetryEvent("acme-123", "dev-001", "evt-a0", DateTime.Parse("2025-05-04T12:30:00Z"), "temperature", 21.0, "C"), // Out-of-order arrival,
                    new TelemetryEvent("acme-123", "dev-001", "evt-a3", DateTime.Parse("2025-05-04T12:36:00Z"), "temperature", 22.5, "C"), // New event after duplicates,
                    new TelemetryEvent("acme-123", "dev-001", "evt-a4", DateTime.Parse("2025-05-04T12:37:00Z"), "temperature", 22.8, "C"), // Another new event,
                    new TelemetryEvent("acme-123", "dev-001", "evt-a5", DateTime.Parse("2025-05-04T12:38:00Z"), "temperature", 23.0, "C"), // Yet another new event,
                    new TelemetryEvent("acme-123", "dev-001", "evt-a6", DateTime.Parse("2025-05-04T12:39:00Z"), "temperature", 23.2, "C"), // And another new event,
                    new TelemetryEvent("acme-123", "dev-001", "evt-a7", DateTime.Parse("2025-05-04T12:40:00Z"), "temperature", 23.5, "C") // Final new event in the sequence,
                    );
            }
            var customer2 = context.Set<Customer>().FirstOrDefault(_ => _.Id == "beta-456");
            if (customer2 == null)
            {
                context.Set<Customer>().Add(new Customer("beta-456", "Beta Corporation"));
                context.Set<Device>().AddRange(
                     new Device("beta-456", "dev-100", "Pump #9", "Site B")
                );
                
                context.Set<TelemetryEvent>().AddRange(new TelemetryEvent("beta-456", "dev-100", "evt-c1", DateTime.Parse("2025-05-04T13:00:00Z"), "temperature", 55.2, "C"));
                
            }
            context.SaveChanges();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context, _) =>
            {
                SeedData(context);
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                SeedData(context);
            });
        }
    }
}
