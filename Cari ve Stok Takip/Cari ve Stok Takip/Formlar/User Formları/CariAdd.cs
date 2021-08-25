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

namespace Cari_ve_Stok_Takip.Formlar.User_Formları
{
    public partial class CariAdd : Form
    {
        public CariAdd()
        {
            InitializeComponent();
        }

        string description = "Cari oluşturmak için tüm alanları eksiksiz doldurmalısınız.";
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
            string tc = textBox3.Text;
            string adress = textBox4.Text;
            string phone = textBox5.Text;
            string postcode = textBox6.Text;
            string mail = textBox7.Text;
            string aors = comboBox1.Text;


            string add = BLLCari.BLLCariAdd(name, surname, tc, adress, phone, postcode, mail, aors);

            if (add == "AlreadyHave")
            {
                MessageBox.Show("Bu TC ile başka bir kayıt var.");
            }
            else if (add == "NullError")
            {
                MessageBox.Show("Alanlar boş bırakılamaz");
            }
            else if (add == "AorSError")
            {
                MessageBox.Show("Geçerli bir alıcı/satıcı değeri seçiniz.");
            }
            else if (add == "Success")
            {
                MessageBox.Show("Başarıyla oluşturuldu.");
                this.Hide();
            }
        }
    }
}
