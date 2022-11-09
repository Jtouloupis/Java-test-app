using Npgsql;
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

namespace EkpaideytikoLogismiko
{
    public partial class SignUpForm : Form
    {
        private NpgsqlConnection cnn;

        private AppForm appForm;
        public SignUpForm(AppForm app)
        {
            InitializeComponent();
            appForm = app;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Log In:\n" 
                + "Enter your credentials correctly to log in to the application.\n" 
                + "\n" 
                + "-------------------------\n"
                + "\n"
                + "Sign Up:\n" 
                + "Enter an available username and a valid password to create a profile for the application.\n"
                + "\n"
                + "-------------------------\n"
                + "\n"
                + "The usesrname should already exist.\n" 
                + "The password should contain at least 6 figures.","Help");
        }

        private void loginBTN_Click(object sender, EventArgs e)
        {
            //check if username and password are empty
            if (!String.IsNullOrEmpty(usernameTXTB.Text) && !String.IsNullOrEmpty(passwordTXTB.Text))
            {
                cnn.Open();

                NpgsqlCommand command;
                NpgsqlDataReader dataReader;
                String sql;

                sql = "Select * from accounts where Username = @username;";

                command = new NpgsqlCommand(sql, cnn);
                command.Parameters.AddWithValue("@username", usernameTXTB.Text);

                dataReader = command.ExecuteReader();

                //log in user if password is correct
                bool logged;
                if (dataReader.Read())
                {
                    if (dataReader.GetValue(4).ToString() == passwordTXTB.Text)
                    {
                        logged = true;
                    }
                    else
                    {
                        logged = false;
                    }
                }
                else
                {
                    logged = false;

                }



                if (logged)
                {
                    User user = new User(dataReader.GetInt32(0),dataReader.GetString(1), dataReader.GetString(2), dataReader.GetString(3));
                    appForm.userLoggedIn(user);
                    Close();
                }
                else
                {
                    MessageBox.Show("Username or Password is invalid!");
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();
            }
            else
            {
                MessageBox.Show("Username and Password cannot be empty!");
            }

        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            cnn = Program.GetConnection();
        }

        private void SignUpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void signUpBTN_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(firstnameTXTB.Text) && !String.IsNullOrEmpty(lastnameTXTB.Text) && !String.IsNullOrEmpty(usernameRTXTB.Text) && !String.IsNullOrEmpty(passwordRTXTB.Text))
            {

                NpgsqlCommand command;
                NpgsqlDataReader dataReader;
                String sql;

                sql = @"select * from accounts where Username = @username;";
                command = new NpgsqlCommand(sql, cnn);

                command.Parameters.AddWithValue("@username", usernameRTXTB.Text);

                cnn.Open();

                dataReader = command.ExecuteReader();

                command.Parameters.Clear();

                bool exists;
                if (dataReader.Read())
                {
                    exists = true;
                }
                else
                {
                    exists = false;

                }

                cnn.Close();

                dataReader.Close();
                command.Dispose();
                if (!exists)
                {
                    using (cnn)
                    {
                        String query = @"INSERT INTO accounts (Firstname,Lastname,Username,Password) VALUES (@firstname, @lastname, @usernameR, @passwordR) returning id";
                         
                        using (command = new NpgsqlCommand(query, cnn))
                        {
                            try
                            {
                                command.Parameters.AddWithValue("@firstname", firstnameTXTB.Text);
                                command.Parameters.AddWithValue("@lastname", lastnameTXTB.Text);
                                command.Parameters.AddWithValue("@usernameR", usernameRTXTB.Text);
                                command.Parameters.AddWithValue("@passwordR", passwordRTXTB.Text);

                                cnn.Open();

                                int id = (int) command.ExecuteScalar();
                                cnn.Close();


                                command.Parameters.Clear();

                                command.Dispose();


                                User user = new User(id, firstnameTXTB.Text, lastnameTXTB.Text, usernameRTXTB.Text);
                                appForm.userLoggedIn(user);

                                Close();
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Username already in use!");

                }
            }
            else
            {
                MessageBox.Show("Please fill all the fields!");

            }
        }
    }
}
