using Super_Market.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market.Secreen.Users
{
    public partial class NewUser : Form
   

    {
        po5Entities1 db = new po5Entities1 ();
        
        public NewUser()
        {
            InitializeComponent();
            
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
         User u=new User 
            {
                UserName = textuser.Text,
                Password = textpassword.Text,
                

            };
            db.Users.Add(u);
            db.SaveChanges();
           
           



            MessageBox.Show("تم حفظ بيانات المستخدم  ");
            textuser.Text = "";
            textpassword.Text = "";

            db.SaveChanges();
            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
