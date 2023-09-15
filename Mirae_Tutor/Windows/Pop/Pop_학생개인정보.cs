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
    public partial class Pop_학생개인정보 : MasterPop
    {

        Student StudentData { get; set; } = null;

        public Pop_학생개인정보()
        {
            InitializeComponent();
        }

        public override DialogResult ShowPop(ePopMode aPopMode, object aParam)
        {
            InitializePop(aPopMode, aParam);
            INIT_Value_AsData();
            return base.ShowPop(aPopMode, aParam);
        }      
        public override void InitializePop(ePopMode aPopMode = ePopMode.None, object aParam = null)
        {
            m_PopMode = aPopMode;
            string SID = Convert.ToString(aParam);
            StudentData = App.Instance().DBManager.Student.Read_Specific(SID);
            if (StudentData == null)
            {
                DialogResult = DialogResult.Ignore; return;
            }
        }

        private void INIT_Value_AsData()
        {
            label_Name.Text = StudentData.Name;
            label_HakGeupName.Text = StudentData.HakGeupName;
            label_Gender.Text = StudentData.Gender;
            label_Contact.Text = StudentData.Contact;
            label_Address.Text = StudentData.Address;
            label_ParentName_Contact.Text = 
                (StudentData.ParentID != null)?
                $"{StudentData.ParentContact}" : "-";
            
            App.Instance().ComponentManager.Set_ImageAndTag_OnPictureBox(pbox_Picture, StudentData.Picture);
        }




        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
