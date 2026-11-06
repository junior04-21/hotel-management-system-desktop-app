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

namespace HM_Project
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameLbl_Click(object sender, EventArgs e)
        {

        }

        private void loginForm_Load(object sender, EventArgs e)
        {

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            registerationForm registerationForm = new registerationForm();
            registerationForm.Show();
            this.Hide();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            string username = txtboxUsername.Text;
            string password = txtboxPassword.Text;

            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\denni\\Downloads\\HM Project\\HM Project\\Database1.mdf\";Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = " Select COUNT(*) FROM loginTbl WHERE Username=@username AND Password=@password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);


                conn.Open();
                int result = (int)cmd.ExecuteScalar();

                if (result > 0)
                {
                    homeForm homeForm = new homeForm();
                    homeForm.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK);
                }
            }
        }


        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                txtboxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtboxPassword.UseSystemPasswordChar = true;
            }

        }

        private void forgotpassLinklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            resetPasswordForm resetForm = new resetPasswordForm();
            resetForm.Show();
            this.Hide();
        }
    }
}
