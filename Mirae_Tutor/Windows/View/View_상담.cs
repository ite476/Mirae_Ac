using Lib.Frame;
using Lib.Utility;
using Mirae_Tutor.Manager;
using Mirae_Tutor.Manager.DBManager;
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
    public partial class View_상담 : MasterView
    {
        DataRow SelectedRow { get; set; } = null;

        public View_상담()
        {
            InitializeComponent();
            INIT();
        }

        private void INIT()
        {
            panel_cbox.Visible = false;
            panel_tbox.Visible = true;
            cbox_SearchField.SelectedIndex = 0;
            cbox_Seed.SelectedIndex = 0;
        }

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<View_메인메뉴>();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchWaiting();
        }
        DataTable DTable_SearchResult { get; set; }
        void SearchWaiting()
        {
            DTable_SearchResult = ReadWaiting_BySearchOption_LimitedToSessionID();
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Waiting, DTable_SearchResult);
        }
        string Field_Latest { get; set; } = null;
        string Seed_Latest { get; set; } = null;
        private DataTable ReadWaiting_BySearchOption_LimitedToSessionID()
        {
            Field_Latest = cbox_SearchField.SelectedItem as string;
            Seed_Latest = GetSeed_AsVisibleOption();

            return App.Instance().DBManager.Waiting.Read_LimitedToSessionID(Field_Latest, Seed_Latest);
        }

        void Refresh_DGV_asLatestSearchOption()
        {
            if (Field_Latest != null)
            {
                DTable_SearchResult = App.Instance().DBManager.Waiting.Read_LimitedToSessionID(Field_Latest, Seed_Latest);
                GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Waiting, DTable_SearchResult);
            }
            else
            {
                throw new Exception("Not Been Searched Once After Loading View");
            }
        }


        private string GetSeed_AsVisibleOption()
        {
            string _Seed;
            if (panel_cbox.Visible == true)
            {
                _Seed = cbox_Seed.SelectedItem as string;
            }
            else if (panel_tbox.Visible == true)
            {
                _Seed = tbox_Seed.Text;
            }
            else
            {
                throw new Exception("ALL Seed Panels Non-Visible");
            }
            return _Seed;
        }

        private void cbox_SearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            Reset_SeedBox_All();
            Toggle_Visible_AsSearchField();
        }
        private void Reset_SeedBox_All()
        {
            cbox_Seed.SelectedIndex = 0;
            tbox_Seed.Text = string.Empty;
        }
        private void Toggle_Visible_AsSearchField()
        {
            bool isComboBox_Visible;
            if (cbox_SearchField.SelectedItem.ToString() == "상태")
            {
                isComboBox_Visible = true;
            }
            else
            {
                isComboBox_Visible = false;
            }

            panel_cbox.Visible = isComboBox_Visible;
            panel_tbox.Visible = (!isComboBox_Visible);
        }

        

        private void dgv_Display_Waiting_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgv_Display_Waiting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.RowIndex < 0) { return; }

            SelectedRow = GridAssist.SelectedRow(dgv_Display_Waiting);
            if (SelectedRow["담당 선생님 아이디"] != DBNull.Value)
            {
                ShowPop_CounselProceed();
            }
            else
            {
                상담배정();
            }
            
        }

        private void dgv_Display_Waiting_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) {
                return;
            }

            if (e.Button == MouseButtons.Right)
            {
                SelectDGVRow_ByIndex(e.RowIndex);                
                contextMenuStrip1.Show(Cursor.Position);
            }
            
        }
        private void SelectDGVRow_ByIndex(int rowIndex)
        {
            dgv_Display_Waiting.Rows[rowIndex].Selected = true;
            SelectedRow = GridAssist.SelectedRow(dgv_Display_Waiting, rowIndex);
        }        


        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedRow != null)
            {
                bool isAssigned = (SelectedRow["담당 선생님"] != DBNull.Value);
                SetContextMenu_ItemsEnableOptions(isAssigned);
            }
            else
            {
                contextMenuStrip1.Close();
            }
        }
        private void SetContextMenu_ItemsEnableOptions(bool isAssigned)
        {
            상담배정ToolStripMenuItem.Visible = (!isAssigned);
            담당취소ToolStripMenuItem.Visible = isAssigned;
            정보수정ToolStripMenuItem.Visible = isAssigned;
        }

        private void 상담배정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            상담배정();           
        }

        private void 상담배정()
        {
            string wt_ID = Convert.ToString(SelectedRow["아이디"]);
            string tt_ID = App.Instance().SessionManager.SessionID;
            int result = App.Instance().DBManager.Waiting.Modify_AssignedTutorID(wt_ID, tt_ID);
            if (result > 0)
            {
                MessageBox.Show($"{SelectedRow["이름"]} 학생에게 배정이 완료되었습니다.");
            }
            else
            {
                MessageBox.Show("상담 배정에 실패했습니다.");
            }
            Refresh_DGV_asLatestSearchOption();
        }

        private void 담당취소ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string wt_ID = Convert.ToString(SelectedRow["아이디"]);
            string tt_ID = null;
            int result = App.Instance().DBManager.Waiting.Modify_AssignedTutorID(wt_ID,tt_ID);
            if (result > 0)
            {
                MessageBox.Show("성공적으로 배정 취소 되었습니다.");
            }
            else
            {
                MessageBox.Show("배정 취소에 실패했습니다.");
            }
            Refresh_DGV_asLatestSearchOption();
        }

        private void 정보수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPop_CounselProceed();
        }
        private void ShowPop_CounselProceed()
        {
            Waiting thePersonnel = new Waiting(SelectedRow);
            if (thePersonnel != null)
            {
                DialogResult _Result = App.Instance().MainForm.ShowPop<Pop_상담>(ePopMode.Modify, thePersonnel);
                if (_Result == DialogResult.OK)
                {
                    Refresh_DGV_asLatestSearchOption();
                }
            }
        }

    }
}
