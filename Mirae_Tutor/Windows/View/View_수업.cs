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
    public partial class View_수업 : MasterView
    {
        #region <<< ScheduleView 공용 로직 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public override void Refresh_View()
        {
            UpdateInfo();

            if (DTable_SearchResult == null || DTable_SearchResult.Rows.Count < 1)
            { 
                label_Wed4.Text = ("검색 결과가 없습니다.");
                label_Wed4.ForeColor = Color.Red;
            }
            else
            {
                label_Wed4.ForeColor = Color.Black;
            }

            
        }

        int TestTick = 0;
        string[] Weekday { get; } = new string[7]
        {
            "Sun","Mon","Tue","Wed","Thu","Fri","Sat"
        };

        private bool isValid_TimeTableLabel(Label theLabel)
        {
            return theLabel != null && theLabel.Tag.GetType() == typeof(int[]);
        }
        private void SetTimeTableAs_DataTable(DataTable aDataTable)
        {
            Console.WriteLine($"TestTick x {TestTick++}");
            ClearTimeTable();
            foreach (DataRow dr in aDataTable.Rows)
            {
                string wkday = Weekday[Convert.ToInt32(dr["요일"]) - 1];
                int period = Convert.ToInt32(dr["교시"]);
                string description = string.Format("{0}\r\n\r\n{1}", Convert.ToString(dr["과목"]), Convert.ToString(dr["학급"]));
                Label Label_ToSet = GetLabelByName(wkday, period);
                Label_ToSet.Text = description;
            }
        }
        Label GetLabelByIndex(int aWeekdayIndex, int aPeriod)
        {
            return GetLabelByName(Weekday[aWeekdayIndex], aPeriod);
        }
        Label GetLabelByName(string aWeekday, int aPeriod)
        {
            string Keyword = GetLabelName_ByStringInt(aWeekday, aPeriod);
            Control[] foundControls = this.Controls.Find(Keyword, true);
            if (foundControls.Length > 0)
            {
                return foundControls[0] as Label;
            }
            return null;
        }
        private string GetLabelName_ByStringInt(string aWeekday, int aPeriod)
        {
            return $"label_{aWeekday}{aPeriod}"; ;
        }
        private string GetLabelName_ByIntInt(int aWeekdayIndex, int aPeriod)
        {
            return GetLabelName_ByStringInt(Weekday[aWeekdayIndex], aPeriod);
        }

        #endregion

        public View_수업()
        {
            InitializeComponent();
            INIT_TimeTable();
            ClearTimeTable();
        }
        private void INIT_TimeTable()
        {
            for (int period = 1; period <= 8; period++)
            {
                for (int wkday = 0; wkday < 7; wkday++)
                {
                    Label foundLabel = GetLabelByIndex(wkday, period);
                    foundLabel.Tag = new int[] { wkday, period };
                    foundLabel.Font = new System.Drawing.Font("맑은 고딕", 9F);
                    foundLabel.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }


        private void ClearTimeTable()
        {
            for (int period = 1; period <= 8; period++)
            {
                for (int wkday = 0; wkday < 7; wkday++)
                {
                    Label foundLabel = GetLabelByIndex(wkday, period);
                    foundLabel.Text = string.Empty;
                }
            }
        }




        DataTable DTable_SearchResult { get; set; } = null;
        internal void UpdateInfo()
        {
            if (App.Instance().SessionManager.OnLine)
            {
                string SID = App.Instance().SessionManager.SessionID;
                DTable_SearchResult = App.Instance().DBManager.Course.Read("담당 선생님 아이디", SID);
                SetTimeTableAs_DataTable(DTable_SearchResult);
            }
        }


        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            App.Instance().MainForm.ShowView<View_메인메뉴>();
        }
    }
}
