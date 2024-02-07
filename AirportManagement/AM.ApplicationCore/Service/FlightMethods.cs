using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    {
            IEnumerable<Passenger> query = from p in flight.passengers.OfType<Passenger>()
                                           orderby p.BithDate ascending
                                           select p;
            return query.Take(3).ToList();
        }
    }
}
