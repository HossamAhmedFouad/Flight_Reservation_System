using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Entities
{
    internal class Reservation
    {
        public int CustomerID { get; set; }
        public int FlightID { get; set; }
        public int seatNumber { get; set; }
        public float Price { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
    }
}
