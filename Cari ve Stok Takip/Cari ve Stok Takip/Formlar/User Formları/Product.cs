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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }

        string description = "Ürün aratmak için gerekli alanları doldurup ara butonuna basabilirsiniz.";
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

        private void GetRows()
        {
            dataGridView1.DataSource = BLLProduct.GetRows();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            GetRows();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetRows();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLProduct.BLLSearchWithType(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLProduct.BLLSearchWithBrand(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLProduct.BLLSearchWithProductNo(textBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
