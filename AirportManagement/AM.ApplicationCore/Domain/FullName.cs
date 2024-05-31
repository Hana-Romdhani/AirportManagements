using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    [Owned ]
    //Dans votre cas, la classe FullName est marquée avec[Owned],
    //    ce qui signifie qu'elle fait partie intégrante de l'entité Passenger.
    //    Les données de la classe FullName seront stockées dans
    //        la même table que l'entité Passenger,
    //        sans avoir sa propre table dans la base de données. configuartion detenus 
    public class FullName
    {   
        [MinLength(3, ErrorMessage = "Longeur Minimale 3!")]
        [MaxLength(25, ErrorMessage = "Longeur Maximale 25!")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
  
    }
}
