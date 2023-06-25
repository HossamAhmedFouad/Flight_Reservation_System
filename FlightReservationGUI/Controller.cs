using FlightReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightReservationGUI
{
    internal class Controller
    {
        public static bool loggedAdmin = false;
        public static bool loggedCustomer = false;

        public static bool adminLog = false;
        public static bool customerLog = false;

        public static Admin activeAdmin = null;
        public static Customer activeCustomer = null;

    }
}
