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
    public partial class Form6 : Form
    {
      
        SqlCommand komut, komut2;
        SqlDataAdapter da;

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BA5NEFA;Initial Catalog=vtOdev;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }

        private void bacak_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            kullanicigetir();
            bilgigetir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 yeni7 = new Form7();
            yeni7.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 yeni7 = new Form1();
            yeni7.Show();
            this.Hide();

        }

      void bilgigetir()
        {
            int id;
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand();
            komut5.Connection = baglanti;
            komut5.CommandText = "Select k_id,k_adsoyad,k_kilo,k_boy from Kullanıcı where k_tc=" + Form5.kyenitc ;
            komut5.ExecuteNonQuery();
            SqlDataReader dr1 = komut5.ExecuteReader();
            if (dr1.Read())
            {
                label2.Text = Form5.kyenitc;
                label3.Text = dr1["k_adsoyad"].ToString();
                label8.Text= dr1["k_kilo"].ToString();
                label10.Text = dr1["k_boy"].ToString();
              
              
            }
            else
            {
                MessageBox.Show("veri cekilemedi");
            }
            baglanti.Close();
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        void kullanicigetir()
        {
            baglanti.Open();
            da = new SqlDataAdapter("Select k_adsoyad AS ADSOYAD,olcum_tur AS BÖLGE,olcum AS ÖLÇÜ,olcumtarihi AS TARİH from Kullanıcı , Ölçüm, Bölgeler WHERE Ölçüm.k_id2 = Kullanıcı.k_id and Bölgeler.olcum_id = Ölçüm.olcum_id1 and Kullanıcı.k_tc="+Form5.kyenitc, baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }
    }
}
