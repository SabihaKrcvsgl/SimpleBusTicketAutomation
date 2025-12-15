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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
      
        public void SeferListesiniGoster(DataTable seferListesi)
        {
            dataGridView1.DataSource = seferListesi;
        }

        // dataGridView1_CellContentClick olayı için bir örnek
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Burada yapılacak işlemleri ekleyin (isteğe bağlı)
        }
    }
}
