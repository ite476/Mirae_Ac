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
            App.Instance().MainForm.ShowView<MainMenuView>();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchWaiting();
        }
        DataTable DTable_SearchResult { get; set; }
        void SearchWaiting()
        {
            DTable_SearchResult = ReadWaiting_BySearchOption();
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Waiting, DTable_SearchResult);
        }
        string Field_Latest { get; set; }
        string Seed_Latest { get; set; }
        private DataTable ReadWaiting_BySearchOption()
        {
            Field_Latest = cbox_SearchField.SelectedItem as string;
            Seed_Latest = GetSeed_AsVisibleOption();            

            return App.Instance().DBManager.ReadWaiting(Field_Latest, Seed_Latest);
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
            panel_tbox.Visible = (! isComboBox_Visible);
        }

        

        private void cbox_Seed_SelectedIndexChanged(object sender, EventArgs e) { }

        private void dgv_Display_Waiting_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgv_Display_Waiting_MouseClick(object sender, MouseEventArgs e)
        {
            RMB_ShowContextMenu_OnDataGrid(e);            
        }
        private void RMB_ShowContextMenu_OnDataGrid(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                App.Instance().MouseHitManager.Show_CMenu_At_MouseCursor(e, dgv_Display_Waiting, contextMenuStrip1);   
            }
        }

        private void dgv_Display_Waiting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowPop_CounselProceed();
        }
        private void cmbtn_Modify_Click(object sender, EventArgs e)
        {
            ShowPop_CounselProceed();
        }
        DataRow SelectedRowOf_DGV { get; set; }
        private void ShowPop_CounselProceed()
        {
            SelectedRowOf_DGV = GridAssist.SelectedRow(dgv_Display_Waiting);
            if (isNotNull(SelectedRowOf_DGV))
            {
                DialogResult _Result = App.Instance().MainForm.ShowPop<CounselProceedPop>(ePopMode.Modify, SelectedRowOf_DGV["아이디"].ToString());
                if(_Result == DialogResult.OK )
                {
                    Refresh_DataGridView_AsLatestSearchOption();
                }
            }
        }
        private void Refresh_DataGridView_AsLatestSearchOption()
        {
            if (Exist_String(Field_Latest) && Seed_Latest != null)
            {
                DTable_SearchResult = App.Instance().DBManager.ReadWaiting(Field_Latest, Seed_Latest);
                GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Waiting, DTable_SearchResult);
            }            
        }

        private bool Exist_String(string aString)
        {
            return aString != null && aString.Length > 0;
        }

        private bool isNotNull(object aObject)
        {
            return aObject != null;
        }

        

        private void cmbtn_AssignToHakGeup_Click(object sender, EventArgs e)
        {
            MessageBox.Show("미구현"); //TODO
        }
    }
    
}
