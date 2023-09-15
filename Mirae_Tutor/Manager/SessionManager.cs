using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_Tutor.Manager
{
    internal class SessionManager
    {
        public string SessionName { get; set; }
        public string SessionID { get; set; }
        public int SessionGrade { get; set; }

        public bool OnLine { get; set; }

        public SessionManager() { }

        public void Login(string aName, string aID, int aGrade)
        {
            OnLine= true;
            SessionName= aName;
            SessionID= aID;
            SessionGrade = aGrade;
        }
        public void Logout() { OnLine = false;}
    }
}
