using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cari_ve_Stok_Takip.Formlar
{
    public partial class HowToUse : Form
    {
        public HowToUse()
        {
            InitializeComponent();
        }

        public string description = ""; //Form çağırıldığı yerden getirilecek değer

        private void HowToUse_Load(object sender, EventArgs e)
        {
            textBox1.Text = description; //Gelen değerin ekrana yazdırılması
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); //Kapatma butonu
        }
    }
}
