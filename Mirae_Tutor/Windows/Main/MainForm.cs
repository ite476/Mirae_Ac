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
using Mirae_Tutor.Windows.View;

namespace Mirae_Tutor
{
    public partial class MainForm : Form
    {
        public DialogResult ShowPop<T>(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            return ShowPop(typeof(T), aPopMode, aParam);
        }
        
        public void ShowView<T>()
        {
            ShowView(typeof(T));
        }
        

        public void SetIcons_Login(string sessionName)
        {
            toolStrip_MenuIcons.Visible = true;
            tlabel_SessionName.Text = $"{sessionName} 선생님";
            
            View_메인메뉴 메인메뉴 = (GetView<View_메인메뉴>() as View_메인메뉴);
            메인메뉴.SetButtons_Login();

        }
        public MasterView GetView<T>()
        {
            return GetView(typeof(T));
        }

        public void SetIcons_Logout()
        {
            toolStrip_MenuIcons.Visible = false;
            tlabel_SessionName.Text = string.Empty;
        }

        public void UpdateInfo()
        {
            View_메인메뉴 메인메뉴 = (GetView<View_메인메뉴>() as View_메인메뉴);
            메인메뉴.UpdateInfo();
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
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public MainForm()
        {
            InitializeComponent();
            InitializeMainForm();
            Application.Idle += (sender, e) =>
            {
                App.Instance().MainForm.UpdateInfo();
            };
        }

        private void InitializeMainForm()
        {
            App.Instance().MainForm = this;
            SetIcons_Logout();
            InitializeViews();
        }
        
        private List<MasterView> Views { get; set; }
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
        
        

        void HideAllView()
        {
            foreach(MasterView view in this.Views)
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

        internal void AskExitProgram()
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            Application.Exit();
        }
        #endregion

        
        private void MainForm_Load(object sender, EventArgs e)
        {

        }

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


        private void tbtn_ToOption_Click(object sender, EventArgs e)
        {
            App.Instance().SessionManager.Logout();
        }

        
    }
}
