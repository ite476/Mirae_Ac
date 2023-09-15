using Lib.Frame;
using Lib.Utility;
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

namespace Mirae_Tutor.Windows.View
{
    public partial class View_상담 : MasterView
    {
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
        string Field_Latest { get; set; }
        string Seed_Latest { get; set; }
        private DataTable ReadWaiting_BySearchOption_LimitedToSessionID()
        {
            Field_Latest = cbox_SearchField.SelectedItem as string;
            Seed_Latest = GetSeed_AsVisibleOption();

            return App.Instance().DBManager.ReadWaiting_LimitedToSessionID(Field_Latest, Seed_Latest);
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

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }
        private void dgv_Display_Waiting_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dgv_Display_Waiting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_Display_Waiting_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgv_Display_Waiting.Rows[e.RowIndex].Selected = true;
            // TODO
            DataGridCell test;
        }

        private void dgv_Display_Waiting_MouseDown(object sender, MouseEventArgs e)
        {
            RMB_ShowContextMenu_OnDataGrid(e);
        }
        private void RMB_ShowContextMenu_OnDataGrid(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                App.Instance().MouseHitManager.Show_CMenu_At_MouseCursor(e, dgv_Display_Waiting, out SelectedRow, contextMenuStrip1);
            }
        }
        DataRow SelectedRow = null;

        private void SelectRow_OnCursor(DataGridView dgv_Display_Waiting, MouseEventArgs e)
        {
            
        }

        private void contextMenuStrip1_Opened(object sender, EventArgs e)
        {
            if (SelectedRow != null)
            {
                MessageBox.Show(Convert.ToString(SelectedRow["담당 선생님"]) + " " + Convert.ToString(SelectedRow["이름"]));
            }            
        }

        
    }
}
