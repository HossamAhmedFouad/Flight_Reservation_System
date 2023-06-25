using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Entities
{
    internal class Aircraft
    {
        public int AircraftId { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Capacity { get; set; }

    }
}
