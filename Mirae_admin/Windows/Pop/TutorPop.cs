using Lib.Frame;
using Mirae_admin.Manager;
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

namespace Mirae_admin.Windows.Pop
{
    public partial class TutorPop : MasterPop
    {
        Mirae_admin.Manager.DBManager.Tutor Data { get; set; }

        public TutorPop()
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
            PopMode = aPopMode;
            Data = App.Instance().DBManager.Tutor.Read_Specific(App.Instance().SessionManager.SessionID);
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
            label_Password.Tag = tbox_Password;
            label_Password.BorderStyle = BorderStyle.None;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (CheckEverthingIsValid_Or_ShowError())
            {
                int result = App.Instance().DBManager.Tutor.Modify(Data);
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
            //필수조건 // 비밀번호(변경시) 이름
            //길이제한 // 비밀번호(변경시) 이름 연락처 주소 과목
            int LengthLimit = 20;
            Validator v_v = App.Instance().Validator;

            bool isPasswordValid = true;
            if (isChanging_Password())
            {
                TextBox tbox_Pwd = (TextBox)label_Password.Tag;
                isPasswordValid = v_v.isValid_Necessary("비밀번호", tbox_Pwd.Text)
                    && v_v.isValid_Below_LengthLimit("비밀번호", tbox_Pwd.Text, LengthLimit);
            }

            if (isPasswordValid
                && v_v.isValid_Necessary("이름", tbox_Name.Text)
                && v_v.isValid_Below_LengthLimit("이름", tbox_Name.Text, LengthLimit)
                && v_v.isValid_Below_LengthLimit("연락처", tbox_Contact.Text, LengthLimit)
                && v_v.isValid_Below_LengthLimit("주소", tbox_Address.Text, LengthLimit)
                && v_v.isValid_Below_LengthLimit("과목", tbox_Subject.Text, LengthLimit))
            {
                return true;
            }

            return false;            
        }

        private bool isChanging_Password()
        {
            return (tbox_Password.Visible == true);
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

        private void btn_Delete_Click(object sender, EventArgs e)
        {

        }
    }
}
