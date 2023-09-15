using Lib.Frame;
using Mirae_Tutor.Manager;
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
    public partial class Pop_마이페이지로그인 : MasterPop
    {
        public Pop_마이페이지로그인()
        {
            InitializeComponent();
            INIT_MyPage_Login();
        }

        private void INIT_MyPage_Login()
        {
            this.ActiveControl = tbox_ID;
        }

        private void btn_ToMyPage_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        private void AttemptLogin()
        {
            if (tbox_ID.Text == App.Instance().SessionManager.SessionID &&
                            App.Instance().DBManager.Login.Validate_IDisTutor(tbox_ID.Text, tbox_Password.Text) == View.View_로그인.LoginAttemptCode.Valid)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("아이디 혹은 비밀번호가 맞지 않습니다.", "알림");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void tbox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                AttemptLogin();
            }
        }
    }
}
