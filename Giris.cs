using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OGR_NOT_OTOMASYONU
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            OgrenciDetay ogrenciDetay = new OgrenciDetay();
            ogrenciDetay.Numara = mtxtNumara.Text;
            ogrenciDetay.Show();
        }

        private void mtxtNumara_TextChanged(object sender, EventArgs e)
        {
            if (mtxtNumara.Text == "2200")
            {
                OgretmenDetay fr = new OgretmenDetay();
                fr.Show();
            }
        }
    }
}
