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

namespace Cari_ve_Stok_Takip.Formlar
{
    public partial class UserForgotPassword : Form
    {
        public UserForgotPassword()
        {
            InitializeComponent();
        }
        string description = "Şifrenizi görmek için gereken tüm alanları eksiksiz doldurmanız gerekir. " +
            "Güvenlik kodunuzu bilmiyorsanız veya bilgilerinizi değiştirmek istiyorsanız bir admine başvurmalısınız.";
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
            this.Hide();
        }

        private void link_HowToUse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fcf.HowToUseOpen(description);
        }

        private void btn_ShowPassword_Click(object sender, EventArgs e)
        {
            string password = BLLUser.BLLForgotPassword(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (password == "NullError")
            {
                MessageBox.Show("Alanlar boş bırakılamaz.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else if (password == "FoundError")
            {
                MessageBox.Show("Personel bulunamadı.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("Şifreniz:" + password);
            }
        }

    }
}
