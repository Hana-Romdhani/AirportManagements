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
    public class ServicePassenger : Service<Passenger>, IServicePassenger
    {

        IUnitOfWork _unitOfWork;
        public ServicePassenger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._unitOfWork = unitOfWork;

        }

        public IList<Staff> GetStaffs(int flightId)
        {
            return _unitOfWork.Repository<Flight>()
                  .GetById(flightId)
                  .tickets.Select(t => t.MyPassengers)
                  .OfType<Staff>().ToList();

        }


    }
}
