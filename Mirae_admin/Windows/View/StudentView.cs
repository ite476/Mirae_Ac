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
using MiraePro.Manager;
using Lib.Control;
using Lib.Utility;

namespace MiraePro.Windows.View
{
    public partial class StudentView : MasterView
    {
        public StudentView()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchStudent();
        }
        DataTable DTable_SearchResult { get; set; }
        void SearchStudent()
        {
            string _Field = cbox_SearchField.SelectedItem as string;
            string _Seed = tbox_Seed.Text;
            DTable_SearchResult = App.Instance().DBManager.ReadStudent(_Field, _Seed);
            GridAssist.SetAuto_GridView_FromSourceTable(dgv_Display_Student, DTable_SearchResult);
        }
    }
}
