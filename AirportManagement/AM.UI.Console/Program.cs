// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using System.Net.Mail;

Console.WriteLine("Hello, World!");
//Plane p1 = new Plane();
//p1.PlaneID = 1;
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