using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace Cari_ve_Stok_Takip
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        string description = "Kullanıcı adınız ve şifreniz ile sisteme giriş yapabilirsiniz. " +
            "Eğer şifrenizi unuttuysanız güvenlik kodunuz ile öğrenebilirsiniz veya bir admine başvurabilirsiniz." +
            "Güvenlik kodunuzu kimseye vermeyiniz.";
        FormsCommonFeatures fcf = new FormsCommonFeatures();
        bool moving = false;
        Point point = new Point(0, 0);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            point = new Point(e.X, e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving == true)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.point.X, p.Y - this.point.Y);
            }
        }


        private void btn_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void link_HowToUse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fcf.HowToUseOpen(description);
        }

        private void link_AdminLoginFormOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formlar.AdminLogin adminlogin = new Formlar.AdminLogin();
            adminlogin.Show();
            this.Hide();
        }

        private void link_UserForgotPWOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Formlar.UserForgotPassword ufp = new Formlar.UserForgotPassword();
            ufp.Show();

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string login = BLLUser.BLLLogin(textBox1.Text, textBox2.Text);
            if (login == "NullError")
            {
                MessageBox.Show("Kullanıcı adı veya şifre boş bırakılamaz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            else if (login == "Failed")
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre tekrar deneyiniz.");
                textBox1.Clear();
                textBox2.Clear();
            }
            else
            {
                Formlar.User_Formları.UserMain usermain = new Formlar.User_Formları.UserMain();
                usermain.Show();
                this.Hide();
            }
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
