using Lib.Frame;
using Mirae_Tutor.Manager;
using Mirae_Tutor.Manager.DBManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Windows.Pop
{
    public partial class Pop_시험정보수정 : MasterPop
    {
        Student StudentData { get; set; } = null;
        DataRow Recieved_DataRow { get; set; } = null;

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        
        public Pop_시험정보수정()
        {
            InitializeComponent();            
        }

        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode, aParam);
            return base.ShowPop(aPopMode, aParam);
        }
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            m_PopMode = aPopMode;
            ePopMode ParamChecker = Validate_Param_And_SaveAsMember(aParam);
            switch (m_PopMode)
            {
                case ePopMode.Add:
                    INIT_AsAddMode(ParamChecker);
                    break;

                case ePopMode.Modify:
                    INIT_AsModifyMode(ParamChecker);
                    break;

                default:
                    throw new Exception("No ePopMode Recieved");
            }            
        }
        private ePopMode Validate_Param_And_SaveAsMember(object aParam)
        {
            if (aParam.GetType() == typeof(List<object>))
            {
                List<object> theParams = (List<object>)aParam;
                if (theParams.Count == 2
                    && theParams[0].GetType() == typeof(Student))
                {
                    StudentData = theParams[0] as Student;

                    if (theParams[1] != null && theParams[1].GetType() == typeof(DataRow))
                    {
                        Recieved_DataRow = theParams[1] as DataRow;
                        return ePopMode.Modify;
                    }
                    else
                    {
                        return ePopMode.Add;
                    }

                }
            }

            return ePopMode.None;
        }
        private void INIT_AsAddMode(ePopMode ParamChecker)
        {
            if (ParamChecker == ePopMode.None) { throw new Exception("Invalid Parameter Recieved"); }
            this.Text = $"시험 기록 추가 :: {StudentData.Name} 학생";
            cbox_TestName.SelectedIndex = 0;
        }
        private void INIT_AsModifyMode(ePopMode ParamChecker)
        {
            if (ParamChecker != ePopMode.Modify) { throw new Exception("Invalid Parameter Recieved"); }
            this.Text = $"시험 기록 수정 :: {StudentData.Name} 학생";
            cbox_TestName.SelectedItem = Convert.ToString(Recieved_DataRow["시험명"]);
            tbox_Korean.Text = Convert.ToString(Recieved_DataRow["국어"]);
            tbox_Math.Text = Convert.ToString(Recieved_DataRow["수학"]);
            tbox_English.Text = Convert.ToString(Recieved_DataRow["영어"]);
            tbox_History.Text = Convert.ToString(Recieved_DataRow["한국사"]);
            tbox_Social.Text = Convert.ToString(Recieved_DataRow["사회탐구"]);
            tbox_Science.Text = Convert.ToString(Recieved_DataRow["과학탐구"]);

            dtp_date_time.Value = Convert.ToDateTime(Recieved_DataRow["시험일자"]);
        }

        #endregion



        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (Validate_Input())
            {
                RunApply_AsPopMode();
            }
        }
        private bool Validate_Input()
        {
            //자료형제한(int)// 국어 수학 영어 한국사 사회탐구 과학탐구

            int LengthLimit = 20;
            Validator v_v = App.Instance().Validator;


            if (v_v.isValid_ConvertibleTo<int>("국어", tbox_Korean.Text)
                && v_v.isValid_ConvertibleTo<int>("수학", tbox_Math.Text)
                && v_v.isValid_ConvertibleTo<int>("영어", tbox_English.Text)
                && v_v.isValid_ConvertibleTo<int>("한국사", tbox_History.Text)
                && v_v.isValid_ConvertibleTo<int>("사회탐구", tbox_Social.Text)
                && v_v.isValid_ConvertibleTo<int>("과학탐구", tbox_Science.Text))
            {
                return true;
            }
            return false;
        }
        private void RunApply_AsPopMode()
        {
            int result = -1;
            Score theScore = GetScore_AsInput();

            switch (m_PopMode)
            {
                case ePopMode.Add:
                    Execute_Add(theScore);
                    break;

                case ePopMode.Modify:
                    Execute_Modify(theScore);
                    break;

                default: break;
            }
        }

        private Score GetScore_AsInput()
        {
            Score theScore =
                Score.Convert_ToScore(StudentData.MemberID, cbox_TestName.SelectedItem, dtp_date_time.Value, 
                tbox_Korean.Text, tbox_Math.Text, tbox_English.Text, tbox_History.Text, tbox_Social.Text, tbox_Science.Text);

            if (theScore == null)
            {
                throw new Exception("the Score is null !!");
            }

            return theScore;
        }
        private void Execute_Add(Score theScore)
        {
            int result = App.Instance().DBManager.Score.Insert(theScore);
            if (result > 0)
            {
                MessageBox.Show("기록 추가에 성공하였습니다.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("기록 추가에 실패했습니다.");
            }            
        }
        private void Execute_Modify(Score theScore)
        {
            int result = App.Instance().DBManager.Score.Modify(theScore);
            if (result > 0)
            {
                MessageBox.Show("기록 수정에 성공하였습니다.");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("기록 수정에 실패했습니다.");
            }            
        }


        
    }
}
