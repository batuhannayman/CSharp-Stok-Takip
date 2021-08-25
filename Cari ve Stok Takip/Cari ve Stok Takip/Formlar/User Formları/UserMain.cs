using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntitiesLayer;

namespace Cari_ve_Stok_Takip.Formlar.User_Formları
{
    public partial class UserMain : Form
    {
        public UserMain()
        {
            InitializeComponent();
        }

        string description = "İşlem yapacağınız alanı seçiniz. Yetkinizin izin vermediği alanlara giremezsiniz.";
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

        private void UserMain_Load_1(object sender, EventArgs e)
        {
            if (EntityUser.userPermission == 1)
            {
                btn_Cari.Enabled = false;
                button1.Enabled = false;
            }
            else if (EntityUser.userPermission == 2)
            {
                btn_Cari.Enabled = false;
            }
            else if (EntityUser.userPermission == 3)
            {
                button1.Enabled = false;
            }
        }

        private void btn_Cari_Click(object sender, EventArgs e)
        {
            Cariler cariler = new Cariler();
            cariler.Show();
            this.Hide();
        }

        private void btn_Product_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CarilerSatıcılar cs = new CarilerSatıcılar();
            cs.Show();
            this.Hide();
        }
    }
}
