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
    public partial class KursYazdir : Form
    {
        public KursYazdir()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KursDb;Integrated Security=True");

        private void yazdırDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KursYazdir_Load(object sender, EventArgs e)
        {
            uyeler();
        }
        private void uyeler()
        {
            baglanti.Open();
            string query = "select * from KursTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            KursYazdırDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa();
            ana.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KursTbl where KursAdi like '%" + FilterTb.Text + "%'", baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            KursYazdırDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Yenile_Click(object sender, EventArgs e)
        {
            uyeler();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.KursYazdırDgv.Width, this.KursYazdırDgv.Height);
            KursYazdırDgv.DrawToBitmap(bmp, new Rectangle(0, 0, this.KursYazdırDgv.Width, this.KursYazdırDgv.Height));
            e.Graphics.DrawImage(bmp, 20, 150);
            e.Graphics.DrawString(label1.Text, new Font("Verdana", 20, FontStyle.Bold), Brushes.Black, new Point(300, 30));
            this.KursYazdırDgv.Columns["KursId"].Visible= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
