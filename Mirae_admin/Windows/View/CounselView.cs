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
            string _Field = cbox_SearchField.SelectedItem as string;
            DTable_SearchResult = App.Instance().DBManager.ReadWaiting(_Field, tbox_Seed.Text, cbox_Seed);
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Waiting, DTable_SearchResult);
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

    }
    
}
