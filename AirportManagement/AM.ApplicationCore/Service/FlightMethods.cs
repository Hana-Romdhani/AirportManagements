using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();
        // pour pointer vers des fonction anonyme 
        
        public Action<Plane> FlightDetailsdel;// si on a pas une retour 
        public Func<string, double> DurationAverageDel ; //sim ona une retour 

        public FlightMethods()
        {
            //FlightDetailsdel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            FlightDetailsdel = p =>
            {
                var query = from f in Flights
                            where f.myplane == p
                            select new { f.FlightDate, f.Destination };
                foreach (var f in query)
                {
                    Console.WriteLine("la destination= " + f.FlightDate + "la destination = " + f.Destination);
                }
            };
            DurationAverageDel = del =>
            {
                var query = from f in Flights
                            where f.Destination == del
                            select f.EstimatedDiration;
                //Console.WriteLine(query.Sum()/query.Count());
                return query.Average();
            };





        }
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
            /*bil LINQ*/
            //IEnumerable<DateTime> query = from f in Flights
            //                              where f.Destination == destination
            //                              select f.FlightDate;

            ////  return result;
            //return query.ToList();
            /*bil lamda*/
            var lamdaquery = Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate);
            return lamdaquery.ToList();
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    foreach (Flight f in Flights)
                    {
                        if (f.Destination == filterValue)
                        {
                            Console.WriteLine(f);
                        }

                    }
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                    {
                        if (f.FlightDate == DateTime.Parse(filterValue))
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
        {
            DateTime endDay = startDate.AddDays(7);
            //var query = from f in Flights
            //            where f.FlightDate >= startDate && f.FlightDate <= endDay
            //            select f;
            var lamdaquery = Flights.Where(f => f.FlightDate < endDay && f.FlightDate >= startDate);
            //Console.WriteLine("le numbre de date entre " + startDate + " " + endDay + "= " + query.Count());
            Console.WriteLine(lamdaquery.Count());
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var query = from f in Flights
            //            where f.myplane == plane
            //            select new { f.FlightDate, f.Destination };
            //foreach (var f in query)
            //{
            //    Console.WriteLine("la destination= " + f.FlightDate + "la destination = " + f.Destination);
            //}

            var query = Flights.Where(f=>f.myplane== plane).Select(f=>new { f.FlightDate ,f.Destination});
            foreach (var f in query)
            {
                Console.WriteLine("la date= " + f.FlightDate + "la destination = " + f.Destination);
            }
        }
        public void DurationAverage(string destination)
        {
            //var query = from f in Flights
            //            where f.Destination == destination
            //            select f.EstimatedDiration;
            ////Console.WriteLine(query.Sum()/query.Count());
            //Console.WriteLine(query.Average());
            //;
            var lamdaquery = Flights.Where(f => f.Destination == destination).Select(f =>   f.EstimatedDiration );
            Console.WriteLine(lamdaquery.Average());
        }

        public List<Flight> OrderedDurationFlights()
        {
            //IEnumerable<Flight> query = from f in Flights
            //                            orderby f.EstimatedDiration descending
            //                            select f;
            //return query.ToList();
            var lamdaquery = Flights.OrderByDescending(f => f.EstimatedDiration);
            return lamdaquery.ToList();
        }

        public List<Passenger> SeniorTravellers(Flight flight)
        {
            //IEnumerable<Passenger> query = from p in flight.passengers.OfType<Passenger>()
            //                               orderby p.BithDate ascending
            //                               select p;

            /* IEnumerable<Passenger> lamdaquery = flight.passengers.OfType<Traveller>()
                   .OrderBy(p=>p.BithDate);
               return lamdaquery.Take(3).ToList();*/
            return null;
        }
        public void DestinationGroupedFlights()


        {
            var lamdaquery = Flights.GroupBy(f => f.Destination);

            //var  query = from flight in Flights
            //                            group flight by flight.Destination into destination
            //                            select destination;
            foreach (var group in lamdaquery)
            {
                Console.WriteLine("Destination " + group.Key);
                foreach (var flight in group)
                {
                    Console.WriteLine("Décollage : " + flight.FlightDate.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }


        }






    }
}