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
        public DbSet<Tenant> Tenants { get; set; }

        public KalliprDbContext(DbContextOptions<KalliprDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(KalliprDbContext).Assembly);
        }
    }
}
