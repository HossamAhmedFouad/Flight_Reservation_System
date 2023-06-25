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
    public partial class AdminDetails : Form
    {
        public AdminDetails()
        {
            InitializeComponent();
            adminDetailsID.textBox.Text = Controller.activeAdmin.AdminID.ToString();
            adminDetailsEmail.textBox.Text = Controller.activeAdmin.email;
            adminDetailsGender.textBox.Text = Controller.activeAdmin.gendar;
            adminDetailsDate.Value = Controller.activeAdmin.dateOfBirth;
            adminDetailsFirst.textBox.Text = Controller.activeAdmin.fname;
            adminDetailsLast.textBox.Text = Controller.activeAdmin.lname;
            adminDetailsPassword.textBox.Text = Controller.activeAdmin.PASSWORD;
        }

        private void adminDetailsConfirm_Click(object sender, EventArgs e)
        {
            AdminDAO.updateAdmin(new FlightReservationSystem.Entities.Admin
            {
                AdminID = Controller.activeAdmin.AdminID,
                fname = adminDetailsFirst.textBox.Text,
                lname = adminDetailsLast.textBox.Text,
                dateOfBirth = adminDetailsDate.Value,
                email = adminDetailsEmail.textBox.Text,
                gendar = Controller.activeAdmin.gendar,
                PASSWORD = adminDetailsPassword.textBox.Text,
                age = Controller.activeAdmin.age
            });
            Controller.activeAdmin = AdminDAO.getAdmin(adminDetailsEmail.textBox.Text);
            MessageBox.Show("Details Updated");
            this.Close();
        }

        private void adminDetailsID_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void adminDetailsEmail_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void adminDetailsFirst_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void adminDetailsPassword_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void adminDetailsLast_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void adminDetailsDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void adminDetailsGender_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
