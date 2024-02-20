﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Traveller :Passenger
    {  public int TravellerId { get; set; }
        public string HealthInformation { get; set; }
            public string  Nationality { get; set; }
        public override string ToString()
        {
            return base.ToString() + " la nationality = " + Nationality;
        }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine(" I am a \r\ntraveller");
        }
    }
}
