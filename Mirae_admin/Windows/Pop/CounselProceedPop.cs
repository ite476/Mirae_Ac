using Lib.DB;
using Lib.Frame;
using Mirae_admin.Manager;
using Mirae_admin.Manager.DBManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Mirae_admin.Windows.Pop
{
    public partial class CounselProceedPop : MasterPop
    {       
        string RecievedMemberID { get; set; }        
        Waiting Data { get; set; } = null;


        

        private bool isRMB(EventArgs e)
        {
            return isRMB(e as MouseEventArgs);
        }
        private bool isRMB(MouseEventArgs e)
        {
            return e.Button == MouseButtons.Right;
        }

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public CounselProceedPop()
        {
            InitializeComponent();
            INIT_Interactive_Labels();
        }
        private void INIT_Interactive_Labels()
        {
            List<Control> Interactive_Controls = new List<Control>()
            {
                label_name,
                label_contact,
                label_score,
                label_address
            };
            foreach(Control control in Interactive_Controls)
            {
                control.MouseHover += MouseHover_InteractiveControl;
                control.MouseLeave += MouseLeave_InteractiveControl;
                control.Click += Click_Label_Show_TextBox;
            }

            label_tutor.MouseHover += MouseHover_InteractiveControl;
            label_tutor.MouseLeave += MouseLeave_InteractiveControl;
        }        
        void MouseHover_InteractiveControl(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.MouseHover_InteractiveControl(sender);
        }
        void MouseLeave_InteractiveControl(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.MouseLeave_InteractiveControl(sender);
        }
        private void Click_Label_Show_TextBox(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.Click_Label_ToShow_TextBox(sender);
        }

        public override DialogResult ShowPop(ePopMode aPopMode)
        {
            return base.ShowPop(aPopMode);
        }
        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            PopMode = aPopMode;
            InitializeAsPopMode(aParam);
            return base.ShowPop(aPopMode, aParam);
        }
        
        private void InitializeAsPopMode(object aParam)
        {
            switch (PopMode)
            {
                case ePopMode.Modify:
                    InitializeFor_Modify(aParam);
                    return;
                default:
                    throw new NotImplementedException();
            }
        }
        private void InitializeFor_Modify(object aParam)
        {
            RecievedMemberID = aParam as string;
            
            if (RecievedMemberID == null)
            {
                DialogResult = DialogResult.Ignore; 
                return;
            }

            Data = App.Instance().DBManager.Waiting.Read_Specific(RecievedMemberID);
                        
            UpdateIndicator_AsData();
        }

        private void UpdateIndicator_AsData()
        {
            cbox_step.SelectedIndex = -1;
            cbox_step.SelectedItem = Data.Step;

            cbox_gender.SelectedIndex = -1;
            cbox_gender.SelectedItem = Data.Gender;
            
            label_name.Text = GetString_OrNullValue(Data.Name, "");
            label_contact.Text = GetString_OrNullValue(Data.Contact, "");
            label_address.Text = GetString_OrNullValue(Data.Address, "");
            label_parentContact.Text = GetString_OrNullValue(Data.Parent_Contact, "");
            label_tutor.Text = GetString_OrNullValue(Data.Tutor_Name, "");
            label_score.Text = GetString_OrNullValue(Data.Score, "");
            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_picture, Data.Picture);
        }
        private string GetString_OrNullValue(object aObject, string aNull)
        {
            return (aObject != null) ? Convert.ToString(aObject) : aNull;
        }

        #endregion

        

        #region <<< 인풋 관련 이벤트 & 로직 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        
        private void label_tutor_Click(object sender, EventArgs e) { }
        private void lable_tutor_DoubleClick(object sender, EventArgs e)
        {
            UpdateTutorData_FromSearchResultPop();
        }
        private void UpdateTutorData_FromSearchResultPop()
        {
            TutorListPop tutorListPop = new TutorListPop();
            if (tutorListPop.ShowPop(ePopMode.None) == DialogResult.OK)
            {
                Data.Tutor_ID = tutorListPop.Tutor_ID;
                Data.Tutor_Name = tutorListPop.Tutor_Name;
                UpdateIndicator_AsData();
            }
        }


        private void label_parentContact_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("보호자 변경기능 미구현");
        }
        

        #endregion

        # region <<< 버튼 이벤트 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void btn_FindFile_Click(object sender, EventArgs e)
        {
            string _image_file = App.Instance().FileManager.OpenPicture();
            if (_image_file != null)
            { App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_picture, _image_file); }
        }
        private void btn_DeletePicture_Click(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_picture, null);
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (CheckValidate())
            {
                if (RunApplyFunction_ByPopMode() == true)
                {
                    DialogResult = DialogResult.OK;
                }
            }            
        }
        private bool RunApplyFunction_ByPopMode()
        {
            int _result;
            switch (PopMode)
            {
                case ePopMode.Modify:
                    UpdateDataBy_Input();                    
                    _result = App.Instance().DBManager.Waiting.Modify(Data);

                    if (_result > 0) 
                    { 
                        MessageBox.Show("수정 성공");
                        return true;
                    }
                    else 
                    { 
                        MessageBox.Show("수정 실패"); 
                    }
                    break;
                default:
                    break;
            }
            return false;
        }
        private void UpdateDataBy_Input()
        {
            string _Step = cbox_step.SelectedItem.ToString();
            int _Score = (label_score.Text != string.Empty) ? Convert.ToInt32(label_score.Text) : -1;
            string _Name = label_name.Text;
            string _Gender = cbox_gender.SelectedItem.ToString();
            string _Contact = label_contact.Text;
            string _Address = label_address.Text;
            string _Picture = GetString_OrNullValue(pbox_picture.Tag, null);
            Data = new Waiting(
                            Data.Member_ID, _Step, _Score, _Name, _Gender, _Contact, _Address, _Picture,
                            Data.Parent_ID, Data.Tutor_ID, Data.Parent_Contact, Data.Tutor_Name);
        }
        private bool CheckValidate()
        {
            int LengthLimit = 20;
            Validator v_v = App.Instance().Validator;

            //// 제약사항 목록
            // 필수 입력    // 이름
            // 길이 제한    // 이름 연락처 주소
            // 자료형 제한  // 점수 (Int)

            // 필드 순서    // 이름 점수 연락처 주소

            if (v_v.isValid_Necessary("이름", label_name.Text) 
                && v_v.isValid_Below_LengthLimit("이름", label_name.Text, LengthLimit)
                && v_v.isValid_ConvertibleTo<int>("점수",label_score.Text)
                && v_v.isValid_Below_LengthLimit("연락처", label_contact.Text, LengthLimit)
                && v_v.isValid_Below_LengthLimit("주소", label_address.Text, LengthLimit) )
            {
                return true;
            }

            return false;            
        }


        private void btn_AssignToHakGeup_Click(object sender, EventArgs e)
        {
            HakGeupListPop hakGeupListPop = new HakGeupListPop();
            if (hakGeupListPop.ShowDialog() == DialogResult.OK)
            {
                int HakGeup_Code = hakGeupListPop.HakGeup_Code;
                // Transaction Waiting -> Student
                int _Result = App.Instance().DBManager.Student.Insert_ByWaitingID(RecievedMemberID, HakGeup_Code);
                if (_Result > 0)
                {
                    string HG_Name = App.Instance().DBManager.HakGeup.Read_Specific_Name(HakGeup_Code);
                    MessageBox.Show($"{Data.Name}학생을 {HG_Name} 학급에 입학 처리 완료하였습니다.");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("입학처리에 실패하였습니다.");
                }

                
            }

        }


        #endregion

    }
}
