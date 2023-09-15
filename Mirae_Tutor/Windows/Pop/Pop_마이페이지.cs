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
    public partial class Pop_마이페이지 : MasterPop
    {
        Tutor TutorData { get; set; } = null;

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public Pop_마이페이지()
        {
            InitializeComponent();
            INIT_MyPage_Values();
            INIT_InteractiveControls_Event();
        }
        private void INIT_MyPage_Values()
        {
            string SID = App.Instance().SessionManager.SessionID;
            TutorData = App.Instance().DBManager.Tutor.Read_Specific(SID);
            
            label_ID.Text = SID;
            label_Name.Text = TutorData.Name;
            label_Contact.Text = TutorData.Contact;
            label_Address.Text = TutorData.Address;
            label_Subject.Text = TutorData.Subject;
            switch (TutorData.Gender)
            {
                case "남성": 
                    rbtn_Man.Checked = true; break;
                case "여성":
                    rbtn_Woman.Checked = true; break;
                default:break;
            }
            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_Picture,TutorData.Picture);            
        }
        private void INIT_InteractiveControls_Event()
        {
            List<Control> InteractiveControls = new List<Control>()
            {
                label_Name,
                label_Contact, 
                label_Address, 
                label_Subject
            };
            foreach(Control control in InteractiveControls)
            {
                control.MouseHover += MouseHover_InteractiveControl;
                control.MouseLeave += MouseLeave_InteractiveControl;
                control.Click += Click_Label_Show_TextBox;
            }

            label_Password.MouseHover += MouseHover_InteractiveControl;
            label_Password.MouseLeave += MouseLeave_InteractiveControl;
        }


        private void MouseHover_InteractiveControl(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.MouseHover_InteractiveControl(sender);
        }
        private void MouseLeave_InteractiveControl(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.MouseLeave_InteractiveControl(sender);
        }
        private void Click_Label_Show_TextBox(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.Click_Label_Show_TextBox(sender);
        }

        private void label_Password_Click(object sender, EventArgs e)
        {
            Click_Label_ToChange_Password(sender, '●');
        }
        private void Click_Label_ToChange_Password(object sender, char? aPwdChar = null)
        {
            if (sender.GetType() != typeof(Label))
            {
                throw new Exception("Not A Label Called Click_Label_Show_TextBox");
            }
            Label senderLabel = sender as Label;
            senderLabel.Tag = ShowTextBox_OnLabel_UnClosable_WithPassChar(senderLabel, aPwdChar);
        }
        private object ShowTextBox_OnLabel_UnClosable_WithPassChar(Label aLabel, char? aPwdChar = null)
        {
            TextBox aTbox = new TextBox();

            aLabel.BorderStyle = BorderStyle.None;
            aLabel.Parent.Controls.Add(aTbox);

            if (aPwdChar != null)
            {
                aTbox.PasswordChar = (char)aPwdChar;
            }

            aTbox.Location = aLabel.Location;
            aTbox.Size = aLabel.Size;
            aTbox.Dock = DockStyle.Fill;
            aTbox.Text = "";
            aTbox.Visible = true;
            aTbox.Tag = aLabel;
            aTbox.Focus();
            aTbox.BringToFront();

            aTbox.TextChanged += App.Instance().ComponentManager.tbox_TextChanged;

            return aTbox;
        }


        #endregion
        

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (Check_ValidInput())
            {
                Update_TutorData();
                int result = TryCommit_GetResultCode();
                if (result > 0) { 
                    MessageBox.Show("수정에 성공했습니다.");
                    DialogResult = DialogResult.OK;
                } else {
                    MessageBox.Show("수정에 실패했습니다."); 
                }
                
            }
        }

        private int TryCommit_GetResultCode()
        {
            if (isChanging_Password())
            {
                return App.Instance().DBManager.Tutor.Modify_PasswordToo(TutorData, (label_Password.Tag as TextBox).Text);
            }
            else
            {
                return App.Instance().DBManager.Tutor.Modify(TutorData);
            }
        }

        private void Update_TutorData()
        {
            TutorData.Name = label_Name.Text;
            TutorData.Gender =
                rbtn_Man.Checked ? "남성" : (rbtn_Woman.Checked ? "여성" : null);
            TutorData.Contact = label_Contact.Text;
            TutorData.Address = label_Address.Text;
            TutorData.Subject = label_Subject.Text;
            TutorData.Picture = Convert.ToString(pbox_Picture.Tag);
            // 비밀번호 이름 성별 연락처 주소 과목 사진
        }
        #region <<< Validate Methods >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private bool Check_ValidInput()
        {
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
                && v_v.isValid_Necessary("이름", label_Name)
                && v_v.isValid_Below_LengthLimit("이름", label_Name, LengthLimit)
                && v_v.isValid_Below_LengthLimit("연락처", label_Contact, LengthLimit)
                && v_v.isValid_Below_LengthLimit("주소", label_Address, LengthLimit)
                && v_v.isValid_Below_LengthLimit("과목", label_Subject, LengthLimit))
            {
                return true;
            }

            return false;
        }       
        private bool isChanging_Password()
        {
            return label_Password.Tag != null && label_Password.Tag.GetType() == typeof(TextBox);
        }

        #endregion

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btn_FindFile_Click(object sender, EventArgs e)
        {
            string strPicture = App.Instance().FileManager.OpenPicture();
            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_Picture, strPicture);
        }

        private void btn_ErasePicture_Click(object sender, EventArgs e)
        {
            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_Picture, null);
        }
    }
}
