using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
     public class Passenger 
    {
        public int PassengerId { get; set; }
        public int TelNumber { get; set; }
        public string LastName { get; set;}
        public string FirstName { get; set;}
        public string EmailAddress { get; set;}
        public string PasswordNumber { get; set;}
        public DateTime BithDate { get; set;}
        public ICollection<Flight> flights { get; set; }
        public override string ToString()
        {
            return "FirstName="+FirstName+"Lastname"+LastName
            ;
        }

       //public bool CheckProfile(string firstname, string lastname)
       // {
       //     return this.FirstName==firstname && this.LastName==lastname;
       // }
       // public bool CheckProfile(string firstname, string lastname, string email)
       // {
       //     return this.FirstName == firstname &&
       //         this.LastName == lastname  && 
       //         this.EmailAddress == email;
       // }

        public bool CheckProfile(string firstname, string lastname, string? val=null)
        {
            //return this.FirstName == firstname && this.LastName == lastname &&
            //(val == null || this.EmailAddress == val);

            if (val==null)
            {
                return this.FirstName == firstname && this.LastName == lastname;
            }  else
            {
                return this.FirstName == firstname && this.LastName == lastname && this.EmailAddress == val;
            }

        }

        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }


    }
}
