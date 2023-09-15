using Lib.Frame;
using MiraePro.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiraePro.Windows.Pop
{
    public partial class CoursePop : MasterPop
    {

        string[] WeekDays { get; set; } = new string[7]
        {
             "일", "월", "화", "수", "목", "금", "토"
        };
        string GetWeekday(int OracleWeekday)
        {
            return WeekDays[OracleWeekday - 1];
        }
        DataRow Recieved_DataRow { get; set; } = null;
        MiraePro.Manager.DBManager.Course Data { get; set; } = null;

        private bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public CoursePop()
        {
            InitializeComponent();
        }
        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode,aParam);
            return base.ShowPop(aPopMode, aParam);
        }
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            m_PopMode = aPopMode;
            

            List<object> ListParam = aParam as List<object>;

            
            Recieved_DataRow = null;            

            INIT_Data(ListParam);
            Update_ComponentAs_Data();

            switch (aPopMode)
            {
                case ePopMode.Add:
                    btn_Delete.Visible = false;
                    break;
                case ePopMode.Modify:                    
                    btn_Delete.Visible = true;                    
                    break;
                default:
                    DialogResult = DialogResult.Ignore; 
                    break;
            }
        }
        private void INIT_Data(List<object> listParam)
        {
            if (isValidParamList(listParam))
            {
                int HakGeupCode = Convert.ToInt32(listParam[0]);
                int WeekDayOracleIndex = Convert.ToInt32(listParam[1]);
                int GyoSi = Convert.ToInt32(listParam[2]);
                string HakGeupName = App.Instance().DBManager.ReadHakgeupName(HakGeupCode);

                string SubjectName = null;
                string Tutor_ID = null;
                string Tutor_Name = null;

                if (isDataRow_Valid(listParam[3]))
                {
                    Recieved_DataRow = (listParam[3] as DataRow);
                    SubjectName = Convert.ToString(Recieved_DataRow["과목"]);
                    Tutor_ID = Convert.ToString(Recieved_DataRow["담당 선생님 아이디"]);
                    Tutor_Name = Convert.ToString(Recieved_DataRow["담당 선생님"]);
                }

                Data = new DBManager.Course(HakGeupCode, WeekDayOracleIndex, GyoSi, SubjectName, Tutor_ID, Tutor_Name, HakGeupName);
            }
        }
        private bool isValidParamList(List<object> listParam)
        {
            return listParam != null && listParam.Count == 4;
        }
        private bool isDataRow_Valid(object Object)
        {
            return Object != null && Object.GetType() == typeof(DataRow) && (Object as DataRow).ItemArray.Length > 0;
        }
        private void Update_ComponentAs_Data()
        {
            label_HakGeupName.Text = Data.HakGeup_Name;
            label_WeekDay.Text = GetString_Weekday();
            label_GyoSi.Text = GetString_GyoSi();
            tbox_SubjectName.Text = GetString_SubjectName();
            label_TutorName.Text = GetString_TutorName();
        }
        private string GetString_Weekday()
        {
            string WeekDay = GetWeekday_ByData();
            return $"{WeekDay}요일";
        }
        private string GetWeekday_ByData()
        {
            return GetWeekday(Data.Weekday);
        }
        private string GetString_GyoSi()
        {
            return $"{Data.Gyosi} 교시";
        }
        private string GetString_SubjectName()
        {
            return Exist_String(Data.Name) ? Data.Name : "";
        }
        private string GetString_TutorName()
        {
            return Exist_String(Data.Tutor_Name) ? Data.Tutor_Name : "";
        }

        #endregion

        #region <<< 컴포넌트 정보 수정 관련 이벤트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void label_TutorName_Click(object sender, EventArgs e) { }
        private void label_TutorName_DoubleClick(object sender, EventArgs e)
        {
            ShowTutorListPop_And_FetchData();
        }
        private void ShowTutorListPop_And_FetchData()
        {
            TutorListPop tutorListPop = new TutorListPop();
            if (tutorListPop.ShowDialog() == DialogResult.OK)
            {
                Data.Tutor_id = tutorListPop.Tutor_ID;
                label_TutorName.Text = tutorListPop.Tutor_Name;
            }
        }

        private void tbox_SubjectName_TextChanged(object sender, EventArgs e)
        {
            if (Data != null)
            { Data.Name = (sender as TextBox).Text; }
        }

        #endregion

        #region <<< 버튼 이벤트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (CheckEverthingIsValid_Or_ShowError() == true)
            {
                switch (m_PopMode)
                {
                    case ePopMode.Add:
                        Try_RunAndCommit_Add();
                        break;
                    case ePopMode.Modify:
                        Try_RunAndCommit_Modify();
                        break;
                    default:
                        break;
                }
            }
        }
        private bool CheckEverthingIsValid_Or_ShowError()
        {
            UpdateDataAs_Input();

            int LengthLimit = 20;
            Validator Validator = App.Instance().Validator;

            if (Exist_String(Data.Name) == false)
            {
                Validator.ShowErrorMessage_NecessaryNotExist("과목명");
                return false;
            }
            if (Exist_String(Data.Tutor_id) == false)
            {
                Validator.ShowErrorMessage_NecessaryNotExist("담당 선생님");
                return false;
            }

            return true;
        }
        private void UpdateDataAs_Input()
        {
            Data.Name = tbox_SubjectName.Text;
        }
        private void Try_RunAndCommit_Add()
        {
            if (App.Instance().DBManager.AddCourse(Data) > 0)
            {
                MessageBox.Show("데이터 기록이 성공적으로 완료되었습니다.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("데이터 기록에 실패했습니다.", "오류");
            }
        }
        private void Try_RunAndCommit_Modify()
        {
            if (App.Instance().DBManager.ModifyCourse(Data) > 0)
            {
                MessageBox.Show("데이터 수정이 성공적으로 완료되었습니다.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("데이터 수정에 실패했습니다.", "오류");
            }
        }        

        

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion

    }
}
