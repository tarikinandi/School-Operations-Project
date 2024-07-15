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
using System.Reflection;
using System.Security.Cryptography;

namespace OgrenciSistemi
{
    public partial class FrmStudentNotes : Form
    {
        public FrmStudentNotes()
        {
            InitializeComponent();
        }

        connection conn = new connection();        
        public string number;
        private void FrmStudentNotes_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select DersAd , sinav1 , sinav2 , sinav3 , proje , ortalama , durum " +
                "from Tbl_Notlar inner join Tbl_Dersler on Tbl_Dersler.DersId = Tbl_Notlar.DersId " +
                "where OgId = @p1" , conn.sqlConnection());
            cmd.Parameters.AddWithValue("@p1", number);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            SqlCommand cmd2 = new SqlCommand("Select OgAd , OgSoyad from Tbl_Notlar inner join Tbl_Ogrenci on Tbl_Ogrenci.OgId = Tbl_Notlar.OgId where tbl_NOTLAR.OgId = @p1", conn.sqlConnection());
            cmd2.Parameters.AddWithValue("@p1" , number);
            SqlDataReader dr = cmd2.ExecuteReader();
            while (dr.Read()) { 
                this.Text = dr[0] + " " + dr[1];
            }

            
        }
    }
}
