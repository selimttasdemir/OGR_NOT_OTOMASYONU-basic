using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OGR_NOT_OTOMASYONU
{
    public partial class OgrenciDetay : Form
    {
        public OgrenciDetay()
        {
            InitializeComponent();
        }
        public string Numara;

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELIM-TASDEMIR;Initial Catalog=DBnotKayitSistemi;Integrated Security=True");

        private void OgrenciDetay_Load(object sender, EventArgs e)
        {
            lblNumara.Text = Numara;

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tblDers where ogrnumara = @P1", baglanti);
            komut.Parameters.AddWithValue("@P1", Numara);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                lblS1.Text = dr[4].ToString();
                lblS2.Text = dr[5].ToString();
                lblS3.Text = dr[6].ToString();
                lblOtr.Text = dr[7].ToString();
                if (dr[8].ToString() == "True")
                {
                    lblDurum.Text = "Geçti";
                }
                else
                {
                    lblDurum.Text = "Kaldı";
                }
            }
            baglanti.Close();
        }
    }
}
