using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.configuration
{
    public class TicketsConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(t => new
            {
                t.PassengerFK,
                t.FlightFK
            });
            builder.HasOne(t => t.MyPassengers)
                .WithMany(p => p.tickets)
                .HasForeignKey(t => t.PassengerFK);

            builder.HasOne(t => t.MyFlights)
                .WithMany(f => f.tickets)
                .HasForeignKey(t => t.FlightFK);
        }
    }
}
