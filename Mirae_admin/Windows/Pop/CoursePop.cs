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
        public CoursePop()
        {
            InitializeComponent();
        }

        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode,aParam);
            return base.ShowPop(aPopMode, aParam);
        }
        string[] WeekDays { get; set; } = new string[7]
        {
             "일", "월", "화", "수", "목", "금", "토"
        };
        DataRow Current_DataRow { get; set; } = null;
        MiraePro.Manager.DBManager.Course Data { get; set; }
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            m_PopMode = aPopMode;

            List<object> ListParam = aParam as List<object>;
            int HakGeupCode = Convert.ToInt32(ListParam[0]);
            int WeekDayOracleIndex = Convert.ToInt32(ListParam[1]);            
            int GyoSi = Convert.ToInt32(ListParam[2]);
            Current_DataRow = null;
            string WeekDay = WeekDays[WeekDayOracleIndex - 1];

            label_HakGeupName.Text = App.Instance().DBManager.ReadHakgeupName(HakGeupCode);
            label_WeekDay.Text = $"{WeekDay}요일";
            label_GyoSi.Text = $"{GyoSi} 교시";            
            tbox_SubjectName.Text = "";
            label_TutorName.Text = "";
            
            switch(aPopMode)
            {
                case ePopMode.Add:
                    Data = new MiraePro.Manager.DBManager.Course(HakGeupCode, WeekDayOracleIndex, GyoSi, null, null);
                    btn_Delete.Visible = false;
                    break;
                case ePopMode.Modify:
                    
                    btn_Delete.Visible = true;

                    Current_DataRow = (ListParam[3] as DataTable).Rows[0];
                    string SubjectName = Convert.ToString(Current_DataRow["과목"]);
                    string TutorName = Convert.ToString(Current_DataRow["담당 선생님"]);
                    Data = new MiraePro.Manager.DBManager.Course(
                        HakGeupCode, WeekDayOracleIndex, GyoSi, SubjectName, 
                        Convert.ToString(Current_DataRow["담당 선생님 아이디"])
                        );
                    tbox_SubjectName.Text = SubjectName;
                    label_TutorName.Text= TutorName;
                    break;
                default:
                    DialogResult = DialogResult.Ignore; 
                    break;
            }
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (Data.isVaild() == false)
            {
                MessageBox.Show("과목명과 담당 선생님은 필수 입력사항입니다.");
                return;
            }
            switch (m_PopMode)
            {
                case ePopMode.Add:
                    if (App.Instance().DBManager.AddCourse(Data) > 0)
                    {
                        MessageBox.Show("데이터 기록이 성공적으로 완료되었습니다.");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("데이터 기록에 실패했습니다.","오류"); 
                    }
                    break;
                case ePopMode.Modify:
                    if (App.Instance().DBManager.ModifyCourse(Data) > 0)
                    {
                        MessageBox.Show("데이터 수정이 성공적으로 완료되었습니다.");
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("데이터 수정에 실패했습니다.", "오류");
                    }
                    break;
                default:
                    break;
            }
        }

        private void label_TutorName_Click(object sender, EventArgs e)
        {
            
        }

        private void label_TutorName_DoubleClick(object sender, EventArgs e)
        {
            TutorListPop tutorListPop = new TutorListPop();
            if (tutorListPop.ShowDialog() == DialogResult.OK)
            {
                Data.Tutor_id = tutorListPop.Tutor_ID;
                label_TutorName.Text = App.Instance().DBManager.ReadTutor_Name(Data.Tutor_id);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbox_SubjectName_TextChanged(object sender, EventArgs e)
        {
            if (Data != null)
            {
                Data.name = (sender as TextBox).Text;
            }            
        }
    }
}
