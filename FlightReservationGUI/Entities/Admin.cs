using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Entities
{
    internal class Admin
    {
        public int AdminID { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string gendar { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string email { get; set; }
        public int age { get; set; }
        public string PASSWORD { get; set; }
    }
}
