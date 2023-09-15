using Lib.Frame;
using Lib.Utility;
using MiraePro.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiraePro.Windows.View
{
    public partial class ScheduleView : MasterView
    {
        public ScheduleView()
        {
            InitializeComponent();
            INIT();
        }

        private void INIT()
        {
            tbox_Seed.Text = string.Empty;
            panel_cbox.Visible = false;
            panel_tbox.Visible = true;
            cbox_SearchField.SelectedIndex = 0;

            for(int period = 1; period <= 8; period++)
            {
                for (int wkday =  0; wkday < 7; wkday++)
                {
                    Label foundLabel = GetLabelByIndex(wkday, period );
                    foundLabel.Text = $"{Weekday[wkday]},{period}";
                }
            }
        }

        string[] Weekday { get; } = new string[7]
        {
            "Sun","Mon","Tue","Wed","Thu","Fri","Sat"
        };

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView(typeof(MainMenuView));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_SearchField.SelectedIndex == 0)
            {
                //cbox_Seed.SelectedIndex = 0;
                panel_cbox.Visible = true;
                panel_tbox.Visible = false;
            }
            else
            {
                tbox_Seed.Text = string.Empty;
                panel_cbox.Visible = false;
                panel_tbox.Visible = true;
            }
        }
        Label GetLabelByIndex(int WeekdayIndex, int Period)
        {
            return GetLabelByName(Weekday[WeekdayIndex], Period);
        }
        Label GetLabelByName(string aWeekday, int Period)
        {
            string Keyword = $"label_{aWeekday}{Period}";
            Control[] foundControls = this.Controls.Find(Keyword, true);
            if (foundControls.Length > 0) 
            {
                return foundControls[0] as Label;                
            }
            return null;
        }

        private void panel20_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Label found = GetLabelByName(Weekday[1],1);
            if (found != null)
            {
                found.Text = GetStringFor_TimeTable("과목", "담당 선생님");
            }
            
        }

        private string GetStringFor_TimeTable(string subject, string tutor)
        {
            return $"{subject}\r\n\r\n{tutor}";
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchCourse();
        }

        DataTable DTable_SearchResult;
        void SearchCourse()
        {
            string _Field = cbox_SearchField.SelectedItem as string;
            DTable_SearchResult = App.Instance().DBManager.ReadCourse(_Field, tbox_Seed.Text, cbox_Seed);
        }
    }
}
