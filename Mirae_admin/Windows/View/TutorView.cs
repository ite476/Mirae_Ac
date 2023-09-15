using Lib.Frame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mirae_admin.Manager;
using Lib.Utility;

namespace Mirae_admin.Windows.View
{
    public partial class TutorView : MasterView
    {
        public TutorView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            panel_cbox.Visible = false;
            panel_tbox.Visible = true;
            cbox_SearchField.SelectedIndex = 0;
        }

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<MainMenuView>();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchTutor();
        }

        DataTable DTable_SearchResult;
        void SearchTutor()
        {
            string _Field = cbox_SearchField.SelectedItem as string;
            DTable_SearchResult = App.Instance().DBManager.Tutor.Read(_Field, tbox_Seed.Text);
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Tutor, DTable_SearchResult);
        }

        private void cbox_Seed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgv_Display_Tutor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }    
}
