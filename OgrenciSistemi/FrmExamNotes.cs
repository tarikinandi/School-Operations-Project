using OgrenciSistemi.DataSet1TableAdapters;
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
using System.Data.SqlClient;

namespace OgrenciSistemi
{
    public partial class FrmExamNotes : Form
    {
        public FrmExamNotes()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        int noteid;

        private void FrmExamNotes_Load(object sender, EventArgs e)
        {
            connection conn = new connection();
            SqlCommand cmd = new SqlCommand("select * from tbl_dersler", conn.sqlConnection());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbLesson.DisplayMember = "DersAd";
            CmbLesson.ValueMember = "DersId";
            CmbLesson.DataSource = dt;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NoteList(int.Parse(TxtId.Text));

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            noteid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtExam1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtExam2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtExam3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            TxtProject.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            TxtAvg.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            TxtStatus.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            
        }

        int exam1, exam2, exam3, project;
        double avg;
        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            
            exam1 = Convert.ToInt32(TxtExam1.Text);
            exam2 = Convert.ToInt32(TxtExam2.Text);
            exam3 = Convert.ToInt32(TxtExam3.Text);
            project = Convert.ToInt32(TxtProject.Text);
            avg = (exam1 + exam2 + exam3 + project) / 4;
            TxtAvg.Text = avg.ToString();
            if (avg >= 50)
            {
                TxtStatus.Text = "True";
            }
            else
            {
                TxtStatus.Text = "False";
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            ds.NoteUpdate(byte.Parse(CmbLesson.SelectedValue.ToString()), int.Parse(TxtId.Text) ,
                byte.Parse(TxtExam1.Text), byte.Parse(TxtExam2.Text), byte.Parse(TxtExam3.Text), byte.Parse(TxtProject.Text),
                byte.Parse(TxtAvg.Text), bool.Parse(TxtStatus.Text), noteid);
        }
    }
}
