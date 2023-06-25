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

namespace FlightReservationGUI
{
    public partial class CustomerDetails : Form
    {
        public CustomerDetails()
        {
            InitializeComponent();
            adminDetailsID.textBox.Text = Controller.activeCustomer.CustomerID.ToString();
            adminDetailsEmail.textBox.Text = Controller.activeCustomer.email;
            adminDetailsGender.textBox.Text = Controller.activeCustomer.gender;
            adminDetailsDate.Value = Controller.activeCustomer.DataOfBirth;
            adminDetailsFirst.textBox.Text = Controller.activeCustomer.fname;
            adminDetailsLast.textBox.Text = Controller.activeCustomer.lname;
            adminDetailsPassword.textBox.Text = Controller.activeCustomer.password;
        }

        private void adminDetailsConfirm_Click(object sender, EventArgs e)
        {
            CustomerDAO.updateCustomer(new FlightReservationSystem.Entities.Customer
            {
                CustomerID = Controller.activeCustomer.CustomerID,
                fname = adminDetailsFirst.textBox.Text,
                lname = adminDetailsLast.textBox.Text,
                DataOfBirth = adminDetailsDate.Value,
                email = adminDetailsEmail.textBox.Text,
                gender = Controller.activeCustomer.gender,
                password = adminDetailsPassword.textBox.Text,
            });
            Controller.activeCustomer = CustomerDAO.getCustomer(adminDetailsEmail.textBox.Text);
            MessageBox.Show("Details Updated");
            this.Close();
        }

        private void adminDetailsID_Load(object sender, EventArgs e)
        {

        }
    }
}
