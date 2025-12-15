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

namespace İlkProjem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            string connectionString = "Data Source=LAPTOP-SJ6IO553\\SQLEXPRESS;Initial Catalog=guvenlik;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();

                string query = "SELECT * FROM parolaa where kullanici_adi=@username And sifre=@password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {

                    MessageBox.Show("Giriş başarılı");
                    Close();



                }
                else if (string.IsNullOrEmpty(textBox1.ToString()) || string.IsNullOrEmpty(textBox2.ToString()))
                {
                    MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!");
                }

                else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre yanlış");
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bağlantı hatası: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 yeniForm = new Form3();
            yeniForm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // "Şifreyi Göster/Gizle"
            textBox2.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}

