using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DilKursuYonetimProjesi
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
            PanelDesign();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void PanelDesign()
        {
            panel_ogrenciMenu.Visible=false;
            panel_kursMenu.Visible=false;
            panel_puanMenu.Visible=false;
        }
        private void HideMenu()
        {
            if (panel_ogrenciMenu.Visible == true)
                panel_ogrenciMenu.Visible = false;
            if (panel_kursMenu.Visible== true)
                panel_kursMenu.Visible = false;
            if(panel_puanMenu.Visible== true)
                panel_puanMenu.Visible = false;
            
        }
        private void ShowMenu(Panel menu)
        {
            if (menu.Visible == false)
            {
                HideMenu();
                menu.Visible= true;
            }
            else
            {
                menu.Visible = false;
            }
        }

        private void button_ogrenci_Click(object sender, EventArgs e)
        {
            ShowMenu(panel_ogrenciMenu);
        }

        private void button_ogrencikayıt_Click(object sender, EventArgs e)
        {
            HideMenu();
            Kayit kyt = new Kayit();
            kyt.Show();
            this.Hide();
        }

        private void button_ogrenciYonetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            OgrenciYonetim ogry= new OgrenciYonetim();
            ogry.Show();
            this.Hide();
        }

        private void button_ogrenciIcerik_Click(object sender, EventArgs e)
        {
            HideMenu();
        }

        private void button_ogrenciYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
            OgrenciYazdır yzd = new OgrenciYazdır();
            yzd.Show();
            this.Hide();
        }

        private void button_Kurs_Click(object sender, EventArgs e)
        {
            ShowMenu(panel_kursMenu);
        }

        private void button_KursKayıt_Click(object sender, EventArgs e)
        {
            HideMenu();
            YeniKurs yni = new YeniKurs();
            yni.Show();
            this.Hide();
        }

        private void button_KursYonetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            KayitYonetim kyt=new KayitYonetim();
            kyt.Show();
            this.Hide();
        }

        private void button_KursYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
            KursYazdir kyz=new KursYazdir();
            kyz.Show();
            this.Hide();
        }

        private void button_puanlama_Click(object sender, EventArgs e)
        {
            ShowMenu(panel_puanMenu);
        }

        private void button_yenipuan_Click(object sender, EventArgs e)
        {
            HideMenu();
            YeniPuan yni= new YeniPuan();
            yni.Show();
            this.Hide();
        }

        private void button_puanYonetim_Click(object sender, EventArgs e)
        {
            HideMenu();
            PuanYonetim pyn = new PuanYonetim();
            pyn.Show();
            this.Hide();
        }


        private void button_puanYazdır_Click(object sender, EventArgs e)
        {
            HideMenu();
            PuanYazdır pnz=new PuanYazdır();
            pnz.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button_Cıkıs_Click(object sender, EventArgs e)
        {
            Login log=new Login();
            log.Show();
            this.Hide();
        }
    }
}
