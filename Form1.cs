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
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace İlkProjem

{
    public partial class Form1 : Form

    {

        public Form1()
        {
            InitializeComponent();

            // Form2'yi  gösterim
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }

        SqlConnection Baglanti = new SqlConnection("Data Source=LAPTOP-SJ6IO553\\SQLEXPRESS;Initial Catalog=YolcuBilet;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // TextBox'ları kontrol et
            if (string.IsNullOrWhiteSpace(textAd.Text) ||
                string.IsNullOrWhiteSpace(textSoyad.Text) ||
                string.IsNullOrWhiteSpace(maskTelefon.Text) ||
                string.IsNullOrWhiteSpace(maskTC.Text) ||
                string.IsNullOrWhiteSpace(maskMail.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // rezervasyon yapmaktan vazgeç
            }
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into  TABYOLCUBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@p1,@p2,@p3,@p4,@p5,@p6)", Baglanti);
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskTelefon.Text);
            komut.Parameters.AddWithValue("@p4", maskTC.Text);
            komut.Parameters.AddWithValue("@p5", combCinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", maskMail.Text);

            komut.ExecuteNonQuery();
            Baglanti.Close();

            textAd.Text = "";
            textSoyad.Text = "";
            maskTelefon.Text = "";
            maskTC.Text = "";
            combCinsiyet.Text = "";
            maskMail.Text = "";

            MessageBox.Show("Yolcu Bilgi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnKaptan_Click(object sender, EventArgs e)
        {
            // TextBox'ları kontrol et
            if (string.IsNullOrWhiteSpace(textKaptanNo.Text) ||
                string.IsNullOrWhiteSpace(textKaptanAdSoyad.Text) ||
                string.IsNullOrWhiteSpace(maskKaptanTelefon.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TABKAPTAN  (KAPTANNO,ADSOYAD,TELEFON) values (@p1,@p2,@p3)", Baglanti);

            komut.Parameters.AddWithValue("@p1", textKaptanNo.Text);
            komut.Parameters.AddWithValue("@p2", textKaptanAdSoyad.Text);
            komut.Parameters.AddWithValue("@p3", maskKaptanTelefon.Text);

            komut.ExecuteNonQuery();
            Baglanti.Close();

            textKaptanNo.Text = "";
            textKaptanAdSoyad.Text = "";
            maskKaptanTelefon.Text = "";


            MessageBox.Show("Kaptan Bilgi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnSeferOlustur_Click(object sender, EventArgs e)
        {
            // TextBox'ları kontrol et
            if (string.IsNullOrWhiteSpace(textKalkis.Text) ||
                string.IsNullOrWhiteSpace(textVaris.Text) ||
                string.IsNullOrWhiteSpace(maskTarih.Text) ||
                string.IsNullOrWhiteSpace(maskSaat.Text) ||
                string.IsNullOrWhiteSpace(textFiyat.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TABSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FIYAT) values (@p1,@p2,@p3,@p4,@p5,@p6)", Baglanti);

            komut.Parameters.AddWithValue("@p1", textKalkis.Text);
            komut.Parameters.AddWithValue("@p2", textVaris.Text);
            komut.Parameters.AddWithValue("@p3", maskTarih.Text);
            komut.Parameters.AddWithValue("@p4", maskSaat.Text);
            komut.Parameters.AddWithValue("@p5", maskKaptan.Text);
            komut.Parameters.AddWithValue("@p6", textFiyat.Text);


            komut.ExecuteNonQuery();
            Baglanti.Close();

            textKalkis.Text = "";
            textVaris.Text = "";
            maskTarih.Text = "";
            maskSaat.Text = "";
            maskKaptan.Text = "";
            textFiyat.Text = "";
            textSeferNo.Text = "";



            MessageBox.Show("Sefer Bilgisi Sisteme Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        private void btnRezervasyonyap_Click(object sender, EventArgs e)
        {

            // TextBox'ları kontrol et
            if (string.IsNullOrWhiteSpace(textSeferNumara.Text) ||
                string.IsNullOrWhiteSpace(maskYolcuTC.Text) ||
                string.IsNullOrWhiteSpace(textKoltukNo.Text))
                
                
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }
            {
                Baglanti.Open();
                SqlCommand komut = new SqlCommand("insert into TABSEFERDETAY(SEFERNO,YOLCUTC,KOLTUK) values (@p1,@p2,@p3)", Baglanti);
                komut.Parameters.AddWithValue("@p1", textSeferNumara.Text);
                komut.Parameters.AddWithValue("@p2", maskYolcuTC.Text);
                komut.Parameters.AddWithValue("@p3", textKoltukNo.Text);

                komut.ExecuteNonQuery();
                Baglanti.Close();

                textSeferNumara.Text = "";
                maskYolcuTC.Text = "";
                textKoltukNo.Text = "";

            }
            progressBar1.Value = 0;

            for (int i = 0; i <= 100; i++)
            {
                progressBar1.Value = i;

                try
                {
                    Thread.Sleep(50);
                }

                catch (ThreadInterruptedException ex)
                {
                    MessageBox.Show(ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            //  ProgressBar'ı gizle
            progressBar1.Visible = false;


            MessageBox.Show("REZERVASYON İŞLEMİ BAŞARIYLA GERÇEKLEŞTİ.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Veritabanından sefer listesini çek
                DataTable seferListesi = new DataTable();
                using (SqlConnection connection = new SqlConnection("Data Source=LAPTOP-SJ6IO553\\SQLEXPRESS;Initial Catalog=YolcuBilet;Integrated Security=True"))
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM TABSEFERBILGI", connection);
                    da.Fill(seferListesi);
                }

                //  sefer listesini Form4'e aktar
                Form4 form4 = new Form4();
                form4.SeferListesiniGoster(seferListesi);
                form4.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
    
    
    


