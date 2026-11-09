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
    public partial class PuanYazdır : Form
    {
        public PuanYazdır()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KursDb;Integrated Security=True");

        private void KursYazdırDgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_Ara_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from PuanTbl where OgrenciId like '%" + FilterTb.Text + "%'", baglanti);
            SqlDataAdapter sda = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            PuanDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void Yenile_Click(object sender, EventArgs e)
        {
            puanlar();
        }

        private void PuanYazdır_Load(object sender, EventArgs e)
        {
            puanlar();
        }
        private void puanlar()
        {
            baglanti.Open();
            string query = "select * from PuanTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, baglanti);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            PuanDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa();
            ana.Show();
            this.Hide();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap map=new Bitmap(this.PuanDgv.Width,this.PuanDgv.Height);
            PuanDgv.DrawToBitmap(map,new Rectangle(0,0,this.PuanDgv.Width, this.PuanDgv.Height));
            e.Graphics.DrawImage(map, 180, 150);
            e.Graphics.DrawString(label1.Text, new Font("Verdana", 20, FontStyle.Bold), Brushes.Black, new Point(300, 30));
            this.PuanDgv.Columns["PuanId"].Visible= false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();

        }
    }
}
