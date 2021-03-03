using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VeritabaniOdev
{
    public partial class Form5 : Form
    {
        public static string kyenitc;
        public static string kyenisifre;
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-BA5NEFA;Initial Catalog=vtOdev;Integrated Security=True");
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          /*  baglanti.Open();
            SqlCommand komut = new SqlCommand("select k_tc,k_sifre from Kullanıcı where k_tc='" + textBox1.Text + "'and k_sifre='" + textBox2.Text + "' and k_tur='k'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                kyenitc = textBox1.Text;
                kyenisifre = textBox2.Text;

                Form6 yeni6 = new Form6();
                yeni6.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("yanlış");
            }
            baglanti.Close();*/
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 ac = new Form1();
            ac.Show();
            this.Hide();
        }

        private void giris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select k_tc,k_sifre from Kullanıcı where k_tc='" + textBox1.Text + "'and k_sifre='" + textBox2.Text + "' and k_tur='k'", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                kyenitc = textBox1.Text;
                kyenisifre = textBox2.Text;

                Form6 yeni6 = new Form6();
                yeni6.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("yanlış");
            }
            baglanti.Close();
        }
    }
}
