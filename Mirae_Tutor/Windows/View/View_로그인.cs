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

namespace Mirae_Tutor.Windows.View
{
    public partial class View_로그인 : MasterView
    {
        public enum LoginAttemptCode
        {
            Valid, IDNotExists, WrongPassword, LackOfAuthority
        }


        public override void Refresh_View()
        {
            tbox_ID.Text = string.Empty;
            tbox_Password.Text = string.Empty;
        }

        public View_로그인()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            AttemptLogin();
        }

        private void AttemptLogin()
        {
            if (isValid_Login()) { App.Instance().SessionManager.Login(tbox_ID.Text); }
        }
        private bool isValid_Login()
        {
            LoginAttemptCode LoginAttemptCode = App.Instance().DBManager.Login.Validate_IDisTutor(tbox_ID.Text, tbox_Password.Text);
            switch (LoginAttemptCode)
            {
                case LoginAttemptCode.Valid:
                    return true;
                case LoginAttemptCode.IDNotExists:
                case LoginAttemptCode.WrongPassword:
                    MessageBox.Show("아이디 혹은 비밀번호가 맞지 않습니다.");
                    return false;
                case LoginAttemptCode.LackOfAuthority:
                    MessageBox.Show("선생님 아이디가 아닙니다.");
                    return false;
                default:
                    throw new Exception("Login Attempt Code Corrupted");
            }
        }

        private void btn_ForDebug_Click(object sender, EventArgs e)
        {
            App.Instance().SessionManager.Login("ttr");
        }

        private void tbox_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AttemptLogin();
            }
        }
    }
}
