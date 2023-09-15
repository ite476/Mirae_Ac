using MiraePro.Windows.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiraePro.Manager
{
    internal class SessionManager
    {
        public string SessionName { get; set; }
        public string SessionID { get; set; }
        public int SessionGrade { get; set; }

        bool isOnLine = false;
        public bool OnLine
        {
            get { return isOnLine; }

            set { 
                isOnLine = value;
                if (isOnLine)
                {
                    App.Instance().MainForm.SetIcons_Login(SessionName);
                    App.Instance().MainForm.ShowView<MainMenuView>();
                }
                else
                {
                    SessionName = string.Empty;
                    SessionID = string.Empty;
                    App.Instance().MainForm.SetIcons_Logout();
                    App.Instance().MainForm.ShowView<AdminLoginView>();
                }
                
            }
        }

        public SessionManager() { }

        public void Login(string aID)
        {
            SessionID = aID;
            SessionName = App.Instance().DBManager.ReadTutor_Name(aID);            

            OnLine = true;
        }
        public void Logout() { OnLine = false;}
    }
}
