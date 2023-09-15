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

namespace MiraePro.Windows.View
{
    public partial class MainMenuView : MasterView
    {
        public MainMenuView()
        {
            InitializeComponent();
            InitializeMainMenuView();
        }

        private void InitializeMainMenuView()
        {
           
        }

        private void btn_ToTutor_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(TutorView));
        }

        private void btn_ToStudent_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(StudentView));
        }

        private void btn_ToCounsel_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(CounselView));
        }

        private void btn_ToSchedule_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(ScheduleView));
        }

        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ExitProgram();
        }

    }
}
