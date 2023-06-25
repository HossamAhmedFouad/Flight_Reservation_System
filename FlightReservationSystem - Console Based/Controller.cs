using FlightReservationSystem.Entities;
using FlightReservationSystem.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace FlightReservationSystem
{
    internal class Controller
    {
        ///////////////////////////////////// Active User /////////////////////////////
      
        public bool loggedCustomer = false;
        public bool loggedAdmin = false;

        public Admin activeAdmin = null;
        public Customer activeCustomer = null;
        

        ////////////////////////////////////////////////////////////////////////////////
       


        ////////////////////////////////////// SYSTEM MAIN MENU ////////////////////////////////
        public void displayMainMenu()
        {
            Console.WriteLine("Welcome To Our Flight Reservation Application, Please Select An Option");
            Console.WriteLine("1 - Sign Up");
            Console.WriteLine("2 - Log In");
            Console.WriteLine("3 - Exit");
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        public void signup()
        {
            while (true)
            {
                Console.WriteLine("Please Choose An Option");
                Console.WriteLine("1 - Sign Up As Customer");
                Console.WriteLine("2 - Sign Up As Admin");
                Console.WriteLine("3 - Go Back");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    CustomerDAO.insertCustomer(customerSignUp());
                    Console.WriteLine("Registartion has been successful,returning back to main menu");
                }
                else if(choice == 2)
                {
                    AdminDAO.insertAdmin(adminSignUp());
                    Console.WriteLine("Registartion has been successful,returning back to main menu");
                }else if (choice == 3)
                {
                    break;
                }
            }
        }

        public Admin adminSignUp()
        {
            string firstName, lastname, gender, email,password;
            DateTime dob;
            int adminAge, id= AdminDAO.getAdmins().Count + 1;

            Console.Write("First Name: "); firstName = Console.ReadLine();
            Console.Write("Last Name: "); lastname = Console.ReadLine();
            Console.Write("Gender: "); gender = Console.ReadLine();
            Console.Write("Date of Birth and Time YYYY-MM-DD HH:MM:SS  : ");
            string inp = Console.ReadLine();
            if(DateTime.TryParse(inp,out dob))
            {
                Console.WriteLine("You Entered: " + dob.ToString());
            }
            else
            {
                Console.WriteLine("Invalid Date and Time Format");
            }
            Console.Write("Age: "); adminAge = int.Parse(Console.ReadLine());
            Console.Write("Email: "); email = Console.ReadLine();
            Console.Write("Password: "); password = Console.ReadLine();

            Admin admin = new Admin
            {
                AdminID = id,
                fname = firstName,
                lname = lastname,
                age = adminAge,
                dateOfBirth = dob,
                gendar = gender,
                email = email,
                PASSWORD = password
            };
           
            return admin;
        }

        public Customer customerSignUp()
        {
            string firstName, lastname, gender, email, password;
            DateTime dob;
            int adminAge, id = 0;

            Console.Write("First Name: "); firstName = Console.ReadLine();
            Console.Write("Last Name: "); lastname = Console.ReadLine();
            Console.Write("Gender: "); gender = Console.ReadLine();
            Console.Write("Date of Birth and Time YYYY-MM-DD HH:MM:SS  : ");
            string inp = Console.ReadLine();
            if (DateTime.TryParse(inp, out dob))
            {
                Console.WriteLine("You Entered: " + dob.ToString());
            }
            else
            {
                Console.WriteLine("Invalid Date and Time Format");
            }
            Console.Write("Age: "); adminAge = int.Parse(Console.ReadLine());
            Console.Write("Email: "); email = Console.ReadLine();
            Console.Write("Password: "); password = Console.ReadLine();

            Customer customer = new Customer
            {
                CustomerID = CustomerDAO.getCustomers().Count + 1,
                fname = firstName,
                lname = lastname,
                DataOfBirth = dob,
                gender = gender,
                email = email,
                password = password
            };
            return customer;
        }

        public void login()
        {
            while (true)
            {
                Console.WriteLine("Please choose an action");
                Console.WriteLine("1 - Login As Customer");
                Console.WriteLine("2 - Login As Admin");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    loggedCustomer = customerLogin();
                    if (loggedCustomer)
                    {
                        loggedAdmin = false;
                        break;
                    }
                }else if(choice == 2)
                {
                    loggedAdmin = adminLogin();
                    if (loggedAdmin)
                    {
                        loggedCustomer = false;
                        break;
                    }
                }
            }
        }

        public bool adminLogin()
        {
            string email, pass;
            Console.Write("Email: "); email = Console.ReadLine();
            Console.Write("Password: "); pass = Console.ReadLine();
            if(AdminDAO.ValidateCredentials(email, pass))
            {
                activeAdmin = AdminDAO.getAdmin(email);
                activeCustomer = null;
                Console.WriteLine("Login Has Been Successful, Welcome " + activeAdmin.fname);
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
                return false;
            }

        }

        public bool customerLogin()
        {
            string email, pass;
            Console.Write("Email: "); email = Console.ReadLine();
            Console.Write("Password: "); pass = Console.ReadLine();
            if (CustomerDAO.ValidateCredentials(email, pass))
            {
                activeCustomer = CustomerDAO.getCustomer(email);
                activeAdmin = null;
                Console.WriteLine("Login Has Been Successful, Welcome " + activeCustomer.fname);
                return true;
            }
            else
            {
                Console.WriteLine("Invalid Credentials");
                return false;
            }
        }

        public void displayFunctionality()
        {

            if (loggedCustomer)
            {
                while (true)
                {
                  
                    Console.WriteLine("Please Enter An Option");
                    Console.WriteLine("1 - Update Details");
                    Console.WriteLine("2 - Show List Of Avaialble Flights");
                    Console.WriteLine("3 - Manage Reservations");
                    Console.WriteLine("4 - Add A Phone Number");
                    Console.WriteLine("5 - Sign Out");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        updateDetails();
                    }else if(choice == 2)
                    {
                        showAvailableFlights();
                    }else if (choice == 3)
                    {
                        ManageReservations();
                    }else if (choice == 4)
                    {
                        while (true)
                        {
                            Console.WriteLine("Please Enter Phone Numbers, any invalid phone number (chars < 11) will stop taking input");
                            string phone = Console.ReadLine();
                            if (phone.Length < 11)
                            {
                                break;
                            }
                            else
                            {
                                CustomerPhoneDAO.addCustomerPhone(activeCustomer.CustomerID, phone);
                            }
                        }
                    }else if (choice == 5)
                    {
                        loggedCustomer = false;
                        activeCustomer = null;
                        break;
                    }
                }
            }else if (loggedAdmin)
            {
                while (true)
                {
                    Console.WriteLine("Please Enter An Option");
                    Console.WriteLine("1 - Update Details");
                    Console.WriteLine("2 - Add a new Phone Number");
                    Console.WriteLine("3 - Manage Flights");
                    Console.WriteLine("4 - Manage Aircrafts");
                    Console.WriteLine("5 - Manage Customers' Reservations");
                    Console.WriteLine("6 - Manage Customers");
                    Console.WriteLine("7 - Sign Out");
                    int choice = int.Parse(Console.ReadLine());
                    if(choice == 1)
                    {
                        updateDetails();
                    }else if(choice == 2)
                    {
                        while (true)
                        {
                            Console.WriteLine("Please Enter Phone Numbers, any invalid phone number (chars < 11) will stop taking input");
                            string phone = Console.ReadLine();
                            if (phone.Length < 11)
                            {
                                break;
                            }
                            else
                            {
                                AdminPhoneDAO.addAdminPhone(activeAdmin.AdminID, phone);
                            }
                        }
                    }
                    else if( choice == 3)
                    {
                        ManageFlights();
                    }else if(choice == 4)
                    {
                        ManageAircrafts();
                    }else if (choice == 5)
                    {
                        ManageReservations();
                    }
                    else if (choice == 6)
                    {
                        ManageCustomers();
                    }
                    else if (choice == 7)
                    {
                        loggedAdmin = false;
                        activeAdmin = null;
                        break;
                    }
                }
            }
        }

        public void updateDetails()
        {
            if (loggedCustomer)
            {
                Customer customer = customerSignUp();
                customer.CustomerID = activeCustomer.CustomerID;
                CustomerDAO.updateCustomer(customer);
                activeCustomer = customer;
            }
            if (loggedAdmin)
            {
                Admin admin = adminSignUp();
                admin.AdminID = activeAdmin.AdminID;
                AdminDAO.updateAdmin(admin);
                activeAdmin = admin;
            }

        }

        public void showAvailableFlights()
        {
            List<Flight> flights = FlightDAO.getFlights();
            foreach (Flight flight in flights)
            { 
                flight.displayFlightDetails();
                Console.WriteLine("//////////////////////////////////////////");
            }
            while (true)
            {
                Console.WriteLine("Please Choose An Action");
                Console.WriteLine("1 - Filter by Source");
                Console.WriteLine("2 - Filter by Destination");
                Console.WriteLine("3 - Filter by Date");
                Console.WriteLine("4 - Filter by Required Number Of Seats (>=)");
                Console.WriteLine("5 - Go Back");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Console.Write("Please Enter Source: ");
                    string src = Console.ReadLine();
                    List<Flight> f = FlightDAO.getFlightsBySource(src);
                    foreach (Flight flight in f)
                    {
                        flight.displayFlightDetails();
                        Console.WriteLine("//////////////////////////////////////////");
                    }

                }
                else if(choice == 2)
                {
                    Console.Write("Please Enter Destination: ");
                    string dest = Console.ReadLine();
                    List<Flight> f = FlightDAO.getFlightsByDestination(dest);
                    foreach (Flight flight in f)
                    {
                        flight.displayFlightDetails();
                        Console.WriteLine("//////////////////////////////////////////");
                    }

                }
                else if (choice == 3)
                {
                    Console.Write("Please Enter Date and Time YYYY-MM-DD HH:MM:SS  : ");
                    string inp = Console.ReadLine();
                    DateTime d;
                    if (DateTime.TryParse(inp, out d))
                    {
                        Console.WriteLine("You Entered: " + d.ToString());
                        List<Flight> f = FlightDAO.getFlightsByDate(d);
                        foreach (Flight flight in f)
                        {
                            flight.displayFlightDetails();
                            Console.WriteLine("//////////////////////////////////////////");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Date and Time Format");
                    }
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Please Enter Required Number Of Seats");
                    int seats = int.Parse(Console.ReadLine());
                    List<Flight> f = FlightDAO.getFlightsByRequiredSeats(seats);
                    foreach (Flight flight in f)
                    {
                        flight.displayFlightDetails();
                        Console.WriteLine("//////////////////////////////////////////");
                    }
                }
                else if (choice == 5)
                {
                    break;
                }
            }

        }

        public void ManageReservations()
        {
            if (loggedCustomer)
            {
                while (true)
                {
                    Console.WriteLine("Please Choose An Action");
                    Console.WriteLine("1 - Create A Reservation");
                    Console.WriteLine("2 - Show Reservations");
                    Console.WriteLine("3 - Update A Reservation");
                    Console.WriteLine("4 - Cancel A Reservation");
                    Console.WriteLine("5 - Go Back");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        ReservationDAO.insertReservation(CreateReservation());

                    }else if(choice == 2)
                    {
                        DisplayReservations(ReservationDAO.getAllReservationsByCustomerId(activeCustomer.CustomerID));
                    }else if(choice == 3)
                    {
                        DisplayReservations(ReservationDAO.getAllReservationsByCustomerId(activeCustomer.CustomerID));
                        Console.Write("Please Enter Flight ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter Seat Number: ");
                        int seat = int.Parse(Console.ReadLine());
                        Console.WriteLine("Please Enter The New Fields");
                        ReservationDAO.updateReservation(activeCustomer.CustomerID, id, seat, CreateReservation());
                    }
                    else if (choice == 4)
                    {
                        DisplayReservations(ReservationDAO.getAllReservationsByCustomerId(activeCustomer.CustomerID));
                        Console.Write("Please Enter Flight ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter Seat Number: ");
                        int seat = int.Parse(Console.ReadLine());
                        ReservationDAO.deleteReservation(activeCustomer.CustomerID, id,seat);
                    }
                    else if (choice == 5)
                    {
                        break;
                    }
                }
            }else if (loggedAdmin)
            {
                List<Reservation> reservations = ReservationDAO.getAllReservations();
                while (true)
                {
                    Console.WriteLine("Please Choose An Action");
                    Console.WriteLine("1 - Show Reservations");
                    Console.WriteLine("2 - Update A Reservation");
                    Console.WriteLine("3 - Cancel A Reservation");
                    Console.WriteLine("4 - Go Back");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        DisplayReservations(reservations);
                    }else if (choice == 2)
                    {
                        DisplayReservations(reservations);
                        Console.Write("Please Enter Customer ID: ");
                        int custID = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter Flight ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter Seat Number: ");
                        int seat = int.Parse(Console.ReadLine());
                        ReservationDAO.updateReservation(custID, id, seat,CreateReservation());
                        reservations = ReservationDAO.getAllReservations();

                    }
                    else if (choice == 3)
                    {
                        DisplayReservations(reservations);
                        Console.Write("Please Enter Customer ID: ");
                        int custID = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter Flight ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Please Enter Seat Number: ");
                        int seat = int.Parse(Console.ReadLine());
                        ReservationDAO.deleteReservation(custID, id, seat);
                        reservations = ReservationDAO.getAllReservations();
                    }
                    else if (choice == 4)
                    {
                        break;
                    }
                }
            }
        }
        public void DisplayReservations(List<Reservation> reservations)
        {
            Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12} {6,-12}", "CustomerID", "FlightID", "SeatNumber", "Price", "Class", "Type", "State");
            Console.WriteLine("----------------------------------------------------------------");

            foreach (Reservation reservation in reservations)
            {
                Console.WriteLine("{0,-12} {1,-12} {2,-12} {3,-12} {4,-12} {5,-12} {6,-12}", reservation.CustomerID, reservation.FlightID, reservation.seatNumber, reservation.Price, reservation.Class, reservation.Type, reservation.State);
            }
        }
        public Reservation CreateReservation()
        {
            Reservation reservation = new Reservation();

            Console.Write("Enter Customer ID: ");
            reservation.CustomerID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Flight ID: ");
            reservation.FlightID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Seat Number: ");
            reservation.seatNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            reservation.Price = Convert.ToSingle(Console.ReadLine());

            Console.Write("Enter Class: ");
            reservation.Class = Console.ReadLine();

            Console.Write("Enter Type: ");
            reservation.Type = Console.ReadLine();

            Console.Write("Enter State: ");
            reservation.State = Console.ReadLine();

            return reservation;
        }
        public Aircraft CreateAircraft()
        {
            Aircraft newAircraft = new Aircraft();

            Console.Write("Enter Aircraft ID: ");
            newAircraft.AircraftId = int.Parse(Console.ReadLine());

            Console.Write("Enter Model: ");
            newAircraft.Model = Console.ReadLine();

            Console.Write("Enter Color (press Enter to skip): ");
            string colorInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(colorInput))
            {
                newAircraft.Color = colorInput;
            }

            Console.Write("Enter Capacity: ");
            newAircraft.Capacity = int.Parse(Console.ReadLine());

            return newAircraft;
        }
        public Flight CreateFlight()
        {
            Flight newFlight = new Flight();

            Console.Write("Enter Flight ID: ");
            newFlight.FlightId = int.Parse(Console.ReadLine());

            Console.Write("Enter Aircraft ID: ");
            newFlight.aircraftId = int.Parse(Console.ReadLine());

            Console.Write("Enter Source: ");
            newFlight.source = Console.ReadLine();

            Console.Write("Enter Destination: ");
            newFlight.destination = Console.ReadLine();

            Console.Write("Enter Arrival Date (yyyy-MM-dd): ");
            newFlight.arrivalDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Arrival Time (HH:mm:ss): ");
            newFlight.arrivalTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Departure Date (yyyy-MM-dd): ");
            newFlight.departureDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Departure Time (HH:mm:ss): ");
            newFlight.departureTime = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter State: ");
            newFlight.state = Console.ReadLine();

            Console.Write("Enter Required Number of Seats: ");
            newFlight.requiredNumberOfSeats = int.Parse(Console.ReadLine());

            return newFlight;
        }

        public void ManageCustomers()
        {
            while (true)
            {
                Console.WriteLine("Please Choose An Action");
                Console.WriteLine("1 - View All Customers With Phone Numbers");
                Console.WriteLine("2 - Delete A Customer's Phone Number");
                Console.WriteLine("3 - Go Back");
                int choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    DisplayCustomers(CustomerDAO.GetCustomersWithPhones());
                }else if(choice == 2)
                {
                    DisplayCustomers(CustomerDAO.GetCustomersWithPhones());
                    Console.Write("Please Enter Customer ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Please Enter Phone Number To Delete: ");
                    string phone = Console.ReadLine();
                    CustomerPhoneDAO.DeleteCustomerPhone(phone, id);
                }else if(choice == 3)
                {
                    break;
                }
            }
        }

        public void PrintAircraftList(List<Aircraft> aircraftList)
        {
            // Display the results in a table format
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}", "ID", "Model", "Color", "Capacity");
            Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}", "----------", "--------------------", "---------------", "----------");
            foreach (Aircraft aircraft in aircraftList)
            {
                Console.WriteLine("{0,-10} {1,-20} {2,-15} {3,-10}", aircraft.AircraftId, aircraft.Model, aircraft.Color ?? "", aircraft.Capacity);
            }
        }

        public void DisplayCustomers(List<Customer> customers)
            {
                // Display the results in a table format
                Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-10} {4,-20} {5,-30} {6,-15}", "ID", "First Name", "Last Name", "Gender", "Date of Birth", "Email", "Phone Number");
                Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-10} {4,-20} {5,-30} {6,-15}", "----------", "----------", "----------", "------", "---------------", "------------------------------", "---------------");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-20} {3,-10} {4,-20:d} {5,-30} {6,-15}", customer.CustomerID, customer.fname, customer.lname, customer.gender, customer.DataOfBirth, customer.email, customer.phone);
                }
            }
        public void ManageAircrafts()
            {
                while (true)
                {
                    Console.WriteLine("Please Choose Action");
                    Console.WriteLine("1 - Show Available Aircrafts");
                    Console.WriteLine("2 - Add A New Aircraft");
                    Console.WriteLine("3 - Add An Aircraft Class");
                    Console.WriteLine("4 - Update An Aircraft");
                    Console.WriteLine("5 - Go Back");
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        PrintAircraftList(AircraftDAO.getAllAircrafts());
                    }else if (choice == 2)
                    {
                        AircraftDAO.updateAircraft(CreateAircraft());

                    }else if(choice == 3)
                    {
                        Console.Write("Enter Aircraft ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Enter Class: ");
                        string clss = Console.ReadLine();
                        AircraftClassDAO.AddAircraftToClass(clss, id);

                    }else if (choice == 4)
                    {
                        AircraftDAO.updateAircraft(CreateAircraft());

                    }else if (choice == 5)
                    {
                        break;
                    }
                }
            }

        public void ManageFlights()
        {
            while (true)
            {
                Console.WriteLine("Please Choose Action");
                Console.WriteLine("1 - Show Available Flights");
                Console.WriteLine("2 - Add A New Flight");
                Console.WriteLine("3 - Update A Flight");
                Console.WriteLine("4 - Go Back");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    showAvailableFlights();
                }else if (choice == 2)
                {
                    FlightDAO.addNewFlight(CreateFlight());
                }else if (choice == 3)
                {
                    FlightDAO.updateFlight(CreateFlight());
                }else if(choice == 4)
                {
                    break;
                }
            }
        }

        ////////////////////////////////////////// Application Controlling Function ///////////////////////////
        public void start()
        {
            while (true)
            {
                displayMainMenu();
                int choice = int.Parse(Console.ReadLine());
                if(choice == 1)
                {
                    signup();
                }else if (choice == 2)
                {
                    login();
                }else if (choice == 3)
                {
                    break;
                }

                if (loggedAdmin || loggedCustomer)
                {
                    displayFunctionality();
                }

            }
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////
    }
}
