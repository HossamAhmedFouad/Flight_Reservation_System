using FlightReservationSystem;
using FlightReservationSystem.Data_Access;
using FlightReservationSystem.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservationGUI
{
    public partial class CustomerHome : Form
    {
        public CustomerHome()
        {
            InitializeComponent();
            dataGridView1.DataSource = FlightDAO.getFlights();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void loadData_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FlightDAO.getFlights();
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
            }
            else if (dateRadio.Checked)
            {
                dataGridView1.DataSource = FlightDAO.getFlightsByDate(dateFilter.Value);
            }
            else if (seatsRadio.Checked)
            {
                dataGridView1.DataSource = FlightDAO.getFlightsByRequiredSeats((int)seatsFilter.Value);
            }
        }

        private void loadData_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FlightDAO.getFlights();
        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {
            dataGridBookReservation.DataSource = ReservationDAO.getAllReservationsByCustomerId(Controller.activeCustomer.CustomerID);
            customerIDHolder.textBox.Text = Controller.activeCustomer.CustomerID.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridBookReservation.DataSource = ReservationDAO.getAllReservationsByCustomerId(Controller.activeCustomer.CustomerID);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridBookReservation.DataSource = FlightDAO.getFlights();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(srcFilterHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Source");
                return;
            }

            if(destFilterHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Destination");
                return;
            }
            dataGridBookReservation.DataSource = FlightDAO.ReservationFlightFilter(srcFilterHolder.textBox.Text, destFilterHolder.textBox.Text, dateTimeFilterHolder.Value);
            
        }

        private void button2_Click(object sender, EventArgs e)
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

            string selectedType;
            if (windowRadio.Checked)
            {
                selectedType = "Window";
            }
            else
            {
                selectedType = "Aisle";
            }

            ReservationDAO.insertReservation(new Reservation
            {
                FlightID = int.Parse(FlightIDHolder.textBox.Text),
                CustomerID = int.Parse(customerIDHolder.textBox.Text),
                seatNumber = (int)seatNumber.Value,
                Price = int.Parse(priceHolder.textBox.Text),
                Class = classDrop.Text,
                State = "Confirmed",
                Type = selectedType
            });
            MessageBox.Show("Reservation Added");
            dataGridBookReservation.DataSource = ReservationDAO.getAllReservationsByCustomerId(Controller.activeCustomer.CustomerID);
        }

        private void classDrop_SelectedIndexChanged(object sender, EventArgs e)
        {
          
  
            if (classDrop.SelectedItem.ToString() == "First Class")
            {
                priceHolder.textBox.Text = "1000";
            }else if(classDrop.SelectedItem.ToString() == "Business")
            {
                priceHolder.textBox.Text = "600";
            }
            else
            {
                priceHolder.textBox.Text = "200";
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
            dataGridBookReservation.DataSource = ReservationDAO.getAllReservationsByCustomerId(Controller.activeCustomer.CustomerID);
            MessageBox.Show("Reservation Deleted");

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new CustomerDetails().ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Controller.loggedCustomer = false;
            Controller.activeCustomer = null;
            this.Visible = false;
            new home().ShowDialog();
            this.Close();
        }
    }
}
