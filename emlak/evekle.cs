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
    public partial class evekle : Form
    {
        public evekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=emlak.accdb");
        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            textBox4.Text = openFileDialog1.FileName;
        }

        private void evekle_Load(object sender, EventArgs e)
        {
           /* if(checkBox1.Checked==true)
            {
                label6.Text = "AktiF ev";
            }
            else
                label6.Text = "";

            if (checkBox2.Checked == true)
            {
                label5.Text = "pasif ev";
            }
            else
                label5.Text = "";

            if (checkBox3.Checked == true)
            {
                label11.Text = "kiralık";   
            }
            else
                label11.Text = "";

            if (checkBox4.Checked == true)
            {
                label12.Text = "satılık";
            }
            else
                label12.Text = "";*/

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
            
            //.... burayı 81 il şeklınde combo box 1 e yazdırırsın

            comboBox2.Items.Add("1+1");
            comboBox2.Items.Add("2+1");
            comboBox2.Items.Add("3+1");
            comboBox2.Items.Add("4+1");
            comboBox2.Items.Add("triblex");
            comboBox2.Items.Add("villa");
        }

        bool deger;
        void ekleme()
        {
            baglanti.Open();
            OleDbCommand tekrar = new OleDbCommand("SELECT * FROM ev WHERE adres=@P1", baglanti);
            tekrar.Parameters.AddWithValue("@p1", richTextBox1.Text);
            OleDbDataReader oku = tekrar.ExecuteReader();
            if (oku.Read())
            {
                deger = false;
            }
            else
            {
                deger = true;
            }
            baglanti.Close();
        }

            private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked == true)
                {
                    label6.Text = "Aktif ev";
                }
                else
                    label6.Text = "";

                if (checkBox2.Checked == true)
                {
                    label5.Text = "Pasif ev";
                }
                else
                    label5.Text = "";

                if (checkBox3.Checked == true)
                {
                    label11.Text = "kiralık";
                }
                else
                    label11.Text = "";

                if (checkBox4.Checked == true)
                {
                    label12.Text = "satılık";
                }
                else
                    label12.Text = "";

                ekleme();
                if (deger == true)
                {
                    OleDbCommand ekle = new OleDbCommand("insert into ev(IL,TELEFON,ADRES,EV_DURUM1,EV_DURUM2,KAT_NO,ALAN,ODA_SAYISI,TURU,YAPIM_TARIHI,EV_TERCIHI1,EV_TERCIHI2,RESIM)values('" + comboBox1.Text + "','"+maskedTextBox2.Text+"','" + richTextBox1.Text + "','" + label6.Text + "','" + label5.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','" + maskedTextBox1.Text + "','" + label11.Text + "','" + label12.Text + "','" + textBox4.Text + "')", baglanti);
                    baglanti.Open();
                    ekle.ExecuteNonQuery();
                    baglanti.Close();

                    //OleDbCommand sil = new OleDbCommand("delete * from evsil where adres='"+textBox1.Text+"'",baglanti);

                    MessageBox.Show("ev bilgileri veri tabanına eklenmiştir.");


                    richTextBox1.Text = "";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                    maskedTextBox1.Text = "";
                    maskedTextBox2.Text = "";
                    checkBox1.Checked = false;
                    checkBox2.Checked = false;
                    checkBox3.Checked = false;
                    checkBox4.Checked = false;
                }
                else
                    MessageBox.Show("bu ev bilgileri zaten var","Var Olan Ev",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
                baglanti.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            anamenü ana = new anamenü();
            ana.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            evsorgu evs = new evsorgu();
            evs.Show();
            this.Close();
        }
    }
}
