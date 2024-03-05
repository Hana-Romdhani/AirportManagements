using System.ComponentModel.DataAnnotations.Schema;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public int FlightId { get; set; }
        public string? Destination { get; set; }
        public string? Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDiration { get; set; }
        [ForeignKey("myplane")]// representation de relation entre plane et foreign key flights
        public int PlaneId { get; set; }
        public Plane myplane { get; set; }

        public string AirlineLogo { get; set; }
        public ICollection<Passenger> passengers { get; set; }
        
        public override string ToString()
        {
            return "la destination = " + Destination + "la durée = " + EstimatedDiration;
        }
    }
}
