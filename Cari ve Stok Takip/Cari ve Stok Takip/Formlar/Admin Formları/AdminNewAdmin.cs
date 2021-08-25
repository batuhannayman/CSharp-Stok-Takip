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
    public partial class AdminNewAdmin : Form
    {
        public AdminNewAdmin()
        {
            InitializeComponent();
        }

        string description = "Yeni yönetici hesabı için tüm alanları eksiksiz doldurmanız gerekmektedir.";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string username = textBox3.Text;
            string password = textBox4.Text;
            string securitycode = textBox6.Text;

            string update = BLLAdmin.BLLNewAdmin(name, surname, username, password, securitycode);

            if (update == "NullError")
            {
                MessageBox.Show("Alanlar boş bırakılamaz.");
            }
            else if (update == "AlreadyError")
            {
                MessageBox.Show("Bu kullanıcı adı daha önce alınmış. Farklı bir kullanıcı adı deneyin.");
            }
            else if (update == "Success")
            {
                MessageBox.Show("Başarıyla düzenlendi.");
                this.Hide();
            }
        }
    }
}
