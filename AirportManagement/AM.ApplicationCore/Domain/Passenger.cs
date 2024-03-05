using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
     public class Passenger 
    {
        //public int PassengerId { get; set; }
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^[0-9]{8}$")]

        public int TelNumber { get; set; }
        public string LastName { get; set;}
        [MinLength(3,ErrorMessage ="Longeur Minimale 3!")]
        [MaxLength(25, ErrorMessage = "Longeur Maximale 25!")]
        public string FirstName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set;}
        [Key, StringLength(7)]
        public string PasswordNumber { get; set;}

        [Display(Name ="Date of Birth")]
        [DataType(DataType.DateTime)]
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
