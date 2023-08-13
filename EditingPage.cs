using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CustomersDatabase
{
    public partial class EditingPage : Form
    {
        public EditingPage()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection("datasource=localhost;username=root;password=;database=customersdatabase");
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage mainpage = new MainPage();
            mainpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddingPage addingpage = new AddingPage();
            addingpage.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DeletingPage deletingpage = new DeletingPage();
            deletingpage.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ListingPage listingpage = new ListingPage();
            listingpage.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainPage mainpage = new MainPage();
            mainpage.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String id = textBox5.Text;
            String name = textBox1.Text;
            String surname = textBox2.Text;
            String phone = textBox3.Text;
            String address = textBox4.Text;
            String birthday = dateTimePicker1.Text;
            if (name.Length == 0 || surname.Length == 0 || phone.Length == 0 || address.Length == 0 || birthday.Length == 0)
            {
                MessageBox.Show("Complete the empty fields.", "CustomersDatabase");
                return;
            }
            if (phone.Length != 9)
            {
                MessageBox.Show("The phone number must contain 9 characters.", "CustomersDatabase");
                return;
            }
            try
            {
                conn.Open();
                string sqlQuery = "UPDATE customers SET name='" + name + "', surname='" + surname + "', phone='" + phone + "', address='" + address + "', birthday='" + birthday + "' WHERE id='" + id + "'";
                MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("User data updated successfully.", "CustomersDatabase");
                ListingPage listingpage = new ListingPage();
                listingpage.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Registration error. The given id is taken.", "CustomersDatabase");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string id = textBox5.Text;
            if (id.Length == 0)
            {
                MessageBox.Show("Please enter the user id.", "CustomersDatabase");
                return;
            }

            try
            {
                conn.Open();
                string query = "SELECT * FROM customers WHERE id = '" + id + "'";
                MySqlCommand command = new MySqlCommand(query, conn);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string name = reader.GetString(1);
                        string surname = reader.GetString(2);
                        string birthday = reader.GetString(3);
                        string phone = reader.GetString(4);
                        string address = reader.GetString(5);
                        DateTime date = DateTime.Parse(birthday);

                        textBox1.Text = name;
                        textBox2.Text = surname;
                        textBox3.Text = phone;
                        textBox4.Text = address;
                        dateTimePicker1.Value = date;
                    }
                }
                else
                {
                    MessageBox.Show("Customer not found.", "CustomersDatabase");
                }
            }
            catch
            {
                MessageBox.Show("Error.", "CustomersDatabase");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
