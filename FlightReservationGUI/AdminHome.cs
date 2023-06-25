using FlightReservationSystem;
using FlightReservationSystem.Data_Access;
using FlightReservationSystem.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using SqlConnection = System.Data.SqlClient.SqlConnection;
using SqlDataAdapter = System.Data.SqlClient.SqlDataAdapter;

namespace FlightReservationGUI
{
    public partial class AdminHome : Form
    {
        public AdminHome()
        {
            InitializeComponent();
        }

        private void parrotPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroEllipse1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void bigLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Flights_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FlightDAO.getFlights();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (aircraftIdHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Aircraft ID");
                return;
            }

            if (sourceHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Source");
                return;
            }

            if(destinationHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Destination");
                return;
            }

            if(stateholder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter State");
                return;
            }

            if(seatsHolder.Value == 0)
            {
                MessageBox.Show("Please Enter A Valid Seats Number");
                return;
            }

            Flight flight = new Flight
            {
                FlightId = FlightDAO.GetMaxFlightId() + 1,
                aircraftId = int.Parse(aircraftIdHolder.textBox.Text),
                source = sourceHolder.textBox.Text,
                destination = destinationHolder.textBox.Text,
                arrivalTime = datePickArriveTime.Value,
                arrivalDate = datePickArriveDate.Value,
                departureTime = datepickDepartureTime.Value,
                departureDate = datePickDepartureDate.Value,
                state = stateholder.textBox.Text,
                requiredNumberOfSeats = (int)seatsHolder.Value
            };

            FlightDAO.addNewFlight(flight);
            dataGridView1.DataSource = FlightDAO.getFlights();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Controller.loggedAdmin = false;
            Controller.activeAdmin = null;
            this.Visible = false;
            new home().ShowDialog();
            this.Close();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            object cellValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;

            Flight updatedFlight = new Flight
            {
                FlightId = (int)dataGridView1.Rows[rowIndex].Cells[0].Value,
                aircraftId = (int)dataGridView1.Rows[rowIndex].Cells[1].Value,
                source = (string)dataGridView1.Rows[rowIndex].Cells[2].Value,
                destination = (string)dataGridView1.Rows[rowIndex].Cells[3].Value,
                arrivalTime = (DateTime)dataGridView1.Rows[rowIndex].Cells[4].Value,
                arrivalDate = (DateTime)dataGridView1.Rows[rowIndex].Cells[5].Value,
                departureTime = (DateTime)dataGridView1.Rows[rowIndex].Cells[6].Value,
                departureDate = (DateTime)dataGridView1.Rows[rowIndex].Cells[7].Value,
                state = (string)dataGridView1.Rows[rowIndex].Cells[8].Value,
                requiredNumberOfSeats = (int)dataGridView1.Rows[rowIndex].Cells[9].Value
            };
            FlightDAO.updateFlight(updatedFlight);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (sourceDestRadio.Checked)
            {
                if (source_dest.textBox.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Source/Destination or Change Filter!");
                    return;
                }
                else
                {
                    dataGridView1.DataSource = FlightDAO.getFlightsBySource(source_dest.textBox.Text);
                }
            }else if (dateRadio.Checked)
            {
                dataGridView1.DataSource = FlightDAO.getFlightsByDate(dateFilter.Value);
            }else if (seatsRadio.Checked)
            {
                dataGridView1.DataSource = FlightDAO.getFlightsByRequiredSeats((int)seatsFilter.Value);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Aircrafts_Click(object sender, EventArgs e)
        {

        }

        private void AdminHome_Load(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void cyberTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (aircraftHolder.textBox.Text == "" || adminHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information (Aircraft ID or Admin ID)");
                return;
            }
            ManageAircraftDAO.UpdateManageAircraft(new ManageAircraft
            {
                AdminID = int.Parse(adminHolder.textBox.Text),
                AircraftID = int.Parse(aircraftHolder.textBox.Text)
            });
            MessageBox.Show("Aircraft Manager Updated");
            dataGridmanageAircraft.DataSource = ManageAircraftDAO.GetManageAircraft();
            adminHolder.textBox.Text = aircraftHolder.textBox.Text = String.Empty;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (aircraftHolder.textBox.Text == "" || adminHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information (Aircraft ID or Admin ID)");
                return;
            }

            ManageAircraftDAO.InsertManageAircraft(new ManageAircraft
            {
                AdminID = int.Parse(adminHolder.textBox.Text),
                AircraftID = int.Parse(aircraftHolder.textBox.Text)
            });

            MessageBox.Show("Aircraft Manager Added");
            aircraftHolder.textBox.Text = adminHolder.textBox.Text = String.Empty;
            dataGridmanageAircraft.DataSource = ManageAircraftDAO.GetManageAircraft();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (aircraftHolder.textBox.Text == "" || adminHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information (Aircraft ID or Admin ID)");
                return;
            }

            ManageAircraftDAO.DeleteManageAircraft(int.Parse(adminHolder.textBox.Text), int.Parse(aircraftHolder.textBox.Text));
            MessageBox.Show("Aircraft Manager Deleted");
            aircraftHolder.textBox.Text = adminHolder.textBox.Text = String.Empty;
            dataGridmanageAircraft.DataSource = ManageAircraftDAO.GetManageAircraft();
        }

        private void cyberTextBox2_Load(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (capacityHolder.textBox.Text == "" || colorHolder.textBox.Text == "" || aircraftHolder.textBox.Text == "" || modelHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information (Aircraft ID or Color or Model or Capacity)");
                return;
            }

            Aircraft aircraft = new Aircraft
            {
                AircraftId = int.Parse(aircraftHolder.textBox.Text),
                Model = modelHolder.textBox.Text,
                Color = colorHolder.textBox.Text,
                Capacity = int.Parse(capacityHolder.textBox.Text)
            };

            AircraftDAO.addNewAircraft(aircraft);
            MessageBox.Show("Aircraft Added");
            dataGridViewMain.DataSource = AircraftDAO.getAllAircrafts();
            capacityHolder.textBox.Text = colorHolder.textBox.Text = aircraftHolder.textBox.Text = modelHolder.textBox.Text = string.Empty;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            dataGridViewMain.DataSource = AircraftDAO.getAllAircrafts();
            dataGridAircraftClass.DataSource = AircraftClassDAO.GetAircraftClasses();
            dataGridmanageAircraft.DataSource = ManageAircraftDAO.GetManageAircraft();
            dataGridReservations.DataSource = ReservationDAO.getAllReservations();
            dataGridCustomers.DataSource = CustomerDAO.getCustomers();
        }

        private void updateMainBtn_Click(object sender, EventArgs e)
        {
            if (capacityHolder.textBox.Text == "" || colorHolder.textBox.Text == "" || aircraftHolder.textBox.Text == "" || modelHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information (Aircraft ID or Color or Model or Capacity)");
                return;
            }

            AircraftDAO.updateAircraft(new Aircraft
            {
                AircraftId = int.Parse(aircraftHolder.textBox.Text),
                Model = modelHolder.textBox.Text,
                Color = colorHolder.textBox.Text,
                Capacity = int.Parse(capacityHolder.textBox.Text)
            });
            MessageBox.Show("Aircraft Updated");
            dataGridViewMain.DataSource = AircraftDAO.getAllAircrafts();
            capacityHolder.textBox.Text = colorHolder.textBox.Text = aircraftHolder.textBox.Text = modelHolder.textBox.Text = string.Empty;
        }

        private void deleteMainBtn_Click(object sender, EventArgs e)
        {
            if (aircraftHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information , Enter ID");
                return;
            }
            AircraftDAO.DeleteAircraft(int.Parse(aircraftHolder.textBox.Text));
            MessageBox.Show("Aircraft Deleted");
            dataGridViewMain.DataSource = AircraftDAO.getAllAircrafts();
            capacityHolder.textBox.Text = colorHolder.textBox.Text = aircraftHolder.textBox.Text = modelHolder.textBox.Text = string.Empty;
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            dataGridViewMain.DataSource = AircraftDAO.getAllAircrafts();
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (aircraftHolder.textBox.Text == "" || classHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information (Aircraft ID or Class)");
                return;
            }

            AircraftClassDAO.AddAircraftToClass(classHolder.textBox.Text, int.Parse(aircraftHolder.textBox.Text));
            MessageBox.Show("Aircraft_Class Added");
            dataGridAircraftClass.DataSource = AircraftClassDAO.GetAircraftClasses();
            aircraftHolder.textBox.Text = classHolder.textBox.Text = string.Empty;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (aircraftHolder.textBox.Text == "" || classHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information (Aircraft ID or Class)");
                return;
            }

            AircraftClassDAO.UpdateAircraftClass(new Aircraft_Class
            {
                AircraftID = int.Parse(aircraftHolder.textBox.Text),
                Class = classHolder.textBox.Text
            });
            MessageBox.Show("Aircraft_Class Updated");
            dataGridAircraftClass.DataSource = AircraftClassDAO.GetAircraftClasses();
            aircraftHolder.textBox.Text = classHolder.textBox.Text = string.Empty;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (aircraftHolder.textBox.Text == "")
            {
                MessageBox.Show("Missing Information , Enter ID");
                return;
            }
            AircraftClassDAO.DeleteAircraftClass(int.Parse(aircraftHolder.textBox.Text));
            MessageBox.Show("Aircraft_Class Updated");
            dataGridAircraftClass.DataSource = AircraftClassDAO.GetAircraftClasses();
            aircraftHolder.textBox.Text = classHolder.textBox.Text = string.Empty;
        }

        private void showManageBtn_Click(object sender, EventArgs e)
        {
      
            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to join the Aircraft and manageAircraft tables
            string query = "SELECT a.*, m.AdminID FROM Aircraft a JOIN manageAircraft m ON a.AircraftID = m.AircraftID";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlDataAdapter object with the query and the connection
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Create a DataTable object to store the result of the query
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the result of the query
                    adapter.Fill(dataTable);

                    // Set the DataSource property of the DataGridView to the DataTable
                    dataGridViewMain.DataSource = dataTable;
                }
            }
        }

        private void showClassBtn_Click(object sender, EventArgs e)
        {

            // Create a connection string with the credentials to access the database
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";

            // Create a SQL query to join the Aircraft and AircraftClass tables
            string query = "SELECT a.aircraftID, a.model, a.color, a.capacity, ac.class FROM Aircraft a INNER JOIN Aircraft_Class ac ON a.aircraftID = ac.aircraftID";

            // Create a SqlConnection object and open the connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SqlDataAdapter object with the query and the connection
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    // Create a DataTable object to store the result of the query
                    DataTable dataTable = new DataTable();

                    // Fill the DataTable with the result of the query
                    adapter.Fill(dataTable);

                    // Set the DataSource property of the DataGridView to the DataTable
                    dataGridViewMain.DataSource = dataTable;
                }
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (customerIDHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Customer ID");
                return;
            }

            if (FlightIDHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Flight ID");
                return;
            }

            if (priceHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter a price");
                return;
            }

            if (classDrop.SelectedIndex == -1)
            {
                MessageBox.Show("Please Choose A Class");
                return;
            }

            if (seatNumber.Value == 0)
            {
                MessageBox.Show("Please Choose A Seat Number");
                return;
            }

            if (statusDrop.SelectedIndex == -1)
            {
                MessageBox.Show("Please Choose A State");
                return;
            }
            string selectedType;
            if (windowRadio.Checked)
            {
                selectedType = "Window";
            }
            else
            {
                selectedType = "Aisle";
            }

            ReservationDAO.updateReservation(int.Parse(customerIDHolder.textBox.Text), int.Parse(FlightIDHolder.textBox.Text), (int)seatNumber.Value, new Reservation
            {
                FlightID = int.Parse(FlightIDHolder.textBox.Text),
                CustomerID = int.Parse(customerIDHolder.textBox.Text),
                seatNumber = (int)seatNumber.Value,
                Price = int.Parse(priceHolder.textBox.Text),
                Class = classDrop.Text,
                State = statusDrop.Text,
                Type = selectedType
            });

            MessageBox.Show("Reservation Updated!");
            dataGridReservations.DataSource = ReservationDAO.getAllReservations();
            customerIDHolder.textBox.Text = FlightIDHolder.textBox.Text = priceHolder.textBox.Text = String.Empty;
        }

        private void Reservations_Click(object sender, EventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (customerIDHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Customer ID");
                return;
            }


            if (FlightIDHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Flight ID");
                return;
            }


            if (seatNumber.Value == 0)
            {
                MessageBox.Show("Please Choose A Seat Number");
                return;
            }

            ReservationDAO.deleteReservation(int.Parse(customerIDHolder.textBox.Text), int.Parse(FlightIDHolder.textBox.Text), (int)seatNumber.Value);
            MessageBox.Show("Reservation Has Been Deleted");
            dataGridReservations.DataSource = ReservationDAO.getAllReservations();
            customerIDHolder.textBox.Text = FlightIDHolder.textBox.Text = priceHolder.textBox.Text = String.Empty;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new AdminDetails().ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void aircraftIdHolder_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void sourceHolder_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void destinationHolder_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void stateholder_Load(object sender, EventArgs e)
        {

        }

        private void seatsHolder_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void datePickArriveTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datePickArriveDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void datepickDepartureTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void datePickDepartureDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void source_dest_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {
            string connectionString = "Server=DESKTOP-T4VTD3E;Database=DedSecDataBase;Trusted_Connection=True;";
            string query = @"SELECT f.FlightID, f.source, f.destination, f.arrivalDate, f.arrivalTime, f.depatureDate, f.depatureTime, COUNT(r.CustomerID) AS NumberOfReservations
                     FROM Flight f
                     LEFT JOIN Reservation r ON f.FlightID = r.FlightID
                     GROUP BY f.FlightID, f.source, f.destination, f.arrivalDate, f.arrivalTime, f.depatureDate, f.depatureTime";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);

                        // Display the combined flight and reservation data in a DataGridView
                        dvg_Report.DataSource = dataSet.Tables[0];
                        // Set the default cell style to increase the cell height
                        dvg_Report.DefaultCellStyle = new DataGridViewCellStyle()
                        {
                            WrapMode = DataGridViewTriState.True,
                            Padding = new Padding(3, 5, 3, 5),
                            Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular),
                            Alignment = DataGridViewContentAlignment.MiddleLeft,
                            BackColor = Color.White,
                            ForeColor = Color.Black,
                            SelectionBackColor = Color.LightBlue,
                            SelectionForeColor = Color.Black,
                            NullValue = "",
                            Format = ""
                        };
                        dvg_Report.RowTemplate.Height = 40;
                    }
                }
            }
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
