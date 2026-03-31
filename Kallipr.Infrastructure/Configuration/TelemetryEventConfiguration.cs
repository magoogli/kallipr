using Kallipr.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallipr.Infrastructure.Configuration
{
    internal class TelemetryEventConfiguration : IEntityTypeConfiguration<TelemetryEvent>
    {
        public void Configure(EntityTypeBuilder<TelemetryEvent> builder)
        {
            builder.HasKey(_ => _.Id);

            // Ensure that we prevent duplicate events for a customer's device.
            builder.HasIndex(_ => new {_.CustomerId, _.DeviceId, _.EventId})
                .IsUnique();

            // Ensure that we can efficiently query events for a particular device.
            builder.HasIndex(_ => new { _.CustomerId, _.DeviceId, _.RecordedAt });

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(_ => _.CustomerId)
                .IsRequired();

            builder.HasOne<Device>()
                .WithMany()
                .HasForeignKey(_ => _.DeviceId)
                .IsRequired();
        }
    }
}
