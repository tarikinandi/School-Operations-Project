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

namespace OgrenciSistemi
{
    public partial class FrmClub : Form
    {
        public FrmClub()
        {
            InitializeComponent();
        }

        connection conn = new connection();

        void list()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_kulupler where durum=1", conn.sqlConnection());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void FrmClub_Load(object sender, EventArgs e)
        {
            list();
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            list();
        }

        string durum = "1";
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("insert into tbl_kulupler (kulupad,durum) values (@p1,@p2)", conn.sqlConnection());
            cmd.Parameters.AddWithValue("@p1" , TxtName.Text);
            cmd.Parameters.AddWithValue("@p2" , durum);
            cmd.ExecuteNonQuery();
            conn.sqlConnection().Close();
            MessageBox.Show("Kulüp listeye eklendi." , "Bilgi" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            list();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.LightYellow;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[e.RowIndex ].Cells[1].Value.ToString();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update tbl_kulupler set kulupad = @d1 where kulupid = @d2", conn.sqlConnection());
            cmd.Parameters.AddWithValue("@d1" , TxtName.Text);
            cmd.Parameters.AddWithValue("@d2" , TxtId.Text);
            cmd.ExecuteNonQuery();
            conn.sqlConnection().Close();
            MessageBox.Show("Kulüp Güncellendi." , "Bilgi" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update tbl_kulupler set durum=0 where KulupId = @p1",conn.sqlConnection());
            cmd.Parameters.AddWithValue("@p1" , TxtId.Text);
            cmd.ExecuteNonQuery ();
            conn.sqlConnection().Close();
            MessageBox.Show("Kayıt Silindi." , "Bilgi" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

            
    }
}
