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
            App.Instance().MainForm.ShowView<View_일정>();
        }

        private void btn_ToCourse_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<View_수업>();
        }

        private void btn_ToStudent_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<View_학생>();
        }
        private void btn_Counsel_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<View_상담>();
        }


        private void btn_ExitProgram_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.AskExitProgram();
        }

        private void View_메인메뉴_ClientSizeChanged(object sender, EventArgs e)
        {
            List<Control> controls = new List<Control>();
            controls.Add(panel_Menu1);
            controls.Add(panel_Menu2);
            controls.Add(panel_Menu3);
            controls.Add(panel_Menu4);
            controls.Add(panel_Menu5);
            controls.Add(panel_Menu6);
            foreach (Control control in controls)
            {
                control.Size = new Size(control.Size.Width, (this.Size.Height) / controls.Count);
            }
        }

        internal void SetButtons_Login()
        {
            int Count_AssignedHakGeups = App.Instance().SessionManager.Session_Count_AssignedHakGeups;
            bool isShowMyStudents = false;
            if (Count_AssignedHakGeups > 0)
            {
                isShowMyStudents = true;
            }
            else
            {
                isShowMyStudents = false;
            }

            btn_ToStudent.Enabled = isShowMyStudents;
        }

        internal void UpdateInfo()
        {
            label_NewWaiting.Text = GetString_NewWaiting_Notification();
        }

        private string GetString_NewWaiting_Notification()
        {
            int Count_Unassigned_Waiting = App.Instance().DBManager.ReadWaiting_NumberOf_Unassigned();
            string theText;
            if (Count_Unassigned_Waiting > 0)
            {
                theText = $"새로 접수된 원서가 있습니다. ({Count_Unassigned_Waiting}) NEW";
            }
            else
            {
                theText = string.Empty ;
            }
            return theText;
        }
    }
}
