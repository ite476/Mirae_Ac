using Lib.Frame;
using Lib.Utility;
using MiraePro.Manager;
using MiraePro.Windows.Pop;
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
            Current_HakGeupCode = null;
            INIT_SearchOption();
            INIT_cbox_Seed();
            INIT_TimeTable();
            ClearTimeTable();
        }

        int? Current_HakGeupCode { get; set; } = null;
        private void INIT_SearchOption()
        {
            tbox_Seed.Text = string.Empty;
            panel_cbox.Visible = false;
            panel_tbox.Visible = true;
            cbox_SearchField.SelectedIndex = 0;
        }
        private void INIT_cbox_Seed()
        {
            App.Instance().ComponentManager.SetCategoryCbox_WithHakgeup(cbox_Seed);
        }
        private void INIT_TimeTable()
        {
            for (int period = 1; period <= 8; period++)
            {
                for (int wkday = 0; wkday < 7; wkday++)
                {
                    Label foundLabel = GetLabelByIndex(wkday, period);
                    foundLabel.Tag = new int[] { wkday, period };
                    foundLabel.BorderStyle = BorderStyle.Fixed3D;
                    foundLabel.Click += Click_Label_OnTimeTable;
                }
            }
        }
        private void Click_Label_OnTimeTable(object sender, EventArgs e)
        {
            Label senderLabel = sender as Label;
            if (senderLabel != null && isValid_TimeTableLabel(senderLabel) && Current_HakGeupCode != null)
            {
                DTable_SearchResult = ReadCourse_Specific_WithLabelTag(senderLabel);
                List<object> Params = new List<object>
                    {
                        Current_HakGeupCode,
                        (senderLabel.Tag as int[])[0] + 1,
                        (senderLabel.Tag as int[])[1],
                        DTable_SearchResult
                    };
                if (DTable_SearchResult == null || DTable_SearchResult.Rows.Count == 0)
                {
                    if (App.Instance().MainForm.ShowPop<CoursePop>(ePopMode.Add, Params) == DialogResult.OK)
                    {
                        SearchCourse();
                    }
                }
                else if (DTable_SearchResult != null && DTable_SearchResult.Rows.Count == 1)
                {
                    if (App.Instance().MainForm.ShowPop<CoursePop>(ePopMode.Modify, Params) == DialogResult.OK)
                    {
                        SearchCourse();
                    }
                }
                else
                {
                    throw new Exception("한 시간표 블록에 여러 값이 조회됩니다.");
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
        

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            Current_HakGeupCode = null;
            ClearTimeTable();
            App.Instance().MainForm.ShowView(typeof(MainMenuView));
        }


        private void cbox_SearchField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbox_SearchField.SelectedIndex == 0)
            {
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


        string[] Weekday { get; } = new string[7]
        {
            "Sun","Mon","Tue","Wed","Thu","Fri","Sat"
        };
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchCourse();
        }

        DataTable DTable_SearchResult { get; set; }
        void SearchCourse()
        {   
            if(Check_CourseSearchOption_Validate_ToFind_OneAndOnly() == true)
            {
                DTable_SearchResult = ReadCourseBy_SearchOption();
                SetTimeTableAs_DataTable(DTable_SearchResult);
            }
        }
        
        private bool Check_CourseSearchOption_Validate_ToFind_OneAndOnly()
        {
            DTable_SearchResult = ReadDistinctCourseBy_SearchOption();
            int _numberOfResult = DTable_SearchResult.Rows.Count;
            if (_numberOfResult == 1)
            {
                Current_HakGeupCode = Convert.ToInt32( DTable_SearchResult.Rows[0]["학급코드"] );
                return true;
            }
            else if (_numberOfResult > 1)
            {
                MessageBox.Show("검색된 학급이 2개 이상입니다.", "알림");
                return false;
            }
            else
            {
                MessageBox.Show("검색된 학급이 없습니다.", "알림");
                return false;
            }
        }
        private DataTable ReadDistinctCourseBy_SearchOption()
        {
            string _Field = cbox_SearchField.SelectedItem.ToString();
            string _Seed = GetSeedBy_VisibleOption();

            return App.Instance().DBManager.ReadCourse_Distinct(_Field, _Seed);
        }
        private string GetSeedBy_VisibleOption()
        {
            if (panel_cbox.Visible == true)
            {
                return cbox_Seed.SelectedItem as string;
            }
            else if (panel_tbox.Visible == true)
            {
                return tbox_Seed.Text;
            }
            else
            {
                throw new Exception();
            }
        }

        private DataTable ReadCourseBy_SearchOption()
        {
            string _Field = cbox_SearchField.SelectedItem.ToString();
            string _Seed = GetSeedBy_VisibleOption();
            return App.Instance().DBManager.ReadCourse(_Field, _Seed);
        }
        private void SetTimeTableAs_DataTable(DataTable dTable_SearchResult)
        {
            ClearTimeTable();
            foreach(DataRow dr in DTable_SearchResult.Rows)
            {
                string wkday = Convert.ToString(dr["요일"]);
                int period = Convert.ToInt32(dr["교시"]);
                string description = string.Format("{0}\r\n\r\n{1}", Convert.ToString(dr["과목"]), Convert.ToString(dr["담당 선생님"]));
                Label Label_ToSet = GetLabelByName(wkday,period);
                Label_ToSet.Text = description;                
            }
        }

        

        

        private DataTable ReadCourse_Specific_WithLabelTag(Label senderLabel)
        {
            if (isValid_TimeTableLabel(senderLabel) && Current_HakGeupCode != null)
            {
                int[] intTag = (int[])senderLabel.Tag;                
                return App.Instance().DBManager.ReadCourse_Specific(Current_HakGeupCode, intTag[0] + 1, intTag[1]);
            }
            return null;
        }

        private bool isValid_TimeTableLabel(Label senderLabel)
        {
            return senderLabel.Tag.GetType() == typeof(int[]);
        }
    }
}
