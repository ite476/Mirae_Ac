using Lib.Frame;
using MiraePro.Manager;
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

namespace MiraePro.Windows.Pop
{
    public partial class CounselProceedPop : MasterPop
    {       
        string RecievedMemberID { get; set; }        
        DBManager.Waiting Data { get; set; } = null;

        #region <<< 생성자 / 초기화 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public CounselProceedPop()
        {
            InitializeComponent();
        }
        
        public override DialogResult ShowPop(ePopMode aPopMode)
        {
            return base.ShowPop(aPopMode);
        }
        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            m_PopMode = aPopMode;
            InitializeAsPopMode(aParam);
            return base.ShowPop(aPopMode, aParam);
        }
        private void InitializeAsPopMode(object aParam)
        {
            switch (m_PopMode)
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

            Data = App.Instance().DBManager.ReadWaiting_Specific(RecievedMemberID);

            

            UpdateIndicator_AsData();

        }

        private void UpdateIndicator_AsData()
        {

            cbox_step.SelectedIndex = -1;
            cbox_step.SelectedItem = Data.Step;

            cbox_gender.SelectedIndex = -1;
            cbox_gender.SelectedItem = Data.Gender;
            
            label_name.Text = GetString_OrNullValue(Data.Name, "-");
            label_contact.Text = GetString_OrNullValue(Data.Contact, "-");
            label_address.Text = GetString_OrNullValue(Data.Address, "-");
            label_parentContact.Text = GetString_OrNullValue(Data.Parent_Contact, "-");
            label_tutor.Text = GetString_OrNullValue(Data.Tutor_Name, "-");
            label_score.Text = GetString_OrNullValue(Data.Score, "-");
            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_picture, Data.Picture);
        }
        private string GetString_OrNullValue(object aObject, string aNull)
        {
            return (aObject != null) ? Convert.ToString(aObject) : aNull;
        }

        #endregion

        #region <<< 인풋 관련 이벤트 & 로직 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private void label_address_Click(object sender, EventArgs e)
        {
            ShowTextBox_OnLabel(sender as Label, tbox_address);
        }
        private void label_contact_Click(object sender, EventArgs e)
        {
            ShowTextBox_OnLabel(sender as Label, tbox_contact);
        }
        private void label_score_Click(object sender, EventArgs e)
        {
            ShowTextBox_OnLabel(sender as Label, tbox_score);
        }        
        private void label_name_Click(object sender, EventArgs e)
        {
            ShowTextBox_OnLabel(sender as Label, tbox_name);
        }
        void ShowTextBox_OnLabel(Label aLabel, TextBox aTbox)
        {            
            aTbox.Text = label_name.Text;
            aLabel.BorderStyle = BorderStyle.None;
            aTbox.Visible = true;
            aTbox.Tag = aLabel;
        }
        private void tbox_score_TextChanged(object sender, EventArgs e)
        {
            tbox_TextChanged(sender, e, "-");
        }
        void tbox_TextChanged(object sender, EventArgs e)
        {
            tbox_TextChanged(sender, e, "");
        }
        void tbox_TextChanged(object sender, EventArgs e, string strDefault)
        {
            TextBox senderTbox = (sender as TextBox);
            if (senderTbox.Tag != null)
            {
                Label tagLabel = (senderTbox.Tag as Label);
                string theText = senderTbox.Text;
                if (theText == null || theText.Length == 0)
                {
                    tagLabel.Text = strDefault;
                }
                else
                {
                    tagLabel.Text = theText;
                }
                
            }
        }        

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
            }
        }

        private void label_parentContact_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("보호자 변경기능 미구현");
        }

        private void Check_DoneEdit(object sender, KeyEventArgs e)
        {
            if (isPressEnter(e))
            {
                TextBox senderTbox = (sender as TextBox);
                if (senderTbox.Tag != null)
                {
                    Label tagLabel = (senderTbox.Tag as Label);
                    tagLabel.BorderStyle = BorderStyle.Fixed3D;
                }
                senderTbox.Visible = false;
            }
        }

        private bool isPressEnter(KeyEventArgs e)
        {
            return e.KeyCode == Keys.Enter;
        }
        private bool isRMB(EventArgs e)
        {
            return isRMB(e as MouseEventArgs);
        }
        private bool isRMB(MouseEventArgs e)
        {
            return e.Button == MouseButtons.Right;
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
                if (RunApplyFunction_ByPopMode())
                {
                    DialogResult = DialogResult.OK;
                }
            }            
        }
        private bool RunApplyFunction_ByPopMode()
        {
            int _result;
            switch (m_PopMode)
            {
                case ePopMode.Modify:
                    UpdateDataBy_Input();                    
                    _result = App.Instance().DBManager.ModifyWaiting(Data);

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
            string _Picture = pbox_picture.Tag.ToString();
            Data = new DBManager.Waiting(
                            Data.Member_ID, _Step, _Score, _Name, _Gender, _Contact, _Address, _Picture,
                            Data.Parent_ID, Data.Tutor_ID, Data.Parent_Contact, Data.Tutor_Name);
        }
        private bool CheckValidate()
        {
            //MessageBox.Show("적법성 검사 미구현, 일단 쿼리 실행함"); //TODO
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("미구현"); //TODO
        }


        #endregion

    }
}
