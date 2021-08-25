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

namespace Cari_ve_Stok_Takip.Formlar
{
    public partial class AdminUsers : Form
    {
        public AdminUsers()
        {
            InitializeComponent();
        }

        string description = "İsim ile personel aratabilir, yeni personel ekleyebilir, yeni admin ekleyebilirsiniz. " +
            "Seçtiğiniz personelin bilgilerini düzenleyebilir veya personeli silebilirsiniz.";
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
            this.Close();
        }

        private void link_HowToUse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fcf.HowToUseOpen(description);
        }

        private void ShowRows()
        {
            dataGridView1.DataSource = BLLAdmin.BLLShowRows();
        }

        private void AdminUsers_Load(object sender, EventArgs e)
        {
            ShowRows();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ShowRows();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = BLLAdmin.BLLSouce(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminNewUser anu = new AdminNewUser();
            anu.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminNewAdmin ana = new AdminNewAdmin();
            ana.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[selected].Cells[0].Value.ToString());

            DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Personel silme", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                BLLAdmin.BLLDelete(id);
                ShowRows();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int selected = dataGridView1.SelectedCells[0].RowIndex;
            int id = Convert.ToInt32(dataGridView1.Rows[selected].Cells[0].Value.ToString());
            AdminUserUpdate.id = id;

            AdminUserUpdate auu = new AdminUserUpdate();
            auu.Show();
        }
    }
}
