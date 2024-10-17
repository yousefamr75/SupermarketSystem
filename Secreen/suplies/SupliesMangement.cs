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

namespace Super_Market.Secreen.suplies
{
    public partial class SupliesMangement : Form
    {
        po5Entities1 db = new po5Entities1();
        string imagepath = "";
        int id;
        Supplier result;
        public SupliesMangement()
        {
            InitializeComponent();
            dataGridView2.DataSource = db.Suppliers.ToList();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textname2.Text == "")
            {
                dataGridView2.DataSource = db.Suppliers.Where(x => x.Phone.Contains(textphone2.Text)).ToList();
            }
            else
                dataGridView2.DataSource = db.Suppliers.Where(x => x.Phone.Contains(textphone2.Text) && x.Name.Contains(textname2.Text)).ToList();
        
    }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                result = db.Suppliers.SingleOrDefault(x => x.id == id);

                textname.Text = result.Name;
                textphone.Text = result.Phone;
                textadd.Text = result.Address;
                textmail.Text = result.Email;
                textcom.Text = result.Company;
                textnotes.Text = result.Notes;
                
            }
            catch { }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("اضافه مورد جديد", "هل تريد اضافه مورد جديد ", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                if (textname.Text == "" || textphone.Text == "")
                {
                    MessageBox.Show("برجاء اكمال البيانات المطلوبه اولا");
                }
                else if (db.Suppliers.Where(x =>x.Phone==textphone.Text).Count() > 0)
                {
                    MessageBox.Show("هذا المورد موجود مسبقا ");
                }



                else
                {
                   Supplier c= new Supplier();
                    c.Phone = textphone.Text;
                    c.Name = textname.Text;
                    c.Address = textadd.Text;
                    c.Email = textmail.Text;
                    c.Notes = textnotes.Text;
                    c.Company = textcom.Text;
                  


                    db.Suppliers.Add(c);
                    db.SaveChanges();

                    MessageBox.Show("تم حفظ بيانات العميل بنجاح");
                    
                    textphone.Text = "";
                    textname.Text = "";
                    textnotes.Text = "";
                    textadd.Text = "";
                    textcom.Text = "";
                    textmail.Text = "";
                    
                    
                    dataGridView2.DataSource = db.Suppliers.ToList();

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد التعديل", "تاكيد التعديل ", MessageBoxButtons.YesNo);
             if (db.Suppliers.Where(x => x.Phone == textphone.Text && x.id!=id).Count() > 0)
            {
                MessageBox.Show("هذاالمورد موجود مسبقا ");
                return;
            }
            if (r == DialogResult.Yes)
            {
                id = int.Parse(dataGridView2.CurrentRow.Cells[0].Value.ToString());
                var result = db.Suppliers.SingleOrDefault(x => x.id == id);
                result.Name = textname.Text;
                result.Phone = textphone.Text;
                result.Address = textadd.Text;
                result.Company = textcom.Text;
                result.Notes = textnotes.Text;
                result.Email = textmail.Text;
                
                db.SaveChanges();
                MessageBox.Show("تم التعديل بنجاح");

                if (imagepath != "")
                {


                    string newpath = Environment.CurrentDirectory + "\\Suppliers\\" + result.id + "Suppliers.jpg";
                    File.Copy(imagepath, newpath, true);
                    result.Image = imagepath;
                    db.SaveChanges();
                }
                dataGridView2.DataSource = db.Suppliers.ToList();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("هل تريد الحذف", "تاكيد الحذف ", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                var result = db.Suppliers.Find(id);
                db.Suppliers.Remove(result);
                db.SaveChanges();
                dataGridView2.DataSource = db.Suppliers.ToList();
                MessageBox.Show("تم الحذف");
                textadd.Text = "";
                textcom.Text = "";
                textmail.Text = "";
                textname.Text = "";
                textname2.Text = "";
                textnotes.Text = "";
                textphone.Text = "";
                textphone2.Text = "";

               



            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = db.Suppliers.ToList();

        }
    }
}
    
    
