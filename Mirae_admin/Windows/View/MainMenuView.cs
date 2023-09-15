using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Frame;
using Mirae_admin.Manager;

namespace Mirae_admin.Windows.View
{
    public partial class MainMenuView : MasterView
    {
        
        public void Update_Waiting_Info()
        {
            Waiting_NOW = App.Instance().DBManager.Waiting.Read_NumberOf_Unassigned();
        }

        int NumberOfWaiting;
        private int Waiting_NOW
        {
            get { return NumberOfWaiting; }
            set
            {
                NumberOfWaiting = value;
                string theString = "";
                if (NumberOfWaiting > 0) { theString = $"새로 접수된 원서가 있습니다. ({NumberOfWaiting}) NEW"; }

                label_NewWaiting.Text = theString;
            }
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public MainMenuView()
        {
            InitializeComponent();
            InitializeMainMenuView();
        }

        private void InitializeMainMenuView()
        {
           
        }

        #endregion

        #region <<< 메뉴 버튼 이벤트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void btn_ToTutor_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<TutorView>();
        }
        private void btn_ToStudent_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<StudentView>();
        }
        private void btn_ToCounsel_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<CounselView>();
        }
        private void btn_ToSchedule_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<ScheduleView>();
        }
        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ExitProgram();
        }

        #endregion

        private void MainMenuView_ClientSizeChanged(object sender, EventArgs e)
        {
            List<Control> controls = new List<Control>();
            controls.Add(panel_Menu1);
            controls.Add(panel_Menu2);
            controls.Add(panel_Menu3);
            controls.Add(panel_Menu4);
            controls.Add(panel_Menu5);
            controls.Add(panel_Menu6);
            foreach(Control control in controls)
            {
                control.Size = new Size(control.Size.Width, (this.Size.Height) / controls.Count);
            }
        }
        
    }
}
