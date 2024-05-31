using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public  interface IServiceFlight : IService<Flight>
    {
        IList<Flight> GetFlights(int n);
        bool BookFlight(int n, Flight flight);
        public IList<Passenger> GetTraveller(Plane plane, DateTime date);
         public void  NbreTraveller(DateTime date1 ,DateTime date);
        public IEnumerable<Flight> SortFlights();

    }
}
