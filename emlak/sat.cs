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
    public partial class sat : Form
    {
        public sat()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=emlak.accdb");

        public void getir()
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,EV_DURUM1,EV_DURUM2,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,EV_TERCIHI1,EV_TERCIHI2,RESIM FROM satıldı", baglanti);
            adapter.Fill(tablo);
            dataGridView2.DataSource = tablo;
            baglanti.Close();
        }

        public void getir2()
        {
            DataTable tablo = new DataTable();
            baglanti.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT IL,TELEFON,ADRES,EV_DURUM1,EV_DURUM2,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,EV_TERCIHI1,EV_TERCIHI2,RESIM FROM ev", baglanti);
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                label11.Text = "kiralık";
            }
            else
                label11.Text = "";
            ;
            if (checkBox4.Checked == true)
            {
                label12.Text = "satılık";
            }
            else
                label12.Text = "";


            if (checkBox2.Checked == true)
            {
                label5.Text = "pasif";
            }
            else
                label5.Text = "";

            if (checkBox1.Checked == true)
            {
                label6.Text = "aktif";
            }
            else
                label6.Text = "aktif";

            // 1. tablodan adrese göre silip 2. tabloya eklıyoruz
            checkBox2.Checked = false;
            checkBox1.Checked = true;

            OleDbCommand ekle = new OleDbCommand("INSERT into satıldı(IL,TELEFON,ADRES,EV_DURUM1,EV_DURUM2,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,EV_TERCIHI1,EV_TERCIHI2)" +
                       "values('"+comboBox1.Text+ "','" + maskedTextBox2.Text + "','" + richTextBox1.Text + "','" + label6.Text + "','" + label5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + maskedTextBox1.Text + "','" + label11.Text + "','" + label12.Text + "')", baglanti);
            baglanti.Open();
            ekle.ExecuteNonQuery();
            baglanti.Close();
            getir();
            getir2();

            OleDbCommand sil = new OleDbCommand("DELETE FROM ev WHERE ADRES='" + richTextBox1.Text + "'", baglanti);
            baglanti.Open();
            sil.ExecuteNonQuery();
            baglanti.Close();

            getir();
            getir2();


        }

        private void sat_Load(object sender, EventArgs e)
        {
            getir();
            getir2();
            comboBox2.Items.Add("1+1");
            comboBox2.Items.Add("2+1");
            comboBox2.Items.Add("3+1");
            comboBox2.Items.Add("4+1");
            comboBox2.Items.Add("triblex");
            comboBox2.Items.Add("villa");

            comboBox1.Items.Add("Adana");
            comboBox1.Items.Add("Adıyaman");
            comboBox1.Items.Add("Afyon");
            comboBox1.Items.Add("Agrı");
            comboBox1.Items.Add("Amasya");
            comboBox1.Items.Add("Ağrı");
            comboBox1.Items.Add("Amasya");
            comboBox1.Items.Add("Ankara");
            comboBox1.Items.Add("Antalya");
            comboBox1.Items.Add("Artvin");
            comboBox1.Items.Add("Aydın");
            comboBox1.Items.Add("Balıkesir");
            comboBox1.Items.Add("Bilecik");
            comboBox1.Items.Add("Bingöl");
            comboBox1.Items.Add("Bitlis");
            comboBox1.Items.Add("Bolu");
            comboBox1.Items.Add("Burdur");
            comboBox1.Items.Add("Bursa");
            comboBox1.Items.Add("Çanakkale");
            comboBox1.Items.Add("Çankırı");
            comboBox1.Items.Add("Çorum");
            comboBox1.Items.Add("Denizli");
            comboBox1.Items.Add("Diyarbakır");
            comboBox1.Items.Add("Edirne");
            comboBox1.Items.Add("Elazığ");
            comboBox1.Items.Add("Erzincan");
            comboBox1.Items.Add("Erzurum");
            comboBox1.Items.Add("Eskişehir");
            comboBox1.Items.Add("Gazi Antep");
            comboBox1.Items.Add("Giresun");
            comboBox1.Items.Add("Gümüşhane");
            comboBox1.Items.Add("Hakkarı");
            comboBox1.Items.Add("Hatay");
            comboBox1.Items.Add("Isparta");
            comboBox1.Items.Add("Mersin");
            comboBox1.Items.Add("İstanbul");


            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int get = dataGridView1.SelectedCells[0].RowIndex;
            comboBox1.Text = dataGridView1.Rows[get].Cells[0].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[get].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[get].Cells[2].Value.ToString();
            label6.Text = dataGridView1.Rows[get].Cells[3].Value.ToString();
            label5.Text = dataGridView1.Rows[get].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.Rows[get].Cells[5].Value.ToString();
            textBox2.Text = dataGridView1.Rows[get].Cells[6].Value.ToString();
            textBox3.Text = dataGridView1.Rows[get].Cells[7].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[get].Cells[8].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[get].Cells[9].Value.ToString();
            label11.Text = dataGridView1.Rows[get].Cells[10].Value.ToString();
            label12.Text = dataGridView1.Rows[get].Cells[11].Value.ToString();

            if(label6.Text=="Aktif ev")
            {
                checkBox1.Checked = true;
            }

            if (label11.Text == "kiralık")
            {
                checkBox3.Checked = true;
            }

            if (label12.Text == "satılık")
            {
                checkBox4.Checked = true;
            }          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anamenü ana = new anamenü();
            ana.Show();
            this.Close();
        }
    }
}
