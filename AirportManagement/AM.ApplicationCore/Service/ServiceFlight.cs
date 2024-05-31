using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        IUnitOfWork _unitOfWork;
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public bool BookFlight(int n, Flight flight)
        {
            int capacity = flight.myplane.Capacity;
            int nbrTickets = flight.tickets.Count();
            return capacity - nbrTickets >= n;
        }

        public IList<Flight> GetFlights(int n)
        {
            return
            _unitOfWork.Repository<Plane>()
            .GetAll().OrderByDescending(p => p.PlaneId)
            .Take(n)
            .SelectMany(p => p.flights)
            .OrderBy(f => f.FlightDate).ToList(); ;
        }
        public IList<Passenger> GetTraveller(Plane plane, DateTime date)
        {
            return (IList<Passenger>)GetMany(f=>f.myplane==plane && f.FlightDate==date)
                .SelectMany(f=>f.tickets)
                .Select(t=>t.MyPassengers)
                .OfType<Traveller>()
                .ToList(); 
        }

        public void NbreTraveller(DateTime date1, DateTime date)
        {
             var query=GetMany(f=>f.FlightDate>=date1 && f.FlightDate>=date)
                .SelectMany(f=>f.tickets)
                .GroupBy(f=>f.MyFlights.FlightDate)
                .Select(t => new {count=t.Count(), date=t.Key});
             foreach(var item in query)
            {
                Console.WriteLine("la date : "+item.date+"le nombre des voyageur "+item.count);
            }
        }
        public IEnumerable<Flight> SortFlights()
        {
            return GetAll().OrderByDescending(f => f.FlightDate);
        }
    }
}
