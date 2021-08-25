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
    public partial class CariUpdate : Form
    {
        public CariUpdate()
        {
            InitializeComponent();
        }

        string description = "Cari bilgilerini güncellemek için gerekli tüm alanları doldurmalısınız.";
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

        public static int cariID = 0;
        private void CariUpdate_Load(object sender, EventArgs e)
        {
            string[] cari = BLLCari.BLLGetCari(cariID);

            lbl_Name.Text = cari[0];
            lbl_Surname.Text = cari[1];
            lbl_TC.Text = cari[2];
            lbl_Mail.Text = cari[3];
            lbl_Phone.Text = cari[4];
            lbl_PostCode.Text = cari[5];
            lbl_Adress.Text = cari[6];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string update = BLLCari.BLLCariUpdate(cariID, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text);

            if (update == "NullError")
            {
                MessageBox.Show("Alanlar boş bırakılamaz.");
            }
            else if (update == "Success")
            {
                MessageBox.Show("Başarıyla düzenlendi.");
                this.Hide();
            }
        }
    }
}
