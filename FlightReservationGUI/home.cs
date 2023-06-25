using FlightReservationSystem.Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace FlightReservationGUI
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void nightHeaderLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (foreverToggle2.Checked)
            {
                Controller.adminLog = true;
                Controller.customerLog = false;
            }
            else
            {
                Controller.adminLog = false;
                Controller.customerLog = true;
            }


            if (emailHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter An Email");
                return;
            }

            if (passwordHolder.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter A Password");
                return;
            }


            if (Controller.adminLog)
            {
                if (AdminDAO.ValidateCredentials(emailHolder.textBox.Text, passwordHolder.textBox.Text))
                {
                    Controller.loggedAdmin = true;
                    Controller.loggedCustomer = false;
                    Controller.activeAdmin = AdminDAO.getAdmin(emailHolder.textBox.Text);
                    Controller.activeCustomer = null;
                    this.Visible = false;
                    new AdminHome().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }
            }else if (Controller.customerLog)
            {
                if (CustomerDAO.ValidateCredentials(emailHolder.textBox.Text, passwordHolder.textBox.Text))
                {
                    Controller.loggedCustomer = true;
                    Controller.loggedAdmin = false;
                    Controller.activeAdmin = null;
                    Controller.activeCustomer = CustomerDAO.getCustomer(emailHolder.textBox.Text);
                    this.Visible = false;
                    new CustomerHome().ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (foreverToggle2.Checked)
            {
                Controller.adminLog = true;
                Controller.customerLog = false;
            }
            else
            {
                Controller.adminLog = false;
                Controller.customerLog = true;
            }
            this.Visible = false;
            SignUp signUp = new SignUp(); // Create a new instance of Form2
            signUp.ShowDialog(); // Show the new form as a modal dialog
            this.Close(); // Hide the current form
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toggleEdit1_ToggledChanged()
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void foreverToggle2_CheckedChanged(object sender)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
