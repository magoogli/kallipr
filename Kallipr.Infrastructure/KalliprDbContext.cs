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
    }
}
