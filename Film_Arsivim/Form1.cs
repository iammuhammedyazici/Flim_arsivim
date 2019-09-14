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

namespace Film_Arsivim
{
    public partial class TabFlix : Form
    {
        public TabFlix()
        {
            InitializeComponent();
        }
        void temizle()
        {
            txtFlmAd.Text = "";
            TxtKategori.Text = "";
            txtLink.Text = "";

        } 
        void filmlistele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select AD,KATEGORI,LINK FROM TBL_FLIMLER order by ad asc", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void TabFlix_Load(object sender, EventArgs e)
        {
            filmlistele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FLIMLER " +
                "(AD, KATEGORI, LINK) " +
                "VALUES " +
                "(@P1, @P2, @P3)",
                bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtFlmAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtKategori.Text);
            komut.Parameters.AddWithValue("@p3", txtLink.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Film Başarılı Bir Şekilde Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            filmlistele();    

        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            webBrowser1.Navigate(dr["LINK"].ToString());
        }

        private void BtnHakkimizda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Merhabalar ben Muhammed Yazıcı, " +
                "Cumhuriyet Üniversite'si Bilgisayar Mühendisliği son sınıf öğrencisiyim. " +
                "Film izleme uygulaması geliştirdim.-2018", "HAKKIMIZDA", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnRenk_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int sayi = r.Next(9);

            switch (sayi)
            {
                case 0: this.BackColor = Color.Blue; break;
                case 1: this.BackColor = Color.Red; break;
                case 2: this.BackColor = Color.Yellow; break;
                case 3: this.BackColor = Color.Green; break;
                case 4: this.BackColor = Color.Black; break;
                case 5: this.BackColor = Color.Aqua; break;
                case 6: this.BackColor = Color.White; break;
                case 7: this.BackColor = Color.Turquoise; break;
                case 8: this.BackColor = Color.Purple; break;
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);//Satırın verisini al
            if (dr != null)
            {
                txtFlmAd.Text = dr["AD"].ToString();
                TxtKategori.Text = dr["KATEGORI"].ToString();
                txtLink.Text = dr["LINK"].ToString();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult uyari;
            uyari = MessageBox.Show("Silmek istediğinize emin misiniz ?", "UYARI!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (uyari == DialogResult.Yes)
            {
                SqlCommand komutsil = new SqlCommand("Delete From TBL_FLIMLER  where LINK=@p1", bgl.baglanti());
                komutsil.Parameters.AddWithValue("@p1", txtLink.Text);
                komutsil.ExecuteNonQuery();
                bgl.baglanti();
                MessageBox.Show("Filminiz Silindi. ", "Uyarı!!!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                filmlistele();
            }

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
