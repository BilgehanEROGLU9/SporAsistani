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
    public partial class Form4 : Form
    {
        String deger,bolgeid;
        int kullaniciid;
        SqlCommand komut, komut2,komut4;
        SqlDataAdapter da,cumle,db;
        SqlConnection  baglanti = new SqlConnection("Data Source=DESKTOP-BA5NEFA;Initial Catalog=vtOdev;Integrated Security=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            kullanicigetir();
            bolgesec();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        void ara()
        {
            
            baglanti.Open();
            da = new SqlDataAdapter("Select * from Kullanıcı where K_adsoyad like '%" + aranan.Text + "%'", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
        void kullanicigetir()
        {
            
            baglanti.Open();
            da = new SqlDataAdapter("Select k_id,k_adsoyad from Kullanıcı", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {




        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand();
            komut5.Connection = baglanti;
            komut5.CommandText = "Select olcumtarihi from Ölçüm where k_id="+kullaniciid+"and olcum_id="+bolgeid+"";
            komut5.ExecuteNonQuery();
            SqlDataReader dr1 = komut5.ExecuteReader();
            if (dr1.Read())
            {
              //  label5.Text = dr1["olcumtarihi"].ToString();

            }
            else
            {
                MessageBox.Show("veri cekilemedi");
            }
        }

        private void bacak_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Form3 ac = new Form3();
            ac.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            kullaniciid = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
            SqlCommand komut3 = new SqlCommand();
            baglanti.Open();
            komut3.Connection = baglanti;
            komut3.CommandText = "Select olcum_id from Bölgeler where olcum_tur='" + comboBox1.Text + "'";
            komut3.ExecuteNonQuery();
            SqlDataReader dr = komut3.ExecuteReader();
            if (dr.Read())
            {
                bolgeid = dr["olcum_id"].ToString();
 
            }
            else
            {
                MessageBox.Show("veri cekilemedi");
            }
            
            string sorgu = "INSERT INTO Ölçüm(k_id2,olcum_id1,olcum,olcumtarihi)VALUES(@k_id2,@olcum_id1,@olcum,@olcumtarihi)";
            komut4 = new SqlCommand(sorgu, baglanti);
            komut4.Parameters.AddWithValue("@k_id2", kullaniciid);
            komut4.Parameters.AddWithValue("@olcum_id1",Convert.ToInt32(bolgeid));
            komut4.Parameters.AddWithValue("@olcum", textBox2.Text);
            komut4.Parameters.AddWithValue("@olcumtarihi",dateTimePicker1.Value.ToShortDateString());
            dr.Close();
            komut4.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı");
          /*  SqlCommand komut5 = new SqlCommand();
            komut5.Connection = baglanti;
            komut5.CommandText = "Select olcumtarihi from Ölçüm where k_id="+kullaniciid+"and olcum_id="+bolgeid+"";
            komut5.ExecuteNonQuery();
            SqlDataReader dr1 = komut5.ExecuteReader();
            if (dr1.Read())
            {
                label5.Text = dr["olcumtarihi"].ToString();

            }
            else
            {
                MessageBox.Show("veri cekilemedi");
            }
            //  DateTime bTarih = Convert.ToDateTime();
            //  DateTime kTarih = Convert.ToDateTime();
            //  TimeSpan Sonuc = bTarih - kTarih;
            //label1.Text = Sonuc.TotalHours.ToString();*/
            baglanti.Close();

        }
        void bolgeidcek()
        {  
            SqlCommand komut3 = new SqlCommand();
            baglanti.Open();
            komut3.Connection = baglanti;
            komut3.CommandText = "Select olcum_id from Bölgeler where olcum_tur='" + comboBox1.Text + "'";
            komut3.ExecuteNonQuery();
            SqlDataReader dr = komut3.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(dr["olcum_id"].ToString());
            }
            else
            {
                MessageBox.Show("veri cekilemedi");
            }
            baglanti.Close();

        }

        void bolgesec()
        {
            SqlCommand komut = new SqlCommand();
            komut.CommandText = "SELECT olcum_tur FROM Bölgeler";
            komut.Connection = baglanti;
            komut.CommandType = CommandType.Text;

            SqlDataReader dr;
            baglanti.Open();
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["olcum_tur"]);
            }
            baglanti.Close();

        }
        private void button6_Click(object sender, EventArgs e)
        {
            ara();
        }
    }
}
