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
    public partial class FrmTeacher : Form
    {
        public FrmTeacher()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmClub frc = new FrmClub();
            frc.Show();
        }

        private void BtnLesson_Click(object sender, EventArgs e)
        {
            FrmLessons frl = new FrmLessons();
            frl.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmStudent frs = new FrmStudent();
            frs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmExamNotes fre = new FrmExamNotes();
            fre.Show();
        }
    }
}
