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
using MiraePro.Manager;
using MiraePro.Windows.View;

namespace MiraePro
{
    public partial class MainForm : Form
    {
        /*
         * 3.5.1 등록 절차 관리
         * 3.5.2 학생 목록 관리
         * 3.5.3 교직원 목록 관리
         * 3.5.4 수업 일정 관리
         */
        public MainForm()
        {
            InitializeComponent();
            InitializeMainForm();
            
        }

        private void InitializeMainForm()
        {
            App.Instance().MainForm = this;

            InitializeViews();
        }

        #region <<< Views >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        List<MasterView> Views { get; set; }
        void InitializeViews()
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

            ShowView(typeof(AdminLoginView));
        }
        public void ShowView(Type aType)
        {
            foreach (MasterView view in this.Views)
            {
                if (view.GetType() == aType) 
                { view.Visible = true; }
                else 
                { view.Visible = false; }
            }
        }

        internal void ExitProgram()
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
            Application.Exit();
        }
        #endregion

        private void tbnt_ToMainMenu_Click(object sender, EventArgs e)
        {
            ShowView(typeof(MainMenuView));
        }

        private void tbtn_ToStudent_Click(object sender, EventArgs e)
        {
            ShowView(typeof (StudentView));
        }

        private void tbtn_ToTutor_Click(object sender, EventArgs e)
        {
            ShowView(typeof(TutorView));
        }

        private void tbtn_ToSchedule_Click(object sender, EventArgs e)
        {
            ShowView(typeof(ScheduleView));
        }

        private void tbtn_ToCounsel_Click(object sender, EventArgs e)
        {
            ShowView(typeof(CounselView));
        }
    }
}
