using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
       public DateTime  EffectiveArrival { get; set; }
        public   int  EstimatedDiration { get; set; }
        public Plane myplane { get; set; }
        public ICollection<Passenger> passengers { get; set; }
    }
}
