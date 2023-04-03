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

namespace CustomersDatabase
{
    public partial class ListingPage : Form
    {
        public ListingPage()
        {
            InitializeComponent();
            string connectionString = "server=localhost;database=customersdatabase;username=root;password=;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmdDataBase = new MySqlCommand("SELECT id AS 'ID', name AS 'NAME', surname AS 'SURNAME', phone AS 'PHONE NUMBER', address AS 'ADDRESS', birthday AS 'BIRTHDAY', creation_date AS 'CREATION DATE' FROM customers ORDER BY id ASC", connection);
            try
            {
                //DATAGRIDVIEW
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmdDataBase);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
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

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
