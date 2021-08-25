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
    public partial class StokAdd : Form
    {
        public StokAdd()
        {
            InitializeComponent();
        }

        string description = "Stok eklemek için ürünü seçip gerekli alanları doldurmanız gerekmektedir.";
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

        private void StokAdd_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLProduct.GetRows();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLProduct.BLLSearchWithBrand(textBox3.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLProduct.BLLSearchWithType(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLProduct.BLLSearchWithProductNo(textBox4.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int cari = cariID;
                int piece = Convert.ToInt32(textBox1.Text);
                int price = Convert.ToInt32(textBox5.Text);
                string description = textBox6.Text;
                DateTime date = dateTimePicker1.Value;

                int selected = dataGridView1.SelectedCells[0].RowIndex;
                int productID = Convert.ToInt32(dataGridView1.Rows[selected].Cells[0].Value.ToString());

                string add = BLLCariSatıcılar.BLLStokAdd(cari, productID, piece, price, date, description);

                if (add == "Success")
                {
                    MessageBox.Show("Başarıyla gerçekleşti.");
                    this.Hide();
                }
                else if (add == "PieceError")
                {
                    MessageBox.Show("Stokta yeterli ürün yok satış gerçekleşemiyor.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ürün seçtiğinizden, adedi ve fiyatı doğru giriğinizden emin olun.");
            }
        }
    }
}
