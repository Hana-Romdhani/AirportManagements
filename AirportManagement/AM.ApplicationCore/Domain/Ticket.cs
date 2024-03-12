using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public  class Ticket
    {


        public double Prix { get; set; }
        public int Seige { get; set; }
        public bool VIP { get; set;}
        [ForeignKey("MyFlights")]
        public int FlightFK { get; set; }

        public Flight MyFlights { get; set; }

        [ForeignKey("MyPassengers")]

        public string PassengerFK { get; set; }

        public Passenger MyPassengers { get; set; }

    }
}
