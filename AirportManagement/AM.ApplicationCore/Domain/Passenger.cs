using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger 
    {

        public int TelNumber { get; set; }
        public string LastName { get; set;}
        public string FirstName { get; set;}
        public string EmailAddress { get; set;}
        public string PasswordNumber { get; set;}
        public DateTime BithDate { get; set;}
        public ICollection<Flight> flights { get; set; }

    }
}
