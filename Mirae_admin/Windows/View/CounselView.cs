using Lib.Frame;
using Lib.Utility;
using MiraePro.Manager;
using MiraePro.Windows.Pop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiraePro.Windows.View
{
    public partial class CounselView : MasterView
    {
        public CounselView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            panel_cbox.Visible = false;
            panel_tbox.Visible = true;
            cbox_SearchField.SelectedIndex = 0;
            cbox_Seed.SelectedIndex = 0;
        }

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(MainMenuView));
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchWaiting();
        }

        DataTable DTable_SearchResult;
        void SearchWaiting()
        {
            
            DTable_SearchResult = ReadWaiting_BySearchOption(); 
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Waiting, DTable_SearchResult);
        }

        private DataTable ReadWaiting_BySearchOption()
        {
            string _Field = cbox_SearchField.SelectedItem as string;
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
                throw new Exception();
            }
            
            return App.Instance().DBManager.ReadWaiting(_Field, _Seed);
        }

        private void cbox_SearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbox_Seed.SelectedIndex = 0;
            tbox_Seed.Text = string.Empty;

            if (cbox_SearchField.SelectedItem.ToString() == "상태")
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

        private void cbox_Seed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_Display_Waiting_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        { 
        }

        private void dgv_Display_Waiting_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                App.Instance().MouseHitManager.Show_CMenu_At_MouseCursor(e, dgv_Display_Waiting, out SelectedRowOf_DGV, contextMenuStrip1);
            }
        }

        DataRow SelectedRowOf_DGV;

        private void dgv_Display_Waiting_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) { }

        

        private void dgv_Display_Waiting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowPop_CounselProceed();
        }
        private void ShowPop_CounselProceed()
        {
            SelectedRowOf_DGV = GridAssist.SelectedRow(dgv_Display_Waiting);
            MessageBox.Show($"{SelectedRowOf_DGV["아이디"].ToString()} 선택!");

            if (isNotNull(SelectedRowOf_DGV))
            {
                App.Instance().MainForm.ShowPop<CounselProceedPop>(ePopMode.Modify, SelectedRowOf_DGV["아이디"].ToString());
            }
        }

        private bool isNotNull(object aObject)
        {
            return aObject != null;
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void cmbtn_Modify_Click(object sender, EventArgs e)
        {
            ShowPop_CounselProceed();
        }
    }
    
}
