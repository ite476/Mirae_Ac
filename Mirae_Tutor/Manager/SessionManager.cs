using Mirae_Tutor.Windows.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Manager
{
    internal class SessionManager
    {
        public string SessionName { get; set; }
        public string SessionID { get; set; }
        public int SessionGrade { get; set; }
        public int Session_Count_AssignedHakGeups { get; set; }

        bool isOnLine = false;
        public bool OnLine
        {
            get { return isOnLine; }

            set
            {
                isOnLine = value;
                if (isOnLine)
                {
                    App.Instance().MainForm.SetIcons_Login(SessionName);
                    App.Instance().MainForm.ShowView<View_메인메뉴>();
                }
                else
                {
                    SessionName = string.Empty;
                    SessionID = string.Empty;
                    App.Instance().MainForm.SetIcons_Logout();
                    App.Instance().MainForm.ShowView<View_로그인>();
                }

            }
        }

        public SessionManager() { }

        public void Login(string aID)
        {
            SessionID = aID;
            SessionName = App.Instance().DBManager.ReadTutor_Name(aID);
            Session_Count_AssignedHakGeups = App.Instance().DBManager.ReadHakGeup_Count(aID);
            OnLine = true;
        }
        public void Logout() { OnLine = false; }
    }
}
