using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CustomersDatabase
{
    public partial class AddingPage : Form
    {
        public AddingPage()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainPage mainpage = new MainPage();
            mainpage.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditingPage editingpage = new EditingPage();
            editingpage.Show();
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

        private void AddingPage_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            MainPage mainpage = new MainPage();
            mainpage.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String surname = textBox2.Text;
            String id = textBox5.Text;
            String phone = textBox3.Text;
            String address = textBox4.Text;
            String birthday = dateTimePicker1.Text;
            DateTime creation_date = DateTime.Now;
            if (name.Length == 0 || surname.Length == 0 || id.Length == 0 || phone.Length == 0 || address.Length == 0 || birthday.Length == 0)
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
                string connectionString = "server=localhost;database=customersdatabase;username=root;password=;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = "INSERT INTO customers (id, name, surname, phone, address, birthday, creation_date) VALUES (@id, @name, @surname, @phone, @address, @birthday, @creation_date)";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@surname", surname);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@birthday", birthday);
                    command.Parameters.AddWithValue("@creation_date", creation_date);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Coustomer successfully registered.", "CustomersDatabase");
                    conn.Close();
                    ListingPage listingPage = new ListingPage();
                    listingPage.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Registration error. The given id is taken.", "CustomersDatabase");
            }
        }
    }
}
