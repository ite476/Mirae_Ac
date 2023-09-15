using Lib.Frame;
using Lib.Utility;
using Mirae_admin.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_admin.Windows.Pop
{
    public partial class TutorListPop : MasterPop
    {
        public string Tutor_ID { get; set; }
        public string Tutor_Name { get; set; }

        private DataRow SelectedRowOf_DGV { get; set; }

        private bool isNotNull(object selectedRowOf_DGV)
        {
            return (selectedRowOf_DGV != null);
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public TutorListPop()
        {
            InitializeComponent();
            DataTable dt = App.Instance().DBManager.Tutor.Read();
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Tutor,dt);
        }
        
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            base.InitializePop(aPopMode, aParam);
        }

        public override DialogResult ShowPop(ePopMode aPopMode)
        {
            return base.ShowPop(aPopMode);
        }

        #endregion

        #region <<< 클릭 이벤트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


        private void dgv_Display_Tutor_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgv_Display_Tutor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AssignSelectedTutor();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            AssignSelectedTutor();
        }        
        void AssignSelectedTutor()
        {
            SelectedRowOf_DGV = GridAssist.SelectedRow(dgv_Display_Tutor);

            if (isNotNull(SelectedRowOf_DGV))
            {
                Tutor_ID = Convert.ToString(SelectedRowOf_DGV["아이디"]);
                Tutor_Name = Convert.ToString(SelectedRowOf_DGV["이름"]);
                DialogResult = DialogResult.OK;
            }
        }

        private void btn_Deselect_Click(object sender, EventArgs e)
        {
            AssignNoTutor();
        }
        private void AssignNoTutor()
        {
            Tutor_Name = string.Empty;
            Tutor_ID = string.Empty;
            DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
