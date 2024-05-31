using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        public List<DateTime> GetFlightDates(string destination);
        public  void  GetFlights(string filterType, string filterValue);
        public void ShowFlightDetails(Plane plane);
        public void ProgrammedFlightNumber(DateTime startDate);
        public void DurationAverage(string destination);
        public List<Flight> OrderedDurationFlights();
        public List<Passenger> SeniorTravellers(Flight flight);
        public void   DestinationGroupedFlights();

    }
}
