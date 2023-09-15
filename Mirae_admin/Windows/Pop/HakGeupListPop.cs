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
    public partial class HakGeupListPop : MasterPop
    {
        public int HakGeup_Code { get; set; }

        private DataRow SelectedRowOf_DGV { get; set; }

        private bool isNotNull(object aObject)
        {
            return (aObject != null);
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public HakGeupListPop()
        {
            InitializeComponent();
            DataTable dt = App.Instance().DBManager.HakGeup.Read_ALL();
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_HakGeup, dt);
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
        
        private void dgv_Display_HakGeup_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgv_Display_HakGeup_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AssignSelectedHakGeup();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            AssignSelectedHakGeup();
        }
        void AssignSelectedHakGeup()
        {
            SelectedRowOf_DGV = GridAssist.SelectedRow(dgv_Display_HakGeup);

            if (isNotNull(SelectedRowOf_DGV))
            {
                HakGeup_Code = Convert.ToInt32(SelectedRowOf_DGV["학급코드"]);
                DialogResult = DialogResult.OK;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        #endregion

    }
}
