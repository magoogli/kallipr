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
            throw new NotImplementedException();
        }
    }
}
