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
    internal class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(_ => _.Id);

            // Prevent duplicate devices, and ensure efficient device lookups.
            builder.HasIndex(_ => new { _.CustomerId, _.DeviceId })
               .IsUnique();

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(_ => _.CustomerId)
                .IsRequired();
        }
    }
}
