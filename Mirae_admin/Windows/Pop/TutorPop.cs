using Lib.Frame;
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
using System.Xml.Linq;

namespace MiraePro.Windows.Pop
{
    public partial class TutorPop : MasterPop
    {
        public TutorPop()
        {
            InitializeComponent();
        }
        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode, aParam);
            return base.ShowPop(aPopMode, aParam);
        }

        MiraePro.Manager.DBManager.Tutor Data { get; set; }
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            m_PopMode = aPopMode;
            Data = App.Instance().DBManager.ReadTutor_Specific(App.Instance().SessionManager.SessionID);
            if (Data == null)
            {
                throw new Exception("DB에서 세션 사용자 정보가 발견되지 않습니다.");
            }

            switch (aPopMode)
            {
                case ePopMode.None:

                    btn_Delete.Visible = false;
                    InitComponentsValue_AsData();

                    break;
                default:
                    DialogResult = DialogResult.Ignore;
                    break;
            }
        }

        private void InitComponentsValue_AsData()
        {
            label_ID.Text = Data.Member_ID;
            tbox_Name.Text = Data.Name;
            tbox_Contact.Text = Data.Contact;
            tbox_Address.Text = Data.Address;
            tbox_Subject.Text = Data.Subject;

            switch (Data.Gender)
            {
                case "남성":
                    rbtn_Man.Checked = true; break;
                case "여성":
                    rbtn_Woman.Checked = true; break;
                default:
                    rbtn_Man.Checked = false; 
                    rbtn_Woman.Checked = false;
                    break;
            }

            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_Picture, Data.Picture);            
        }


        private void btn_FindFile_Click(object sender, EventArgs e)
        {
            string _image_file = App.Instance().FileManager.OpenPicture();
            if (_image_file != null)
            {
                App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_Picture, _image_file);
            }
        }

        private void label_Password_Click(object sender, EventArgs e)
        {
            tbox_Password.Visible = true;
            label_Password.BorderStyle = BorderStyle.None;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (CheckEverthingIsValid_Or_ShowError())
            {
                int result = App.Instance().DBManager.ModifyTutor(Data);
                if (result > 0)
                {
                    MessageBox.Show("정보를 수정하였습니다.");
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("정보 수정에 실패하였습니다.", "오류");
                }                
            }
        }
        private bool CheckEverthingIsValid_Or_ShowError()
        {
            UpdateDataAs_Input();

            int LengthLimit = 20;
            Validator Validator = App.Instance().Validator;
            if ((tbox_Password.Visible == true) && (Exist_String(Data.Name) == false))
            {
                Validator.ShowErrorMessage_NecessaryNotExist("비밀번호");
                return false;
            }

            if (isString_ExceedLength(tbox_Password.Text, LengthLimit))
            {
                Validator.ShowErrorMessage_Exceed("비밀번호", LengthLimit);
                return false;
            }
            if (isString_ExceedLength(Data.Name, LengthLimit))
            {
                Validator.ShowErrorMessage_Exceed("이름", LengthLimit);
                return false;
            }
            if (isString_ExceedLength(Data.Contact, LengthLimit))
            {
                Validator.ShowErrorMessage_Exceed("연락처", LengthLimit);
                return false;
            }
            if (isString_ExceedLength(Data.Address, LengthLimit))
            {
                Validator.ShowErrorMessage_Exceed("주소", LengthLimit);
                return false;
            }
            if (isString_ExceedLength(Data.Subject, LengthLimit))
            {
                Validator.ShowErrorMessage_Exceed("담당 업무", LengthLimit);
                return false;
            }

            return true;
        }
        private void UpdateDataAs_Input()
        {
            Data.Name = tbox_Name.Text;
            Data.Contact = tbox_Contact.Text;
            Data.Address = tbox_Address.Text;
            Data.Picture = Convert.ToString(pbox_Picture.Tag);
            Data.Subject = tbox_Subject.Text;
            Data.Gender = GetGenderAs_RadioButtion();
        }
        private string GetGenderAs_RadioButtion()
        {
            string strGender = null;
            if (rbtn_Man.Checked) { strGender = "남성"; }
            if (rbtn_Woman.Checked) { strGender = "여성"; }
            return strGender;
        }

        private bool isString_ExceedLength(string aStr, int aLength)
        {
            return Exist_String(aStr) && (aStr.Length > aLength);
        }
        private bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
