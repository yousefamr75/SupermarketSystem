using Super_Market.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market.Secreen.Products
{
    public partial class Productlist : Form

    {
        po5Entities1 db = new po5Entities1();
        
        int id;
        Super_Market.db.product result;

        public Productlist()
        {
            InitializeComponent();
            dataGridView1.DataSource = db.products.OrderBy(x=>x.Price).ToList();
           
          
        }

        private void Productlist_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'po5DataSet1.Catagory' table. You can move, or remove it, as needed.
            this.catagoryTableAdapter.Fill(this.po5DataSet1.Catagory);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textName.Text == "")
            {
                dataGridView1.DataSource = db.products.Where(x => x.Name.Contains(textName.Text)).ToList();
            }
            else
                dataGridView1.DataSource = db.products.Where(x => x.Code == textqur.Text && x.Name.Contains(textName.Text)).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.products.ToList();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {


            try
            {

                id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                result = db.products.SingleOrDefault(x => x.id == id);

                textqurr.Text = result.Code;
                textName2.Text = result.Name;
                textPrice.Text = result.Price.ToString();
                textqua.Text = result.Quantity.ToString();
                textNotes.Text = result.Notes;
               
                comboBox1.SelectedValue=result.Catagoryid;
            }
            catch { }
        }





        private void button6_Click(object sender, EventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            var result = db.products.SingleOrDefault(x => x.id == id);
            result.Name = textName2.Text;
            result.Code = textqurr.Text;
            result.Price = decimal.Parse(textPrice.Text);
            result.Quantity = int.Parse(textqua.Text);
            result.Notes = textNotes.Text;
            result.Catagoryid= int.Parse(comboBox1.SelectedValue.ToString());

            db.SaveChanges();
            MessageBox.Show("تم التعديل بنجاح");
            
            dataGridView1.DataSource = db.products.ToList();



        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف", "تاكيد الحذف ", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                result = db.products.Find(id);
                db.products.Remove(result);
                db.SaveChanges();
                MessageBox.Show("تم الحذف");
                dataGridView1.DataSource = db.products.ToList();
                textName.Text = "";
                textPrice.Text="";
                textNotes.Text = "";
                textqurr.Text = "";
                textqua.Text = "";
                textName2.Text = "";
                textqur.Text = "";




            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           Products p= new Products();
            p.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
