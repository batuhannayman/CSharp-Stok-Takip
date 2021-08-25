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
    public partial class PayAddSatıcılar : Form
    {
        public PayAddSatıcılar()
        {
            InitializeComponent();
        }

        public static int cariID = 0;
        string description = "Ödeme miktarını ve tarihini giriniz.";

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void link_HowToUse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormsCommonFeatures fcf = new FormsCommonFeatures();
            fcf.HowToUseOpen(description);
        }

        private void PayAddSatıcılar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string add = BLLCariSatıcılar.BLLPayAdd(cariID, Convert.ToInt32(textBox1.Text), dateTimePicker1.Value);

                if (add == "Success")
                {
                    MessageBox.Show("Başarıyla kaydedildi.");
                    this.Hide();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen geçerli bir değer giriniz");
            }
        }
    }
}
