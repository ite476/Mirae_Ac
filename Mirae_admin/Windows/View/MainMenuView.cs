﻿using System;
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
        int NumberOfWaiting;
        private int NOW 
        {
            get { return NumberOfWaiting; }
            set { 
                NumberOfWaiting = value;
                btn_ToCounsel.Text = $"입학 신청 명단 ({NumberOfWaiting}명 배정 대기중)";
            } 
        }
        public void Update_Info()
        {
            NOW = App.Instance().DBManager.ReadWaiting_NumberOf_Unassigned();
        }

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
                control.Size = new Size(control.Size.Width, (this.Size.Height-50) / controls.Count);
            }
        }
        
    }
}
