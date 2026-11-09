using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DilKursuYonetimProjesi
{
    public partial class OgrenciYonetim : Form
    {
        public OgrenciYonetim()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KursDb;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void OgrenciYonetim_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from OgrenciTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            YonetimDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        int OgrKey;
        private void button2_Click(object sender, EventArgs e)
        {
            if (AdSoyadTb.Text == "" || TelefonTb.Text == "" || ResimTb.Text == "" || CinsiyetCb.Text == "" || AdresTb.Text == "")
            {
                MessageBox.Show("Silinecek öğrenciyi seçiniz");
            }
            else
            {
                try
                {
                    OgrKey = Convert.ToInt32(YonetimDgv.SelectedRows[0].Cells[0].Value.ToString());
                    baglanti.Open();
                    string query = "delete from OgrenciTbl where OgrenciId="+OgrKey+"";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci Başarıyla Silindi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void YonetimDgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            OgrKey = Convert.ToInt32(YonetimDgv.SelectedRows[0].Cells[0].Value.ToString());
            AdSoyadTb.Text = YonetimDgv.SelectedRows[0].Cells[1].Value.ToString();
            TelefonTb.Text = YonetimDgv.SelectedRows[0].Cells[2].Value.ToString();
            DogumThTb.Text = YonetimDgv.SelectedRows[0].Cells[3].Value.ToString();
            CinsiyetCb.Text = YonetimDgv.SelectedRows[0].Cells[4].Value.ToString();
            ResimTb.Text = YonetimDgv.SelectedRows[0].Cells[5].Value.ToString();
            AdresTb.Text = YonetimDgv.SelectedRows[0].Cells[6].Value.ToString();
            YonetimPb.ImageLocation = ResimTb.Text;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AdSoyadTb.Text == "" || TelefonTb.Text == "" || ResimTb.Text == "" || CinsiyetCb.Text == "" || AdresTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    //OgrKey = Convert.ToInt32(YonetimDgv.SelectedRows[0].Cells[0].Value.ToString());
                    baglanti.Open();
                    string query = "update OgrenciTbl set AdSoyad='"+AdSoyadTb.Text+"',Telefon='"+TelefonTb.Text+"',DogumTrh='"+DogumThTb.Text+"',Cinsiyet='"+CinsiyetCb.Text+"',Resim='"+ResimTb.Text+"',Adres='"+AdresTb.Text+"' where OgrenciId="+OgrKey+";";
                    SqlCommand komut = new SqlCommand(query, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Öğrenci Başarıyla Güncellendi");
                    baglanti.Close();
                    uyeler();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa();
            ana.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //sopenFileDialog1.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.ShowDialog();
            
            YonetimPb.ImageLocation = openFileDialog1.FileName;
            ResimTb.Text = openFileDialog1.FileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdSoyadTb.Text = "";
            TelefonTb.Text = "";
            ResimTb.Text = "";
            AdresTb.Text = "";
            CinsiyetCb.Text = "";
            YonetimPb.ImageLocation = "";
        }

        private void button_Ara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from OgrenciTbl where AdSoyad like '%"+FilterTb.Text+"%'",baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            YonetimDgv.DataSource = ds.Tables[0];
            baglanti.Close();

        }

        private void Yenile_Click(object sender, EventArgs e)
        {
            uyeler();

        }
    }
}
