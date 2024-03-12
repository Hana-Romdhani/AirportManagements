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
    public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName,
                full=> { 
                    full.Property(f=>  f.FirstName).HasMaxLength(30).HasColumnName("PassFilghtsName");
                    });
            /*builder.HasDiscriminator<string>("IsTraveller")
                .HasValue<Passenger>("0")
                .HasValue<Traveller>("1")
                .HasValue<Staff>("2");*/
        }
    }
}
