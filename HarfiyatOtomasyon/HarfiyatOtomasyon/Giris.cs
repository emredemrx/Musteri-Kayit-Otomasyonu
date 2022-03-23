using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using HarfiyatOtomasyon.Controller;

namespace HarfiyatOtomasyon
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginMethod();
        }
        private void LoginMethod()
        {
            string name = textBox1.Text;
            string password = textBox2.Text;
            Login login = new Login();
            //
            // Not
            //
            //veri tabanı kaydı yoksa ilk giriş için daha sonrasında kullanıcı kaydı ekleyeceğim 
                name = "admin";
                password = "admin";
            
            //
            // 
            //
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adi ve/veya şifre giriniz...");
            }
            else
            {
                //object a = login.loginControl(name, password);
                //a != null
                // kullanıcı veri kaydından sonra bu sorgular eklenecekdir

                if (true)
                {
                    
                    Otomasyon frm = new Otomasyon();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Lütfen kullanıcı adi ve Şifrenizi doğru giriniz...");
                }
            }
        }
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoginMethod();
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) LoginMethod();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Şuan Sistemde kayıt olmadığı için GİRİŞ butonuna tıklayarak giriş yapabilirsiniz.");
        }
    }
}
