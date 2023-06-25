using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationSystem.Entities
{
    internal class Flight
    {
        public int FlightId { get; set; }
        public int aircraftId { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public DateTime arrivalTime { get; set; }
        public DateTime arrivalDate { get; set; }
        public DateTime departureTime { get; set; }
        public DateTime departureDate { get; set; }
        public string state { get; set; }
        public int requiredNumberOfSeats { get; set; }

        public void displayFlightDetails()
        {
            Console.WriteLine("Flight ID: " + FlightId);
            Console.WriteLine("Aircraft ID: " +aircraftId);
            Console.WriteLine("Route: " + source + " to " + destination);
            Console.WriteLine("Departure: " + departureDate.ToShortDateString() + " " + departureTime.ToString("hh\\:mm") + " " + state);
            Console.WriteLine("Arrival: " + arrivalDate.ToShortDateString() + " " + arrivalTime.ToString("hh\\:mm") + " " + state);
            Console.WriteLine("Required Number of Seats: " + requiredNumberOfSeats);
        }
    }
}
