using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class FlightMethods:IFlightMethods
    {
        public List<Flight> Flights { get; set; }=new List<Flight>();

       

        public List<DateTime> GetFlightDates(string destination)
        {
          //  List<DateTime> result = new List<DateTime>();

            //for (int i=0;i< Flights.Count();i++) {
            //if (Flights[i].Destination == destination) { 
            //    result.Add(Flights[i].FlightDate); 
            //}
            //   
            //}

            //foreach (Flight f in Flights)
            //{
            //    if (f.Destination == destination)
            //    {
            //        result.Add(f.FlightDate);

            //    }

            //}
             IEnumerable<DateTime> query=from f in Flights
                       where f.Destination == destination
                       select f.FlightDate;

            //  return result;
             return query.ToList();

        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if(f.Destination == filterValue)
                        {
                            Console.WriteLine(f);
                        }

                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse( filterValue))
                        {
                            Console.WriteLine(f);
                        }

                    }
                    break;
                case "EstimatedDiration":
                    foreach (Flight f in Flights)
                    {
                        if (f.EstimatedDiration == int.Parse(filterValue))
                        {
                            Console.WriteLine(f);
                        }

                    }
                    break;

            }
        }

        public void ProgrammedFlightNumber(DateTime startDate)
        { DateTime  endDay=startDate.AddDays(7);
                var query = from f in Flights
                        where f.FlightDate>= startDate && f.FlightDate<=endDay
                        select  f;
            Console.WriteLine("le numbre de date entre "+ startDate+" "+ endDay +"= "+query.Count());
        }

        public void ShowFlightDetails(Plane plane)
        { var query= from f in Flights
                     where f.myplane == plane
                     select new { f.FlightDate, f.Destination};
            foreach (var f in query)
            {
                Console.WriteLine("la destination= " + f.FlightDate+"la destination = "+f.Destination);
            }       
        }
        public void DurationAverage(string destination)
        {
            var query = from f in Flights
                        where f.Destination == destination
                        select f.EstimatedDiration;
            //Console.WriteLine(query.Sum()/query.Count());
            Console.WriteLine(query.Average());
            ;
        }

        public List<Flight> OrderedDurationFlights()
        {
            IEnumerable<Flight> query = from f in Flights
                                 orderby f.EstimatedDiration descending
                                 select f;
            return query.ToList();
        }
    }
}
