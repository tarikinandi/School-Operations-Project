using OgrenciSistemi.DataSet1TableAdapters;
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
    public partial class FrmStudent : Form
    {
        public FrmStudent()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.DataTable1TableAdapter ds = new DataSet1TableAdapters.DataTable1TableAdapter();
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmStudent_Load(object sender, EventArgs e)
        {
            connection conn = new connection();
            SqlCommand cmd = new SqlCommand("select * from tbl_kulupler" , conn.sqlConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbClub.DisplayMember = "Kulupad";
            CmbClub.ValueMember = "Kulupid";
            CmbClub.DataSource = dt;    

            dataGridView1.DataSource = ds.StudentList();
        }
        string gender = "";
        private void BtnAdd_Click(object sender, EventArgs e)
        {
           
            if (rdbGirl.Checked == true)
            {
                gender = "Kız";
            }
            else if(rdbBoy.Checked == true) {
                gender = "Erkek";
            }
            ds.StudentAdd(TxtName.Text , TxtSurname.Text , byte.Parse(CmbClub.SelectedValue.ToString()) , gender);
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentList();

        }

        private void CmbClub_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.StudentUpdate(TxtName.Text , TxtSurname.Text ,byte.Parse(CmbClub.SelectedValue.ToString()) , gender , int.Parse(TxtId.Text) );
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            ds.StudentDelete(int.Parse(TxtId.Text));
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            CmbClub.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            gender = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (gender == "Kız") {
                rdbBoy.Checked = false;
                rdbGirl.Checked = true;
            }
            else if(gender == "Erkek"){
                rdbBoy.Checked=true;
                rdbGirl.Checked=false;   
            }
        }

        private void rdbGirl_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBoy.Checked == true) {
                gender = "Erkek";
            }
        }

        private void rdbBoy_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGirl.Checked == true)
            {
                gender = "Kız";
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.StudentsSearch(TxtSearch.Text);
        }
    }
}
