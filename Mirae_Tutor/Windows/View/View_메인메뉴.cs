using Lib.Frame;
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
    public partial class View_메인메뉴 : MasterView
    {
        public View_메인메뉴()
        {
            InitializeComponent();
        }
        private void btn_ToSchedule_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(View_일정));
        }

        private void btn_ToCourse_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(View_수업));
        }

        private void btn_ToStudent_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(View_학생));
        }
        private void btn_Consultation_Click(object sender, EventArgs e)
        {

        }


        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.AskExitProgram();
        }


    }
}
