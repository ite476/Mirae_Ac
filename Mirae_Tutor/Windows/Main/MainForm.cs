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
using Mirae_Tutor.Manager;
using Mirae_Tutor.Windows.Pop;
using Mirae_Tutor.Windows.Pop.Appendix;
using Mirae_Tutor.Windows.View;

namespace Mirae_Tutor
{
    public partial class MainForm : Form
    {

        private List<MasterView> Views { get; set; }

        public void ShowView<T>()
        {
            ShowView(typeof(T));
        }
        public DialogResult ShowPop<T>(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            return ShowPop(typeof(T), aPopMode, aParam);
        }

        public MasterView GetView<T>()
        {
            return GetView(typeof(T));
        }


        public void UpdateInfo()
        {
            View_메인메뉴 메인메뉴 = (GetView<View_메인메뉴>() as View_메인메뉴);
            메인메뉴.UpdateInfo();
            View_수업 수업시간표 = GetView<View_수업>() as View_수업;
            수업시간표.UpdateInfo();
        }


        public void SetIcons_Login(string sessionName)
        {
            toolStrip_MenuIcons.Visible = true;
            로그아웃ToolStripMenuItem.Enabled = true;

            로그인ToolStripMenuItem.Enabled = false;
            
            tlabel_SessionName.Text = $"{sessionName} 선생님";
            
            View_메인메뉴 메인메뉴 = (GetView<View_메인메뉴>() as View_메인메뉴);

            int Count_AssignedHakGeups = App.Instance().SessionManager.Session_Count_AssignedHakGeups;
            bool isShowMyStudents = Count_AssignedHakGeups > 0;
            tbtn_ToStudent.Enabled = isShowMyStudents;
            메인메뉴.SetButtons_Login(isShowMyStudents);
        }
        public void SetIcons_Logout()
        {
            로그인ToolStripMenuItem.Enabled = true;

            로그아웃ToolStripMenuItem.Enabled = false;            
            toolStrip_MenuIcons.Visible = false;
            tlabel_SessionName.Text = string.Empty;
        }

        public void AskExitProgram()
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        

        private DialogResult ShowPop(Type PopType, ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            dynamic CurrentPop = Activator.CreateInstance(PopType);
            return CurrentPop.ShowPop(aPopMode, aParam);
        }
        private void ShowView(Type aType)
        {
            HideAllView();
            GetView(aType).Visible = true;
            GetView(aType).Refresh_View();
        }
        private void HideAllView()
        {
            foreach (MasterView view in this.Views)
            { view.Visible = false; }
        }
        private MasterView GetView(Type aType)
        {
            foreach (MasterView view in this.Views)
            {
                if (view.GetType() == aType)
                { return view; }
            }
            return null;
        }

        private void Refresh_MainForm()
        {
            string SName = App.Instance().SessionManager.RefreshSessionName();
            SetIcons_Login(SName);
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public MainForm()
        {
            InitializeComponent();
            InitializeMainForm();
        }
        private void InitializeMainForm()
        {
            App.Instance().MainForm = this;
            SetIcons_Logout();
            InitializeViews();
        }        
        private void InitializeViews()
        {
            this.Views = new List<MasterView>();
            this.Views.Add(new View_로그인());
            this.Views.Add(new View_메인메뉴());
            this.Views.Add(new View_일정());
            this.Views.Add(new View_수업());
            this.Views.Add(new View_학생());
            this.Views.Add(new View_상담());

            foreach (MasterView view in this.Views)
            {
                view.Parent = ViewSpace;
                view.Dock = DockStyle.Fill;
                view.Visible = false;
            }

            ShowView<View_로그인>();
        }
        
        #endregion


        private void tbtn_ToMainMenu_Click(object sender, EventArgs e)
        {
            ShowView<View_메인메뉴>();
        }
        private void tbtn_ToCourse_Click(object sender, EventArgs e)
        {
            ShowView<View_수업>();
        }
        private void tbtn_ToSchedule_Click(object sender, EventArgs e)
        {
            ShowView<View_일정>();
        }
        private void tbtn_ToStudent_Click(object sender, EventArgs e)
        {
            ShowView<View_학생>();
        }
        private void tbtn_ToCounsel_Click(object sender, EventArgs e)
        {
            ShowView<View_상담>();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPop<Pop_버전정보>();
        }
        private void 환경설정ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowPop<Pop_환경설정>();
        }
        private void 로그아웃ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            App.Instance().SessionManager.Logout();
        }



        private void tbtn_ToOption_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }
        private void tbtn_ToOption_MouseDown(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Right) { contextMenuStrip1.Show(Cursor.Position); }
        }
        private void 마이페이지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Show_MyPage() == DialogResult.OK)
            {
                Refresh_MainForm();
            }
        }
        DialogResult Show_MyPage()
        {
            if (ShowPop<Pop_마이페이지로그인>() == DialogResult.OK)
            {
                return ShowPop<Pop_마이페이지>();
            }
            else
            {
                return DialogResult.Ignore;
            }
        }

        private void 로그인ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowView<View_로그인>();
        }

        private void 로그아웃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App.Instance().SessionManager.Logout();
        }

    }
}
