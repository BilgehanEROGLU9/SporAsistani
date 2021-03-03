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
    public partial class Form7 : Form
    {
        SqlCommand komut, komut2;
        SqlDataAdapter da;
        public static double kilo, boy, indeks;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BA5NEFA;Initial Catalog=vtOdev;Integrated Security=True");
        public Form7()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           Form8 yeni= new Form8();
           
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 300, 168);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\benchpress.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();


        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 313, 161);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\inclinebench.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 261, 193);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\inclinedumbellpress.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 298, 169);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\cablecrossover.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 275, 183);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\reversecrunch.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 256, 197);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\toetouches.png");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10,10, 313, 403);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\crunch.png");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 256, 197);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\pullup.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label9_Click(object sender, EventArgs e)
        {

            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 318, 158);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\barbellbentover.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 303, 166);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\dumbellrow.jpg");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 330, 231);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\tbarrowmuscle.png");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Form8 yeni = new Form8();
            PictureBox picture = new PictureBox();
            picture.SetBounds(10, 10, 330, 193);
            yeni.Controls.Add(picture);
            picture.Image = Image.FromFile(@"C:\Users\bilge\OneDrive\Masaüstü\VeritabaniOdev\resimler\barbelldeadlift.png");
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            yeni.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 yeni7 = new Form1();
            yeni7.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 yeni7 = new Form6();
            yeni7.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            antrenmansec();

        }

        void antrenmansec()
        {

            SqlCommand komut3 = new SqlCommand();
            baglanti.Open();
            komut3.Connection = baglanti;
            komut3.CommandText = "Select k_kilo from Kullanıcı where  k_tc='" + Form5.kyenitc + "'";
            komut3.ExecuteNonQuery();
            SqlDataReader dr = komut3.ExecuteReader();
            if (dr.Read())
            {
                //  MessageBox.Show(dr["k_kilo"].ToString());
            }
            else
            {
                // MessageBox.Show("veri cekilemedi");
            }
            kilo = Convert.ToInt32(dr["k_kilo"]);

            baglanti.Close();
            // MessageBox.Show("kilo"+kilo.ToString());
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand();

            komut2.Connection = baglanti;
            komut2.CommandText = "Select k_boy from Kullanıcı where  k_tc='" + Form5.kyenitc + "'";
            komut2.ExecuteNonQuery();
            SqlDataReader dr1 = komut2.ExecuteReader();
            if (dr1.Read())
            {
                // MessageBox.Show(dr1["k_boy"].ToString());
            }
            else
            {
                //  MessageBox.Show("veri cekilemedi");
            }
            boy = Convert.ToInt32(dr1["k_boy"]);
            baglanti.Close();
            //MessageBox.Show("boy" + boy.ToString());
            indeks = (kilo / (boy * boy)) * 10000;
            //MessageBox.Show(indeks.ToString());

      
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            if (comboBox1.SelectedItem.ToString() == "Kilo Verme")
            {
                if (indeks >= 35)
                {
                    baglanti.Open();
                    da = new SqlDataAdapter("Select * from Antrenmanlar where a_seviyesi='kv1'", baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();

                }
                else if (25 < indeks || indeks < 35)
                {
                    baglanti.Open();
                    da = new SqlDataAdapter("Select * from Antrenmanlar where a_seviyesi='kv2'", baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();
                }
            }
            else if(comboBox1.SelectedItem.ToString() == "Kilo Alma")
            {
              
                    baglanti.Open();
                    da = new SqlDataAdapter("Select * from Antrenmanlar where a_seviyesi='ka1'", baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();

             

            }
            else if (comboBox1.SelectedItem.ToString() == "Kas Kazanma")
            {
                if (indeks > 19 || indeks <25 )
                {
                    baglanti.Open();
                    da = new SqlDataAdapter("Select * from Antrenmanlar where a_seviyesi='kk1'", baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();
                }
                else if (indeks > 16 || indeks < 19)
                {

                    baglanti.Open();
                    da = new SqlDataAdapter("Select * from Antrenmanlar where a_seviyesi='kk2'", baglanti);
                    DataTable tablo = new DataTable();
                    da.Fill(tablo);
                    dataGridView1.DataSource = tablo;
                    baglanti.Close();
                }

            }


        }
    }
}
