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
    public partial class ProductAdd : Form
    {
        public ProductAdd()
        {
            InitializeComponent();
        }

        string description = "Ürün eklemek için tüm alanları eksiksiz doldurmalısınız.";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string type = textBox2.Text;
            string brand = textBox3.Text;
            string productno = textBox5.Text;
            string description = textBox1.Text;
            DateTime date = dateTimePicker1.Value;

            try
            {
                int piece = Convert.ToInt32(textBox6.Text);
                int price = Convert.ToInt32(textBox7.Text);

                string add = BLLProduct.BLLProductAdd(type, brand, productno, piece, price);

                if (add == "AlreadyHave")
                {
                    MessageBox.Show("Bu ürün kodu daha önce verilmiş.");
                }
                else if (add == "NullError")
                {
                    MessageBox.Show("Alanlar boş bırakılamaz");
                }
                else
                {
                    int productID = Convert.ToInt32(add);
                    string add2 = BLLCariSatıcılar.BLLProductAdd(cariID, productID, piece, price, date, description);
                    if (add2 == "Success")
                    {
                        MessageBox.Show("Başarıyla gerçekleşti.");
                        this.Hide();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hatalı stok veya fiyat girişi. Tekrar deneyin.");
            }
        }

        private void ProductAdd_Load(object sender, EventArgs e)
        {

        }
    }
}
