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
    public partial class OgretmenDetay : Form
    {
        public OgretmenDetay()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=SELIM-TASDEMIR;Initial Catalog=DBnotKayitSistemi;Integrated Security=True");

        private void OgretmenDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBnotKayitSistemiDataSet.tblDers' table. You can move, or remove it, as needed.

            this.tblDersTableAdapter.Fill(this.dBnotKayitSistemiDataSet.tblDers);
            //string kalanOgr = lblKalanSayisi.Text;
            //string gecenOgr = lblGecenSayisi.Text;
            //baglanti.Open();
            //SqlCommand cmd = new SqlCommand("SELECT COUNT (durum) FROM tblDers where DURUM = 'True'", baglanti);



            //cmd.ExecuteNonQuery();


            int gecen = 0, kalan = 0; int i = 0;

            while (dataGridView1.Rows[i].Cells[0].Value != null)

            {

                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "True")

                    gecen = gecen + 1;

                if (dataGridView1.Rows[i].Cells[8].Value.ToString() == "False")

                    kalan++;

                i++;

            }

            lblKalanSayisi.Text = kalan.ToString();

            lblGecenSayisi.Text = gecen.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert into tblders (ogrNumara,ogrAd,ogrSoyad) values (@q1,@q2,@q3)", baglanti);
            komut.Parameters.AddWithValue("@q1", mtxtNumara.Text);
            komut.Parameters.AddWithValue("@q2", txtAd.Text);
            komut.Parameters.AddWithValue("@q3", txtSoyad.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Sisteme Eklendi");
            this.tblDersTableAdapter.Fill(this.dBnotKayitSistemiDataSet.tblDers);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtxtNumara.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtS1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtS2.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtS3.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            lblOrtalama.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }

        private void btnNotGuncelle_Click(object sender, EventArgs e)
        {
            double ortalama, s1, s2, s3;
            string durum;
            s1 = Convert.ToDouble(txtS1.Text);
            s2 = Convert.ToDouble(txtS2.Text);
            s3 = Convert.ToDouble(txtS3.Text);
            ortalama = (s1 + s2 + s3) / 3;
            lblOrtalama.Text = ortalama.ToString();

            if (ortalama >= 50)
            {
                durum = "True";
            }
            else
            {
                durum = "False";
            }


            baglanti.Open();
            SqlCommand komut = new SqlCommand("Update tblders set ogrs1=@p1,ogrs2=@p2,ogrs3=@p3,ortalama=@p4,durum=@p5 where ogrnumara=@p6", baglanti);
            komut.Parameters.AddWithValue("@p1", txtS1.Text);
            komut.Parameters.AddWithValue("@p2", txtS2.Text);
            komut.Parameters.AddWithValue("@p3", txtS3.Text);
            komut.Parameters.AddWithValue("@p4", decimal.Parse(lblOrtalama.Text));
            komut.Parameters.AddWithValue("@p5", durum);
            komut.Parameters.AddWithValue("@p6", mtxtNumara.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Öğrenci Notları Güncellendi.");
            this.tblDersTableAdapter.Fill(this.dBnotKayitSistemiDataSet.tblDers);
        }
    }
}
