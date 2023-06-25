using FlightReservationSystem.Data_Access;
using FlightReservationSystem.Entities;
using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FlightReservationGUI
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(firstNametxtBox.textBox.Text.Trim() == "")
            {
                MessageBox.Show("First Name Cannot Be Empty");
                return;

            }

            if(lastNameTxtBox.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Last Name Cannot Be Empty");
                return;
            }

            if (firstPhone.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter a phone number");
                return;
            }

            if (email.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Email Cannot be Empty");
                return;
            }

            if(password.textBox.Text.Trim() == "")
            {
                MessageBox.Show("Password Cannot be Empty");
            }

            

            int age = CalculateAge(dateTimePicker);
            if (age < 18)
            {
                MessageBox.Show("To create an account you need to be 18 or older");
                return;
            }

            if (Controller.adminLog)
            {
                string gender;
                if (maleRadioButton.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                Admin admin = new Admin
                {
                    AdminID = AdminDAO.getAdmins().Count + 1,
                    fname = firstNametxtBox.textBox.Text,
                    lname = lastNameTxtBox.textBox.Text,
                    email = email.textBox.Text,
                    gendar = gender,
                    PASSWORD = password.textBox.Text,
                    dateOfBirth = dateTimePicker.Value,
                    age = age
                };

                AdminDAO.insertAdmin(admin);
                AdminPhoneDAO.addAdminPhone(admin.AdminID, firstPhone.textBox.Text);
                if (secondPhone.textBox.Text.Trim() != "")
                {
                    AdminPhoneDAO.addAdminPhone(admin.AdminID,secondPhone.textBox.Text);
                }
                Controller.activeAdmin = admin;
                this.Visible = false;
                new AdminHome().ShowDialog();
                this.Close();
            }
            else
            {
                string gender;
                if (maleRadioButton.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                Customer customer = new Customer
                {
                    CustomerID = CustomerDAO.getCustomers().Count + 1,
                    fname = firstNametxtBox.textBox.Text,
                    lname = lastNameTxtBox.textBox.Text,
                    email = email.textBox.Text,
                    gender = gender,
                    password = password.textBox.Text,
                    DataOfBirth = dateTimePicker.Value
                };
                Controller.activeCustomer = customer;
                CustomerDAO.insertCustomer(customer);
                CustomerPhoneDAO.addCustomerPhone(customer.CustomerID, firstPhone.textBox.Text);
                if(secondPhone.textBox.Text.Trim() != "")
                {
                    CustomerPhoneDAO.addCustomerPhone(customer.CustomerID, secondPhone.textBox.Text); 
                }
                this.Visible = false;
                new CustomerHome().ShowDialog();
                this.Close();
            }
        }

        private int CalculateAge(DateTimePicker dateTimePicker)
        {
            DateTime currentDate = DateTime.Now;
            DateTime birthDate = dateTimePicker.Value;

            int age = currentDate.Year - birthDate.Year;

            // Check if the birth date has occurred this year
            if (birthDate.Date > currentDate.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        private void hopeRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void firstNametxtBox_Load(object sender, EventArgs e)
        {

        }

        private void firstNametxtBox_Validating(object sender, CancelEventArgs e)
        {

       

        }
        private void lastNametxtBox_Validating(object sender, CancelEventArgs e)
        {


        }

        private void emailtxtBox_Validating(object sender, CancelEventArgs e)
        {

         

        }
        private void passwordtxtBox_Validating(object sender, CancelEventArgs e)
        {

            

        }

        private void firstPhone_Validating(object sender, CancelEventArgs e)
        {

           
        }

        private void lastNameTxtBox_Load(object sender, EventArgs e)
        {

        }

        private void cyberTextBox1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void secondPhone_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            new home().ShowDialog();
            this.Close();
        }
    }
}
