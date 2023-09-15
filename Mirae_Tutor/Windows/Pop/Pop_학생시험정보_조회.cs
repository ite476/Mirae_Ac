using Lib.Frame;
using Mirae_Tutor.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Windows.Pop
{
    public partial class Pop_학생시험정보_조회 : MasterPop
    {
        public Pop_학생시험정보_조회()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { App.Instance().MouseHitManager.Show_CMenu_At_MouseCursor(e, dataGridView1, out m_CurrentDataRow, contextMenuStrip1, true); }
        }

        DataRow m_CurrentDataRow;

        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowPop<Pop_시험정보수정>();
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                MessageBox.Show("삭제 기능 미구현"); // TODO
            }
        }
    }
}
