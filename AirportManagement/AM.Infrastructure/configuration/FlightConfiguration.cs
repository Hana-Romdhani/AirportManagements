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
    public class FlightConfiguration:IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {//manytomany
            //builder
            // .HasMany(f => f.passengers)
            // .WithMany(p => p.flights)
            // .UsingEntity(j => j.ToTable("Reservation"));
            //one to many 
            builder
                .HasOne(f => f.myplane)
                .WithMany(p => p.flights)
                .HasForeignKey(f => f.PlaneId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
