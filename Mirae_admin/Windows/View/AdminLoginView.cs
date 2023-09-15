using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lib.Frame;
using MiraePro.Manager;

namespace MiraePro.Windows.View
{
    public partial class AdminLoginView : MasterView
    {
        public AdminLoginView()
        {
            InitializeComponent();
        }


        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (isValid_Login())
            {
                App.Instance().SessionManager.Login(tbox_ID.Text);
            }
        }
        public enum LoginAttemptCode
        {
            Valid, IDNotExists, WrongPassword, LackOfAuthority
        }
        private bool isValid_Login()
        {            
            LoginAttemptCode LoginAttemptCode = App.Instance().DBManager.Check_ValidID_ForAdmin_ByDB(tbox_ID.Text, tbox_Password.Text);
            switch (LoginAttemptCode)
            {
                case LoginAttemptCode.Valid:
                    return true;
                case LoginAttemptCode.IDNotExists:
                case LoginAttemptCode.WrongPassword:
                    MessageBox.Show("아이디 혹은 비밀번호가 맞지 않습니다.");
                    return false;
                case LoginAttemptCode.LackOfAuthority:
                    MessageBox.Show("관리자 권한이 없습니다.");
                    return false;
                default:
                    throw new Exception("Login Attempt Code Corrupted");
            }
        }

        private void btn_ForDebug_Click(object sender, EventArgs e)
        {
            App.Instance().SessionManager.Login("TEST");
        }
    }
}
