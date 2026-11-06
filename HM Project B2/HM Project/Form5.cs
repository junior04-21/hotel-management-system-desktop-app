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
    public partial class resetPasswordForm : Form
    {
        public resetPasswordForm()
        {
            InitializeComponent();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
        
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtNewPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("All fields are required.", "Error", MessageBoxButtons.OK);
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK);
                return;
            }

            string connectionString = @"Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\""C:\\Users\\denni\\Downloads\\HM Project\\HM Project\\Database1.mdf\"";Integrated Security=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    try
                    {
                        conn.Open();
                        string query = "UPDATE loginTbl SET Password = @newPassword WHERE Username = @username";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@newPassword", txtNewPassword.Text);

                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                                MessageBox.Show("Password updated successfully!", "Update Successful!", MessageBoxButtons.OK);
                            else
                                MessageBox.Show("Username not found.", "Update Failed", MessageBoxButtons.OK);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message);
                    }
                }
            }
            loginForm loginForm = new loginForm();
            loginForm.Show();
            this.Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show(
        "Are you sure you want to cancel the password reset and return to the login screen?",
        "Confirm Cancel",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                loginForm loginForm = new loginForm();
                loginForm.Show();
                this.Close();
            }
        }
    }
}
