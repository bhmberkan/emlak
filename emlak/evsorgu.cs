using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace emlak
{
    public partial class evsorgu : Form
    {
        public evsorgu()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=emlak.accdb");

      public void getir()
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,RESIM FROM ev", baglanti);
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            /*DataTable tabloo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter listelee = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,RESIM FROM ev WHERE TURU LIKE '" + comboBox4.Text + "%'", baglanti);
            listelee.Fill(tabloo);
            dataGridView1.DataSource = tabloo;
            baglanti.Close();*/

           /* DataTable tablo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter listele = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,RESIM FROM ev WHERE IL LIKE '" + comboBox1.Text + "%'", baglanti);
            listele.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();*/

        }

        private void evsorgu_Load(object sender, EventArgs e)
        {
            getir();
            comboBox4.Items.Add("1+1");
            comboBox4.Items.Add("2+1");
            comboBox4.Items.Add("3+1");
            comboBox4.Items.Add("4+1");
            comboBox4.Items.Add("triblex");
            comboBox4.Items.Add("villa");

            comboBox1.Items.Add("Adana");
            comboBox1.Items.Add("Adıyaman");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int get = dataGridView1.SelectedCells[0].RowIndex;
            comboBox2.Text = dataGridView1.Rows[get].Cells[0].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[get].Cells[2].Value.ToString();
           maskedTextBox2.Text = dataGridView1.Rows[get].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[get].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[get].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[get].Cells[5].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[get].Cells[6].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[get].Cells[7].Value.ToString();
            textBox4.Text = dataGridView1.Rows[get].Cells[8].Value.ToString();
            pictureBox1.ImageLocation=dataGridView1.Rows[get].Cells[8].Value.ToString();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter listele = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,RESIM FROM ev WHERE IL LIKE '" + comboBox1.Text + "%'", baglanti);
            listele.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable tabloo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter listelee = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,RESIM FROM ev WHERE TURU LIKE '" + comboBox4.Text + "%'", baglanti);
            listelee.Fill(tabloo);
            dataGridView1.DataSource = tabloo;
            baglanti.Close();  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anamenü ana = new anamenü();
            ana.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            DataTable tablo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter listele = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,RESIM FROM ev WHERE IL LIKE '" + comboBox1.Text + "%'", baglanti);
            listele.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
    }
}
