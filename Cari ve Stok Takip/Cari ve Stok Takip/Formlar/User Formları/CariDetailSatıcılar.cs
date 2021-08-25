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
    public partial class CariDetailSatıcılar : Form
    {
        public CariDetailSatıcılar()
        {
            InitializeComponent();
        }

        public static int cariID = 0;

        string description = "Satış yapabilir, cariyi düzenleyebilir veya ödeme ekleyebilirsiniz. " +
            "Tarihler arası olayları görmek için ise tarih belirleyip ara butonuna basabilirsiniz.";
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

        private void GetRows()
        {
            string[] cari = BLLCariSatıcılar.BLLGetCari(cariID);

            lbl_Name.Text = cari[0];
            lbl_Surname.Text = cari[1];
            lbl_TC.Text = cari[2];
            lbl_Mail.Text = cari[3];
            lbl_Phone.Text = cari[4];
            lbl_PostCode.Text = cari[5];
            textBox1.Text = cari[6];

            dataGridView1.DataSource = BLLCariSatıcılar.BLLGetSales(cariID);
            //--------------------------------------------------------------

            int sum = BLLCariSatıcılar.BLLGetSum(cariID);
            int pay = BLLCariSatıcılar.BLLGetPay(cariID);

            lbl_Toplam.Text = sum.ToString();
            lbl_Odenen.Text = pay.ToString();
            lbl_Kalan.Text = (sum - pay).ToString();
        }

        private void CariDetailSatıcılar_Load(object sender, EventArgs e)
        {
            GetRows();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetRows();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLCariSatıcılar.BLLSearchWithDate(cariID, dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CariUpdate.cariID = 4;
            CariUpdate cu = new CariUpdate();
            cu.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PayAddSatıcılar.cariID = cariID;

            PayAddSatıcılar pas = new PayAddSatıcılar();
            pas.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ProductAdd.cariID = cariID;

            ProductAdd pa = new ProductAdd();
            pa.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            StokAdd.cariID = cariID;

            StokAdd sa = new StokAdd();
            sa.Show();
        }
    }
}
