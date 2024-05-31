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
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        IUnitOfWork unitOfWork;
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DeletePlane()
        {
            foreach (Plane p in GetMany(p => (DateTime.Now.Year - p.ManufactureDate.Year) > 10))
            {
                Delete(p);
                Commit();

            }
        }

        public IList<Passenger> getPassengers(Plane plane)
        {

            return unitOfWork.Repository<Plane>()// when we want to call methode de crud when we are in service of other entity not same sevice for the entity ken hajty bi flight w ena fi plane naaytelha
                  .GetById(plane.PlaneId)
                  .flights
                  .SelectMany(f => f.tickets)
                  .Select(t => t.MyPassengers)
                  .OfType<Passenger>()
                   .Distinct()// meme vouyageur prend meme flight plusieurs fois
                  .ToList();
        }


    }
}
