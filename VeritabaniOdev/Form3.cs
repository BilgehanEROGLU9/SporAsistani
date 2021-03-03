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

namespace VeritabaniOdev
{
    public partial class Form3 : Form
    {
        public static int kullaniciid;
        SqlCommand komut,komut2;
        SqlDataAdapter da;

       SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BA5NEFA;Initial Catalog=vtOdev;Integrated Security=True");
        public Form3()
        {
            InitializeComponent();
            kullanicigetir();
           
        }
        void kullanicigetir()
        {
           
            baglanti.Open();
            da = new SqlDataAdapter("Select k_id,k_tc,k_adsoyad,k_sifre,k_kilo,k_boy,k_tur from Kullanıcı", baglanti);
           // da = new SqlDataAdapter("Select k_tc,k_adsoyad,k_sifre,k_tur,olcum_id1,olcum,olcumtarihi from Kullanıcı INNER JOIN Ölçüm ON Ölçüm.k_id2 = Kullanıcı.k_id", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
     //   INNER JOIN Ölçüm ON Ölçüm.k_id = Kullanıcı.k_id
        private void Form3_Load(object sender, EventArgs e)
        {
            kullanicigetir();   
        }
        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
          /*  txtadsoyad.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtyas.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtkilo.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtboyun.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtomuz.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 yeni = new Form4();
            yeni.Show();
            this.Hide();

        }

        private void bacak_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            kullaniciid = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "DELETE FROM Kullanıcı_Detay INNER JOIN Kullanıcı ON Kullanıcı_Detay.k_id1 = Kullanıcı.k_id Where k_id="+kullaniciid; 
           // komut.CommandText = "delete from Kullanıcı where k_id=" +kullaniciid+ "INNER JOIN Kullanıcı_Detay ON Kullanıcı_Detay.k_id = Kullanıcı.k_id1";
            komut.ExecuteNonQuery();
            baglanti.Close();
            kullanicigetir();
        }
       
        private void guncelle_Click(object sender, EventArgs e)
        {
            kullaniciid = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            
            komut = new SqlCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            string tür = "";
            if (comboBox1.Text == "Personel")
                tür = "P";
            else if (comboBox1.Text == "Kullanıcı")
                tür = "K";
            komut.CommandText = "update Kullanıcı set k_tc='" + txttc.Text + "',k_adsoyad='" + txtadsoyad.Text + "',k_sifre='" +txtsifre.Text + "',k_tur='" + tür+"',k_kilo='" +txtkilo.Text + "',k_boy='" + txtboy.Text + "' where k_id=" + kullaniciid + "";
           
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Open();
            komut2 = new SqlCommand();
           komut2.Connection = baglanti;
            string cinsiyet = "";
            if (radioButton1.Checked)
                cinsiyet = "E";
            else if (radioButton2.Checked)
                cinsiyet = "K";
            komut2.CommandText = "update Kullanıcı_Detay set k_cinsiyet='" + cinsiyet + "',k_yas='" + txtyas.Text  + "' where k_id1=" + kullaniciid + "";
          
           komut2.ExecuteNonQuery();
            baglanti.Close();
            kullanicigetir();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtboy_TextChanged(object sender, EventArgs e)
        {

        }

        private void ekle_Click(object sender, EventArgs e)
        {

            string sorgu = "INSERT INTO Kullanıcı(k_tc,k_adsoyad,k_sifre,k_kilo,k_boy,k_tur)VALUES(@k_tc,@k_adsoyad,@k_sifre,@k_kilo,@k_boy,@k_tur)";
            string sorgu2 = "INSERT INTO Kullanıcı_Detay(k_id1,k_yas,k_cinsiyet)VALUES((SELECT IDENT_CURRENT('Kullanıcı')),@k_yas,@k_cinsiyet)";
           
            komut = new SqlCommand(sorgu, baglanti);
            komut2 = new SqlCommand(sorgu2, baglanti);
            komut.Parameters.AddWithValue("@k_tc", txttc.Text);
            komut.Parameters.AddWithValue("@k_adsoyad", txtadsoyad.Text);
            komut.Parameters.AddWithValue("@k_sifre", txtsifre.Text);
            komut.Parameters.AddWithValue("@k_boy", txtboy.Text);
            komut.Parameters.AddWithValue("@k_kilo", txtkilo.Text);
            komut2.Parameters.AddWithValue("@k_yas", txtyas.Text);
            string tür = "";
            if (comboBox1.Text=="Personel")
                tür = "P";
            else if (comboBox1.Text=="Kullanıcı")
                tür= "K";
            
            komut.Parameters.AddWithValue("@k_tur",tür);
            string cinsiyet = "";
            if (radioButton1.Checked)
                cinsiyet = "E";
            else if (radioButton2.Checked)
                cinsiyet = "K";

            komut2.Parameters.AddWithValue("@k_cinsiyet",cinsiyet);
            

            baglanti.Open();
            komut.ExecuteNonQuery();
            komut2.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
            baglanti.Close();
            kullanicigetir();
        }
    }
    }

