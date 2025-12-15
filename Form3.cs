using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace İlkProjem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        MailMessage eposta = new MailMessage();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = textBox1.Text;
            string eposta = textBox2.Text;
            String sifrem = "12345";
            string connectionString = "Data Source=LAPTOP-SJ6IO553\\SQLEXPRESS;Initial Catalog=guvenlik;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            string query = "SELECT * FROM parolaa where kullanici_adi=@username And eposta=@eposta  ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@eposta", eposta);




            connection.Open();

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                SmtpClient smtp = new SmtpClient();
                MailMessage mail = new MailMessage();
                String tarih = DateTime.Now.ToLongDateString();
                String mailadres = "sbhk80646@gmail.com";
                String sifre = "iknr kuyf gzoj ozkb";
                String smtpserver = "smtp.gmail.com";
                String kime = reader["eposta"].ToString();
                String konu = "şifre hatırlatma";
                String yaz = "Sayın, " + reader["kullanici_adi"].ToString() + "\n" + "bizden " + tarih +
                    " tarihinde şifre hatırlatma maili talebinde bulundunuz. Şifreniz: " + sifrem;
                smtp.Credentials = new NetworkCredential(mailadres, sifre);
                smtp.Port = 587;
                smtp.Host = smtpserver;
                smtp.EnableSsl = true;
                mail.From = new MailAddress(mailadres);
                mail.To.Add(kime);
                mail.Subject = konu;
                mail.Body = yaz;
                smtp.Send(mail);

                DialogResult bilgi = MessageBox.Show("Girmiş olduğunuz bilgiler uyuştu, mail adresinizi kontrol ediniz");
            }
            else
            {
                DialogResult bilgi = MessageBox.Show("Girmiş olduğunuz bilgiler uyuşmadı");
            }

            connection.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

