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
    public partial class registerationForm : Form
    {
        public registerationForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void registerBtn1_Click(object sender, EventArgs e)
        {
            {

                if (string.IsNullOrWhiteSpace(txtboxUsername.Text) ||
                    string.IsNullOrWhiteSpace(txtboxPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtboxconfirmPassword.Text) ||
                    string.IsNullOrWhiteSpace(txtboxEmail.Text) ||
                    (!rbtnMale.Checked && !rbtnFemale.Checked && !rbtnOther.Checked))
                {
                    MessageBox.Show("Please fill in all required fields.", "Error", MessageBoxButtons.OK);
                    return;
                }


                if (txtboxPassword.Text != txtboxconfirmPassword.Text)
                {
                    MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK);
                    return;
                }

                string gender = "";
                if (rbtnMale.Checked)
                    gender = "Male";
                else if (rbtnFemale.Checked)
                    gender = "Female";
                else if (rbtnOther.Checked)
                    gender = "Other";

                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\denni\Downloads\HM Project\HM Project\Database1.mdf"";Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        string query = @"INSERT INTO loginTbl 
                            (Username, Password, Email, Gender)
                            VALUES 
                            (@username, @password, @emailaddress, @gender)";

                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@username", txtboxUsername.Text);
                        cmd.Parameters.AddWithValue("@password", txtboxPassword.Text);
                        cmd.Parameters.AddWithValue("@emailaddress", txtboxEmail.Text);
                        cmd.Parameters.AddWithValue("@gender", gender);

                        int result = cmd.ExecuteNonQuery();

                        if (result > 0)
                            MessageBox.Show("User registered successfully!", "Registeration Successful!", MessageBoxButtons.OK);
                        else
                            MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }


                }
            }

            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void loginBtn1_Click(object sender, EventArgs e)
        {
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
