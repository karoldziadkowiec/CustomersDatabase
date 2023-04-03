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
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

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
            ListingPage listingpage = new ListingPage();
            listingpage.Show();
            this.Hide();
        }
    }
}
