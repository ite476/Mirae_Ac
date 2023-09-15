using Lib.Control;
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

        public override void Refresh_View()
        {
            cbox_SearchField.SelectedIndex = 0;
            App.Instance().ComponentManager.SetComboBox_AssignedHakGeup_BySessionID(cbox_Seed);
            tbox_Seed.Text = string.Empty;

            SearchStudent();
        }

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<View_메인메뉴>();
        }

        
        private void dgv_Display_Student_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgv_Display_Student_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            if (e.Button == MouseButtons.Left ||
                e.Button == MouseButtons.Right)
            {
                dgv_Display_Student.Rows[e.RowIndex].Selected = true;
                CurrentRow = GridAssist.SelectedRow(dgv_Display_Student, e.RowIndex);
                
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        DataRow CurrentRow { get; set; }
        string Selected_ID
        {
            get
            {
                if (CurrentRow != null)
                {
                    return Convert.ToString(CurrentRow[0]);
                }
                return null;
            }
        }


        private void 학습정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowPop<Pop_학생시험정보_조회>(ePopMode.None, Selected_ID);
        }

        private void 개인정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowPop<Pop_학생개인정보>(ePopMode.None, Selected_ID);            
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }
        DataTable DTable_SearchResult { get; set; }
        void SearchStudent()
        {
            string _Field = cbox_SearchField.SelectedItem as string;
            string _Seed = GetSeed_ByVisibleOption();
            DTable_SearchResult = App.Instance().DBManager.Student.Read_AssignedToSessionID(_Field, _Seed);
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Student, DTable_SearchResult);
        }

        private string GetSeed_ByVisibleOption()
        {
            if (panel_cbox.Visible)
            {
                return Convert.ToString((cbox_Seed.SelectedItem as ComboItem).Value);
            }
            else if (panel_tbox.Visible)
            {
                return tbox_Seed.Text;
            }

            throw new Exception("No Seed is Visible");
        }

        private void cbox_SearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_SearchField.SelectedIndex == 0)
            {
                panel_cbox.Visible = true;
                panel_tbox.Visible = false;
            }
            else
            {
                panel_cbox.Visible = false;
                panel_tbox.Visible = true;
            }
        }
    }
}
