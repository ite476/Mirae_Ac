﻿using Lib.Frame;
using Mirae_admin.Manager;
using Mirae_admin.Manager.DBManager;
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

namespace Mirae_admin.Windows.Pop
{
    public partial class CoursePop : MasterPop
    {
        
        private Mirae_admin.Manager.DBManager.Course CourseData { get; set; } = null;
        private DataRow Recieved_DataRow { get; set; } = null;


        private string[] WeekDays { get; set; } = new string[7]
        {
             "일", "월", "화", "수", "목", "금", "토"
        };
        private string GetString_OfWeekday(int OracleWeekday)
        {
            return WeekDays[OracleWeekday - 1];
        }


        private bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }
        private bool Exist_Data(DataRow aDataRow)
        {
            return aDataRow != null && aDataRow.ItemArray.Count() > 0;
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        public CoursePop()
        {
            InitializeComponent();
            INIT_InteractiveLabels();
        }
        
        private void INIT_InteractiveLabels()
        {
            label_TutorName.MouseHover += MouseHover_InteractiveControl;
            label_TutorName.MouseLeave += MouseLeave_InteractiveControl;
        }
        private void MouseHover_InteractiveControl(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.MouseHover_InteractiveControl(sender);
        }
        private void MouseLeave_InteractiveControl(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.MouseLeave_InteractiveControl(sender);
        }

        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode,aParam);
            return base.ShowPop(aPopMode, aParam);
        }
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            PopMode = aPopMode;
            Recieved_DataRow = (aParam as DataRow);
            if (Recieved_DataRow == null)
            {
                throw new Exception("Recieved DataRow was Null");
            }

            INIT_Data(Recieved_DataRow);
            Update_ComponentAs_Data();

            switch (aPopMode)
            {
                case ePopMode.Add:
                    this.Text = "시간표 추가";
                    btn_Delete.Visible = false;
                    break;
                case ePopMode.Modify:
                    this.Text = "시간표 수정";
                    btn_Delete.Visible = true;                    
                    break;
                default:
                    DialogResult = DialogResult.Ignore; 
                    break;
            }
        }
        private void INIT_Data(DataRow aDataRow)
        {
            if (Exist_Data(aDataRow))
            {                
                CourseData = new Course(aDataRow);
                
            }
        }
        
        private void Update_ComponentAs_Data()
        {
            label_HakGeupName.Text = CourseData.HakGeup_Name;
            label_WeekDay.Text = GetString_Weekday();
            label_GyoSi.Text = GetString_GyoSi();
            tbox_SubjectName.Text = GetString_SubjectName();
            label_TutorName.Text = GetString_TutorName();
        }
        private string GetString_Weekday()
        {
            return $"{GetString_OfWeekday(CourseData.Weekday)}요일";
        }        
        private string GetString_GyoSi()
        {
            return $"{CourseData.Gyosi} 교시";
        }
        private string GetString_SubjectName()
        {
            return Exist_String(CourseData.Subject_Name) ? CourseData.Subject_Name : "";
        }
        private string GetString_TutorName()
        {
            return Exist_String(CourseData.Tutor_Name) ? CourseData.Tutor_Name : "";
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
                CourseData.Tutor_ID = tutorListPop.Tutor_ID;
                label_TutorName.Text = tutorListPop.Tutor_Name;
            }
        }
        private void tbox_SubjectName_TextChanged(object sender, EventArgs e)
        {
            if (CourseData != null)
            { CourseData.Subject_Name = (sender as TextBox).Text; }
        }

        #endregion

        #region <<< 버튼 이벤트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (Validate_EveryInput() == true)
            {
                switch (PopMode)
                {
                    case ePopMode.Add:
                        RunAndCommit_Add_ShowResult();
                        break;
                    case ePopMode.Modify:
                        RunAndCommit_Modify_ShowResult();
                        break;
                    default:
                        break;
                }
            }
        }
        private bool Validate_EveryInput()
        {
            UpdateDataAs_Input();

            //필수조건// 과목명, 담당선생님
            //길이제한// 과목명
            
            int LengthLimit = 20;
            Validator v_v = App.Instance().Validator;

            if (v_v.isValid_Necessary("과목", CourseData.Subject_Name)
                && v_v.isValid_Below_LengthLimit("과목", CourseData.Subject_Name, LengthLimit)
                && v_v.isValid_Necessary("담당 선생님", CourseData.Tutor_ID) )
            {
                return true;
            }

            return false;
        }
        private void UpdateDataAs_Input()
        {
            CourseData.Subject_Name = tbox_SubjectName.Text;
        }
        private void RunAndCommit_Add_ShowResult()
        {
            if (App.Instance().DBManager.Course.Insert(CourseData) > 0)
            {
                MessageBox.Show("데이터 기록이 성공적으로 완료되었습니다.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("데이터 기록에 실패했습니다.", "오류");
            }
        }
        private void RunAndCommit_Modify_ShowResult()
        {
            if (App.Instance().DBManager.Course.Modify(CourseData) > 0)
            {
                MessageBox.Show("데이터 수정이 성공적으로 완료되었습니다.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("데이터 수정에 실패했습니다.", "오류");
            }
        }


        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("정말로 삭제하시겠습니까?", "경고", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                int _result = App.Instance().DBManager.Course.Delete(CourseData);
                if (_result > 0)
                {
                    MessageBox.Show("성공적으로 삭제되었습니다.");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("삭제에 실패하였습니다.");
                }
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


        #endregion

        
    }
}
