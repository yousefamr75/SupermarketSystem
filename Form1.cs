using Super_Market.db;
using Super_Market.Secreen.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market
{
    public partial class Form1 : Form
    {
        po5Entities1 db = new po5Entities1();

        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textuser.Text == "" || textpassword.Text == "")
            {
                MessageBox.Show("برجاء ادخال اسم المستخدم و كلمه سر");
            }
            else
            {
                var result = db.Users.Where(x => x.UserName == textuser.Text && x.Password == textpassword.Text).ToList();
               // MessageBox.Show(result.Count().ToString());
                if (result.Count() > 0)
                {
                    this.Close();
                    Thread th = new Thread(openform);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();

                }
                else
                {
                    MessageBox.Show("اسم المستخدم أو كلمة المرور غير صالحة"  );
                }
                textuser.Text = "";
                textpassword.Text = "";
            }
        }
        void openform()
        {
            Application.Run(new mainfram());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        NewUser newUser = new NewUser();
        newUser.Show();
          
       }
        
        }
    
    
      }