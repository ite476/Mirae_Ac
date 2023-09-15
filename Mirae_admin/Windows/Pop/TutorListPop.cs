using Lib.Frame;
using Lib.Utility;
using MiraePro.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiraePro.Windows.Pop
{
    public partial class TutorListPop : MasterPop
    {
        public TutorListPop()
        {
            InitializeComponent();
            DataTable dt = App.Instance().DBManager.ReadTutor();
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Tutor,dt);
        }
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            CounselProceedPop = aParam as CounselProceedPop;
            base.InitializePop(aPopMode, aParam);
        }
        public override DialogResult ShowPop(ePopMode aPopMode)
        {
            return base.ShowPop(aPopMode);
        }
        
        DataRow SelectedRowOf_DGV { get; set; }
        CounselProceedPop CounselProceedPop { get; set; }
        private void dgv_Display_Tutor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AssignSelectedTutor();
        }
        private void btn_OK_Click(object sender, EventArgs e)
        {
            AssignSelectedTutor();
        }
        public string Tutor_ID { get; set; }
        public string Tutor_Name { get; set; }
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
        private void AssignNoTutor()
        {
            Tutor_Name = "배정 안됨";
            Tutor_ID = string.Empty;
            DialogResult = DialogResult.OK;
        }

        private bool isNotNull(DataRow selectedRowOf_DGV)
        {
            return (selectedRowOf_DGV != null);
        }

        
        private void dgv_Display_Tutor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Deselect_Click(object sender, EventArgs e)
        {
            AssignNoTutor();
        }

    }
}
