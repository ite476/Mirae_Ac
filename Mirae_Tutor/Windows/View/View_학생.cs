using Lib.Frame;
using Lib.Utility;
using Mirae_Tutor.Manager;
using Mirae_Tutor.Windows.Pop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Windows.View
{
    public partial class View_학생 : MasterView
    {
        public View_학생()
        {
            InitializeComponent();
        }

        private void StudentView_Load(object sender, EventArgs e)
        {

        }

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(View_메인메뉴));
        }

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { App.Instance().MouseHitManager.Show_CMenu_At_MouseCursor(e, dataGridView1, out m_CurrentDataRow, contextMenuStrip1, true); }
        }

        DataRow m_CurrentDataRow;


        private void 학습정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowPop<Pop_학생시험정보_조회>();
        }

        private void 개인정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowPop<Pop_학생개인정보>();
        }
    }
}
