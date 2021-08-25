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
    public partial class CarilerSatıcılar : Form
    {
        public CarilerSatıcılar()
        {
            InitializeComponent();
        }

        string description = "Cari aramak için gerekli alanı doldurup ara butonuna basabilirsiniz. " +
            "Yeni cari ekleyebilir veya üzerine tıkladığınız carinin detaylarına gidip satış işlemi yapabilirsiniz. " +
            "Bazı durumlarda bilgiler yenilenmez ise yenile butonuna basınız.";
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
            dataGridView1.DataSource = BLLCariSatıcılar.GetRows();
        }

        private void CarilerSatıcılar_Load(object sender, EventArgs e)
        {
            GetRows();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            GetRows();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLCariSatıcılar.BLLSearchWithName(textBox1.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLCariSatıcılar.BLLSearchWithTC(textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLCariSatıcılar.BLLSearchWithPhone(textBox3.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLCariSatıcılar.BLLSearchWithMail(textBox4.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            CariAdd ca = new CariAdd();
            ca.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[selected].Cells[0].Value.ToString());
            CariDetailSatıcılar.cariID = id;

            CariDetailSatıcılar cds = new CariDetailSatıcılar();
            cds.Show();
        }
    }
}
