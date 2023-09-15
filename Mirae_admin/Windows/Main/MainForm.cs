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
using Mirae_admin.Windows.Pop;
using Mirae_admin.Windows.View;
using Mirae_Tutor.Windows.Pop.Appendix;

namespace Mirae_admin
{
    public partial class MainForm : Form
    {
        private List<MasterView> Views { get; set; }


        public void SetIcons_Login_AsSession(string aSessionName)
        {
            로그인ToolStripMenuItem.Enabled = false;
            로그아웃ToolStripMenuItem.Enabled = true;

            toolStrip_WithIcons.Enabled = true;
            tlabel_SessionName.Text = $"{aSessionName}님";
        }
        public void SetIcons_Logout()
        {
            로그인ToolStripMenuItem.Enabled = true;
            로그아웃ToolStripMenuItem.Enabled = false;

            toolStrip_WithIcons.Enabled = false;
            tlabel_SessionName.Text = string.Empty;
        }

        private void LogOut()
        {
            SetIcons_Logout();
            App.Instance().SessionManager.Logout();
        }
        


        public MainForm()
        {
            InitializeComponent();
            InitializeMainForm();
        }
        private void InitializeMainForm()
        {
            App.Instance().MainForm = this;

            
            InitializeViews();
            LogOut();
        }
        private void InitializeViews()
        {
            Views = new List<MasterView>();
            this.Views.Add(new AdminLoginView());
            this.Views.Add(new MainMenuView());
            this.Views.Add(new StudentView());
            this.Views.Add(new TutorView());
            this.Views.Add(new CounselView());
            this.Views.Add(new ScheduleView());
            foreach (MasterView view in this.Views)
            {
                view.Parent = ViewSpace;
                view.Dock = DockStyle.Fill;
                view.Visible = false;
            }

            ShowView<AdminLoginView>();
        }


        public void ShowView<T>()
        {
            ShowView(typeof(T));
        }
        private void ShowView(Type aType)
        {
            foreach (MasterView view in this.Views)
            {
                if (view.GetType() == aType) 
                { view.Visible = true; }
                else 
                { view.Visible = false; }

                if (view.GetType() == typeof(MainMenuView)) {
                    (view as MainMenuView).Update_Waiting_Info();
                }

            }
        }

        public DialogResult ShowPop<T>(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            return ShowPop(typeof(T), aPopMode, aParam);
        }
        private DialogResult ShowPop(Type PopType, ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            dynamic CurrentPop = Activator.CreateInstance(PopType);
            return CurrentPop.ShowPop(aPopMode, aParam);
        }

        public void ExitProgram()
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            Application.Exit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////




        #region <<< Button-Like Click Events >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void tbtn_ToMainMenu_Click(object sender, EventArgs e)
        {
            ShowView<MainMenuView>();
        }
        private void tbtn_ToStudent_Click(object sender, EventArgs e)
        {
            ShowView<StudentView>();
        }
        private void tbtn_ToTutor_Click(object sender, EventArgs e)
        {
            ShowView<TutorView>();
        }
        private void tbtn_ToSchedule_Click(object sender, EventArgs e)
        {
            ShowView<ScheduleView>();
        }
        private void tbtn_ToCounsel_Click(object sender, EventArgs e)
        {
            ShowView<CounselView>();
        }
        private void 개인정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPop<TutorPop>();
        }
        private void 로그아웃ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LogOut();
        }
        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogOut();
        }
        


        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<AdminLoginView>();
        }
        
        

        private void tbtn_ToOption_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                case MouseButtons.Right:
                    contextMenuStrip_SessionIcon.Show(Cursor.Position);
                    break;
                default:
                    return;
            }
        }



        #endregion

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPop<VersionInfoPop>();
        }

        private void 환경설정ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPop<SettingsPop>();
        }
    }
}
