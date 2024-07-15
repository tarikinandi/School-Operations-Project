using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciSistemi
{
    public partial class FrmLessons : Form
    {
        public FrmLessons()
        {
            InitializeComponent();
        }

        DataSet1TableAdapters.Tbl_DerslerTableAdapter lsn = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        private void FrmLessons_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = lsn.LessonList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lsn.LessonAdd(TxtName.Text);
            MessageBox.Show("Ders Ekleme işlemi başarılı." , "Bilgi" , MessageBoxButtons.OK , MessageBoxIcon.Information);
        }

        private void BtnList_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= lsn.LessonList();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            lsn.LessonDelete(byte.Parse(TxtId.Text));
            MessageBox.Show("Ders Silme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            lsn.LessonUpdate(TxtName.Text , byte.Parse(TxtId.Text));
            MessageBox.Show("Ders Güncelleme işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
