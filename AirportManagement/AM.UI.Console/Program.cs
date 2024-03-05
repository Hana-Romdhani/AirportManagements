// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Service;
using AM.Infrastructure;
using System.Net.Mail;

Console.WriteLine("Hello, World!");
Plane p1 = new Plane();
p1.PlaneId = 1;
//p1.capacity = 1;
//p1.ManuFactureDate = new DateTime(2021, 01, 30);
//p1.PlaneType = PlaneType.Boing;

//Plane p2 = new Plane(PlaneType.Airbus, 300, new DateTime(2021, 01, 30)); 
//Plane p3 = new Plane();

Plane p3 = new Plane
{
    PlaneType = PlaneType.Airbus,
    Capacity = 250,
    PlaneId = 3,
    ManufactureDate = DateTime.Now,

};
Console.WriteLine(p3.ToString());
Console.WriteLine(p3);

Passenger ps1 = new Passenger
{
    FirstName = "hana",
    LastName = "Romdhani",
    EmailAddress="hana@gmail.com"
};
Console.WriteLine(ps1.ToString());
Console.WriteLine(ps1.CheckProfile("hana", "Romdhani"));
Console.WriteLine(ps1.CheckProfile("hana","Romdhani", "hana@gmail.com"));
Staff stf = new Staff
{
    Function="HEHUH"

};
Traveller pas = new Traveller
{
    Nationality="Tunis"
};
stf.PassengerType();
pas.PassengerType();

FlightMethods fm = new FlightMethods
{
    Flights = TestData.listFlights
};
foreach (var item in fm.GetFlightDates("Paris"))
{
    Console.WriteLine(item);
}
fm.GetFlights("Destination", "Madrid");
Console.WriteLine("/*****************************/");
fm.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine("/************retour avec delegue sans parametre    *****************/");
fm.FlightDetailsdel(TestData.BoingPlane);
Console.WriteLine("/*******************  *****************/");

fm.ProgrammedFlightNumber(new DateTime(2022, 02, 01, 21, 10, 10));
Console.WriteLine("/*****************************/");

fm.DurationAverage("Paris");
Console.WriteLine("/************List des Vol *****************/");
foreach (var item in fm.OrderedDurationFlights())
{
    Console.WriteLine(item);
}
Console.WriteLine("/************Passenger *****************/");
foreach (var item in fm.SeniorTravellers(TestData.flight1))
{
    Console.WriteLine(item);
}
Console.WriteLine("/************Flights date  *****************/");


fm.DestinationGroupedFlights();
Console.WriteLine("/*****************************/");

Passenger passe = new Passenger
{
    FirstName= "hana",
    LastName= "romdhani",


};
Console.WriteLine("Before:", passe);
passe.UpperFullName();
Console.WriteLine("After :", passe);
AMContext context = new AMContext
{
};
context.Flights.Add(TestData.flight2);
context.SaveChanges();

