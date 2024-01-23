using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff :Passenger
    {

        public DateTime EmployementDate { get; set; }
        public string Function { get; set; }
        public double Salary { get; set; }

    }
}
