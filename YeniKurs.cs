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
    public partial class YeniKurs : Form
    {
        public YeniKurs()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=KursDb;Integrated Security=True");

        private void YeniKurs_Load(object sender, EventArgs e)
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
            KursDgv.DataSource = ds.Tables[0];
            baglanti.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (AdTb.Text == "" || SaatTb.Text == "" || AciklamaTb.Text == "")
            {
                MessageBox.Show("Eksik Bilgi");
            }
            else
            {
                try
                {
                    baglanti.Open();
                    string query = "insert into KursTbl values ('" + AdTb.Text + "','" + SaatTb.Text + "','" + AciklamaTb.Text + "')";
                    SqlCommand komut = new SqlCommand(query,baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("KursBaşarıyla Eklendi");
                    baglanti.Close();
                    uyeler();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdTb.Text = "";
            SaatTb.Text = "";
            AciklamaTb.Text = "";
        }

        private void label8_Click(object sender, EventArgs e)
        {
            AnaSayfa ana=new AnaSayfa();
            ana.Show();
            this.Hide();
        }
    }
}
