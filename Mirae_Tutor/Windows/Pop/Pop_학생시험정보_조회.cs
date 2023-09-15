using Lib.Frame;
using Lib.Utility;
using Mirae_Tutor.Manager;
using Mirae_Tutor.Manager.DBManager;
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
        string SID { get; set; } = null;
        Student StudentData { get; set; } = null;
        DataRow Current_DataRow { get; set; } = null;

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public Pop_학생시험정보_조회()
        {
            InitializeComponent();
        }
        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode, aParam);
            return base.ShowPop(aPopMode, aParam);
        }
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            m_PopMode = aPopMode;
            SID = Convert.ToString(aParam);
            StudentData = App.Instance().DBManager.Student.Read_Specific(SID);
            

            if (SID == null || SID.Length == 0 || StudentData == null)
            {
                DialogResult = DialogResult.Ignore;
                return;
            }

            label1.Text = $"{StudentData.Name} 학생의 시험기록";
            Refresh_DGV();
        }

        #endregion


        private void dgv_Display_Score_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex < 0) { return; }
            
            if (e.Button == MouseButtons.Left)
            {
                dgv_Display_Score.Rows[e.RowIndex].Selected = true;
                Current_DataRow = GridAssist.SelectedRow(dgv_Display_Score, e.RowIndex);
            }

            if (e.Button == MouseButtons.Right)
            {
                dgv_Display_Score.Rows[e.RowIndex].Selected = true;
                Current_DataRow = GridAssist.SelectedRow(dgv_Display_Score, e.RowIndex);

                contextMenuStrip1.Show(Cursor.Position);
            }
        }
        private void dgv_Display_Score_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        private void 수정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_TestPop_And_Refresh(ePopMode.Modify);
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Show_TestPop_And_Refresh(ePopMode.Add);
        }

        void Show_TestPop_And_Refresh(ePopMode aPopMode)
        {
            DialogResult result = App.Instance().MainForm.ShowPop<Pop_시험정보수정>(aPopMode, GetParams_ForPop());
            if (result == DialogResult.OK) { Refresh_DGV(); }
        }
        private List<object> GetParams_ForPop()
        {
            return new List<object>()
            {
                StudentData, Current_DataRow
            };
        }

        private void 삭제ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Delete_SelectedRecord_And_Refresh();
            }
        }
        void Delete_SelectedRecord_And_Refresh()
        {
            if (Current_DataRow != null)
            {
                int result = App.Instance().DBManager.Score.Delete(Score.GetScore(SID,Current_DataRow));
                if (result > 0)
                {
                    MessageBox.Show("삭제가 완료되었습니다.");
                    Refresh_DGV();
                }
                else
                {
                    MessageBox.Show("삭제에 실패했습니다.");
                }
                
            }
            
        }


        private void Refresh_DGV()
        {
            DataTable dt = App.Instance().DBManager.Score.Read_ByStudentID(SID);
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Score, dt);

            if (dt.Rows.Count == 0)
            { label_NoResult.Visible = true; }
            else
            { label_NoResult.Visible = false; }
        }

        private void dgv_Display_Score_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }

            dgv_Display_Score.Rows[e.RowIndex].Selected = true;
            Current_DataRow = GridAssist.SelectedRow(dgv_Display_Score, e.RowIndex);

            Show_TestPop_And_Refresh(ePopMode.Modify);
        }
    }
}
