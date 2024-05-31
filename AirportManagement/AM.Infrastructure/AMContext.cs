using AM.ApplicationCore.Domain;
using AM.Infrastructure.configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AM.Infrastructure
{
    public  class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
             Initial Catalog=AirportManagementDBhanaromdhani;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
      //dbset
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());
            modelBuilder.ApplyConfiguration(new TicketsConfiguration());

            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Traveller");


            //modelBuilder.Entity<Facture>().HasOne(t => t.Compteurs)
            //  .WithMany(p => p.factures)
            //.HasForeignKey(t => t.CompteFK);

            //modelBuilder.Entity<Facture>().HasOne(t => t.periodes)
            //    .WithMany(f => f.factures)
            //    .HasForeignKey(t => t.PeriodesFK);

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configBuilder)
        {
            configBuilder.Properties<DateTime>().HaveColumnType("date");
            //configBuilder.Properties<DateTime>().HaveColumnType("date");
            //configBuilder.Properties<string>().HaveMaxLength(150);
        }


    }
}
