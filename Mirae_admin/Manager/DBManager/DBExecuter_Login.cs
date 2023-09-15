using Mirae_admin.Windows.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_admin.Manager.DBManager
{
    internal class DBExecuter_Login:DBExecuter_Base
    {
        public DBExecuter_Login(DBManager theDBmgr) : base(theDBmgr) { }

        public AdminLoginView.LoginAttemptCode Validate_IDisAdmin(string aID, string aPassword)
        {
            string _strQuery =
                "SELECT M.id 아이디, M.password 비밀번호, M.membergroup_code \"회원 분류 코드\" " +
                "FROM Member M " +
                $"WHERE M.id = '{aID}' ";

            DataTable dt = ReadTable(_strQuery, "Tutor");
            if (dt.Rows.Count == 0)
            { return AdminLoginView.LoginAttemptCode.IDNotExists; }
            else
            {
                DataRow dr = dt.Rows[0];
                if (aPassword != Convert.ToString(dr["비밀번호"]))
                { return AdminLoginView.LoginAttemptCode.WrongPassword; }
                if (Convert.ToInt32(dr["회원 분류 코드"]) != 1)
                { return AdminLoginView.LoginAttemptCode.LackOfAuthority; }

                return AdminLoginView.LoginAttemptCode.Valid;
            }
        }
    }
}
