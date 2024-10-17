using Super_Market.db;
using Super_Market.Secreen.Products;
using Super_Market.Secreen.Products.Customers;
using Super_Market.Secreen.suplies;
using Super_Market.Secreen.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market
{
    public partial class mainfram : Form
    {
        public mainfram()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewUser fr = new NewUser();
            fr.Show();
        }

        private void createProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productlist products = new Productlist();
            products.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Productlist products = new Productlist();
            products.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CustomerManagement s =new CustomerManagement();
            s.Show();
            
       
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
             SupliesMangement s=new  SupliesMangement();
            s.Show();
        }

        private void الموردينToolStripMenuItem_Click(object sender, EventArgs e)
        {
           SupliesMangement supliesMangement = new SupliesMangement();
            supliesMangement.Show();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerManagement customerManagement = new CustomerManagement();
            customerManagement.Show();
        }

        private void managementProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Productlist productList = new Productlist();
            productList.Show();
        }
    }
}
