using Lib.Control;
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

        DataTable DTable_SearchResult { get; set; }
        int? Current_HakGeupCode { get; set; } = null;
        
        string[] Weekday { get; } = new string[7]
        {
            "Sun","Mon","Tue","Wed","Thu","Fri","Sat"
        };

        #region <<< ScheduleView 공용 로직 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private bool isValid_TimeTableLabel(Label theLabel)
        {
            return theLabel != null && theLabel.Tag.GetType() == typeof(int[]);
        }
        private void SetTimeTableAs_DataTable(DataTable aDataTable)
        {
            ClearTimeTable();
            foreach (DataRow dr in aDataTable.Rows)
            {
                string wkday = Weekday[Convert.ToInt32(dr["요일"]) - 1];
                int period = Convert.ToInt32(dr["교시"]);
                string description = string.Format("{0}\r\n\r\n{1}", Convert.ToString(dr["과목"]), Convert.ToString(dr["담당 선생님"]));
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

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

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
                    foundLabel.DoubleClick += DoubleClick_Label_OnTimeTable;
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

        #endregion

        #region <<< 시간표 칸 클릭 델리게이트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        
        private void DoubleClick_Label_OnTimeTable(object sender, EventArgs e)
        {
            Label senderLabel = sender as Label;
            if (isValid_TimeTableLabel(senderLabel) && Current_HakGeupCode != null)
            {
                Show_CoursePop_AsSearchResult(senderLabel);
                Refresh_TimeTable_AsLatestSearchOption();
            }
        }
        private void Show_CoursePop_AsSearchResult(Label aLabel)
        {
            DataRow Current_DataRow_OfLabel = ReadCourse_Specific_WithLabelTag(aLabel);
            if (Current_DataRow_OfLabel == null)
            {
                throw new Exception("DataRow was Null");
            }

            if (Current_DataRow_OfLabel["과목"] == DBNull.Value || Current_DataRow_OfLabel["담당 선생님 아이디"] == DBNull.Value)
            {                
                App.Instance().MainForm.ShowPop<CoursePop>(ePopMode.Add, Current_DataRow_OfLabel);
            }
            else
            {
                App.Instance().MainForm.ShowPop<CoursePop>(ePopMode.Modify, Current_DataRow_OfLabel);
            }

        }
        private DataRow ReadCourse_Specific_WithLabelTag(Label senderLabel)
        {
            if (isValid_TimeTableLabel(senderLabel) && Current_HakGeupCode != null)
            {
                int[] intTag = (int[])senderLabel.Tag;
                DataRow _Result = App.Instance().DBManager.ReadCourse_Specific(Current_HakGeupCode, intTag[0] + 1, intTag[1]);
                if (_Result == null)
                {
                    _Result = DTable_SearchResult.NewRow();
                    _Result["학급코드"] = Current_HakGeupCode;
                    _Result["학급"] = App.Instance().DBManager.ReadHakGeupName((int)Current_HakGeupCode);
                    _Result["요일"] = intTag[0] + 1;
                    _Result["교시"] = intTag[1];
                }
                return _Result;
            }
            return null;
        }
        private void Refresh_TimeTable_AsLatestSearchOption()
        {
            DTable_SearchResult = ReadCourse_AsLatestSearchOption();
            SetTimeTableAs_DataTable(DTable_SearchResult);
        }
        private DataTable ReadCourse_AsLatestSearchOption()
        {
            string _Field = "학급코드";
            string _Seed = Convert.ToString(Current_HakGeupCode);
            return App.Instance().DBManager.ReadCourse(_Field, _Seed);
        }
        
        #endregion

        #region <<< 버튼 클릭 이벤트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void btn_ToMainMenu_Click(object sender, EventArgs e)
        {
            Current_HakGeupCode = null;
            ClearTimeTable();
            App.Instance().MainForm.ShowView<MainMenuView>();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            SearchCourse();
        }
        #region <<< btn_Search Logics >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        void SearchCourse()
        {

            if (isValid_CourseSearchOption_ToFind_OneAndOnly_HakGeup() == true)
            {
                DTable_SearchResult = ReadCourseBy_SearchOption();
                SetTimeTableAs_DataTable(DTable_SearchResult);
            }
        }
        private bool isValid_CourseSearchOption_ToFind_OneAndOnly_HakGeup()
        {
            if (cbox_SearchField.Visible == true)
            {
                Current_HakGeupCode = Convert.ToInt32((cbox_Seed.SelectedItem as ComboItem).Value);
                return true;
            }
            DTable_SearchResult = ReadDistinctHakGeupBy_SearchOption();
            int _numberOfResult = DTable_SearchResult.Rows.Count;
            if (_numberOfResult == 1)
            {
                Current_HakGeupCode = Convert.ToInt32(DTable_SearchResult.Rows[0]["학급코드"]);
                return true;
            }
            else if (_numberOfResult > 1)
            {
                MessageBox.Show("검색된 학급이 2개 이상입니다.", "알림");
                return false;
            }
            else
            {
                MessageBox.Show("검색된 시간표가 없습니다.", "알림");
                return false;
            }
        }
        private DataTable ReadDistinctHakGeupBy_SearchOption()
        {
            string _Field = cbox_SearchField.SelectedItem.ToString();
            string _Seed = GetSeedBy_VisibleOption();

            return App.Instance().DBManager.ReadHakGeup_Distinct(_Field, _Seed);
        }
        private DataTable ReadCourseBy_SearchOption()
        {
            string _Field = cbox_SearchField.SelectedItem.ToString();
            string _Seed = GetSeedBy_VisibleOption();
            return App.Instance().DBManager.ReadCourse(_Field, _Seed);
        }
        private string GetSeedBy_VisibleOption()
        {
            if (panel_cbox.Visible == true)
            {
                return Convert.ToString((cbox_Seed.SelectedItem as ComboItem).Value);
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

        #endregion

        #endregion

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

    }
}
