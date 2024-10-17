using Super_Market.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market.Secreen.Products
{
    public partial class Products : Form
    {
        po5Entities1 db = new po5Entities1();
       
        public Products()
        {
            InitializeComponent();

        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'po5DataSet.Catagory' table. You can move, or remove it, as needed.
            this.catagoryTableAdapter.Fill(this.po5DataSet.Catagory);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textqur.Text == "" || textName.Text == "" || textPrice.Text == "" )
            {
                MessageBox.Show("برجاء اكمال البيانات المطلوبه اولا");
            }
            else
            {
                Super_Market.db.product product = new Super_Market.db.product();

                product.Code = textqur.Text;
                product.Name = textName.Text;
                int pri, qua;
               int.TryParse(textPrice.Text , out pri);
                int.TryParse(textqua.Text , out qua);

                product.Notes = textqur.Text;
               product.Price = pri;
                product.Quantity = qua;
                product.Catagoryid = int.Parse(comboBox1.SelectedValue.ToString());


                db.products.Add(product);
                db.SaveChanges();
               
                MessageBox.Show("تم حفظ بيانات المنتج بنجاح");
                
                textqur.Text = "";
                textName.Text = "";
                textNotes.Text = "";
                textPrice.Text = "";
                textqua.Text = "";
                

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Productlist p= new Productlist();
            p.Show();
        }
    }
    }

