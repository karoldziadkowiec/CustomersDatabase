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

namespace CustomersDatabase
{
    public partial class DeletingPage : Form
    {
        public DeletingPage()
        {
            InitializeComponent();
            string connectionString = "server=localhost;database=customersdatabase;username=root;password=;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand cmdDataBase = new MySqlCommand("SELECT id AS 'ID', name AS 'NAME', surname AS 'SURNAME', birthday AS 'BIRTHDAY', creation_date AS 'CREATION DATE' FROM customers ORDER BY id ASC", connection);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string selectedValue = row.Cells[0].Value.ToString();
            textBox1.Text = "";
            textBox1.Text = selectedValue;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            try
            {
                string connectionString = "server=localhost;database=customersdatabase;username=root;password=;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string sqlQuery = "DELETE FROM customers WHERE id = @id";
                    MySqlCommand command = new MySqlCommand(sqlQuery, conn);
                    command.Parameters.AddWithValue("@id", id);
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer successfully removed.", "CustomersDatabase");
                    }
                    else
                    {
                        MessageBox.Show("Customer not found.", "CustomersDatabase");
                    }

                    conn.Close();
                    DeletingPage deletingpage = new DeletingPage();
                    deletingpage.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Error removing customer.", "CustomersDatabase");
            }
        }
    }
}
