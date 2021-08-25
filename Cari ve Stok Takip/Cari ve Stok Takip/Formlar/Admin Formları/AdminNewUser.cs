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
    public partial class AdminNewUser : Form
    {
        public AdminNewUser()
        {
            InitializeComponent();
        }

        string description = "Yeni personel oluşturmak için alanları eksiksiz doldurmalısınız. " +
            "Depo sorumluları sadece depodaki ürünlerin stoklarını fiyatlarını ve ürün bilgilerini görebilir yeni ürün ekleyemez, " +
            "ürünü düzenleyemez veya stok ekleyemez. " +
            "Satış yapabilenler sadece alıcılara ve depoya erişebilirler, ürün satışlarını tutabilirler ama ürünlerin bilgilerini değiştiremezler veya yeni ürün ekleyemezler. " +
            "Alış yapabilenler sadece satıcılara ve depoya erişebilirler, yen ürün girebilir, mevcut ürüne stok girebilirler. Ürün satamazlar";
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
            int permission = 1;

            if (comboBox1.Text != "Depo Sorumlusu" && comboBox1.Text != "Satış Yapabilen" && comboBox1.Text != "Alış Yapabilen")
            {
                MessageBox.Show("Yetki seçeneklerden farklı olamaz");
            }
            else
            {
                if (comboBox1.Text == "Depo Sorumlusu")
                {
                    permission = 1;
                }
                else if (comboBox1.Text == "Alış Yapabilen")
                {
                    permission = 2;
                }
                else if(comboBox1.Text == "Satış Yapabilen")
                {
                    permission = 3;
                }

                string update = BLLAdmin.BLLNewUser(name, surname, username, password, permission, securitycode);

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

        private void AdminNewUser_Load(object sender, EventArgs e)
        {

        }
    }
}
