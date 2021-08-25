using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cari_ve_Stok_Takip
{
    public class FormsCommonFeatures
    {
        public void HowToUseOpen(string description)
        {
            Formlar.HowToUse htu = new Formlar.HowToUse();
            htu.description = description;
            htu.Show();
        }
    }
}
