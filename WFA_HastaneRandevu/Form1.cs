using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_HastaneRandevu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Brans> bolumler = new List<Brans>();
        List<Randevu> randevular = new List<Randevu>();
        private void BtnBrans_Click(object sender, EventArgs e)
        {
           
            Brans brans = new Brans();
            brans.Ad = txtBrans.Text;
            
            brans.Doktorlar = new List<Doktor>();
            bolumler.Add(brans);
            
            cmbBrans.DataSource = cmbRandevuBrans.DataSource = bolumler.ToList();
        }

        private void BtnDoktorEkle_Click(object sender, EventArgs e)
        {
            Doktor doktor = new Doktor();
            doktor.Ad = txtDoktorAdi.Text;
            Brans brans = cmbBrans.SelectedItem as Brans;              
            brans.Doktorlar.Add(doktor);
            cmbRandevuDoktor.DataSource = brans.Doktorlar.ToList();
        }

        private void CmbRandevuBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brans b = cmbRandevuBrans.SelectedItem as Brans;
            cmbRandevuDoktor.DataSource = b.Doktorlar.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Olustur();
        }
        //object initilizer
        List<string> saatler = new List<string>()
        {
            "09:00","09:30","10:00","10:30","11:00","11:30","12:00"
        };
        public void Olustur()
        {
            
            foreach(string item in saatler)
            {
                Button btn = new Button();
                btn.Text = item;
                flowLayoutPanel1.Controls.Add(btn);
                btn.Click += Btn_Click;
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (txtTcKimlikNo.Text == string.Empty || txtAd.Text == string.Empty || txtSoyad.Text == string.Empty || cmbRandevuBrans.SelectedIndex < 0 || cmbRandevuDoktor.SelectedIndex < 0 || dtpRandevu.Value < DateTime.Today)
            {
                MessageBox.Show("Lütfen randevu bilgilerinizi eksiksiz ve doğru bir şekilde giriniz");
            }
            else
            {
                DialogResult dr = MessageBox.Show("Randevu oluşturmak istediğinize emin misiniz?", "Bilgi", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    btn.BackColor = Color.Red;
                    Randevu randevu = new Randevu();
                    randevu.Ad = txtAd.Text;
                    randevu.Soyad = txtSoyad.Text;
                    randevu.TCKN = txtTcKimlikNo.Text;
                    randevu.DoktorAdi = cmbRandevuDoktor.SelectedItem as Doktor;
                    randevu.Brans = cmbRandevuBrans.SelectedItem as Brans;
                    randevu.Saat = btn.Text;
                    randevu.RandevuTarih = dtpRandevu.Value;
                    randevular.Add(randevu);
                }
            }

        }
    }
}

