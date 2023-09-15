using Mirae_Tutor.Windows.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_Tutor.Manager.DBManager
{
    internal class DBExecuter_Login : DBExecuter_Base
    {
        public DBExecuter_Login(DBManager theDBmgr) : base(theDBmgr) { }

        public View_로그인.LoginAttemptCode Validate_IDisTutor(string aID, string aPassword)
        {
            string _strQuery =
                "SELECT M.id 아이디, M.password 비밀번호, M.membergroup_code \"회원 분류 코드\" " +
                "FROM Member M " +
                $"WHERE M.id = '{aID}' ";

            DataTable dt = ReadTable(_strQuery, "Tutor");
            if (dt.Rows.Count == 0)
            { return View_로그인.LoginAttemptCode.IDNotExists; }
            else
            {
                DataRow dr = dt.Rows[0];
                if (aPassword != Convert.ToString(dr["비밀번호"]))
                { return View_로그인.LoginAttemptCode.WrongPassword; }
                if (Convert.ToInt32(dr["회원 분류 코드"]) != 1
                    && Convert.ToInt32(dr["회원 분류 코드"]) != 2)
                { return View_로그인.LoginAttemptCode.LackOfAuthority; }

                return View_로그인.LoginAttemptCode.Valid;
            }
        }
    }
}
