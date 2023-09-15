using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_admin.Manager.DBManager
{
    internal class DBExecuter_HakGeup :DBExecuter_Base
    {
        public DBExecuter_HakGeup(DBManager dBManager) : base(dBManager) { }


        /// <summary>
        /// {학급코드 | 학급 | 담당 선생님 아이디 | 담당 선생님 }
        /// </summary>
        /// <returns></returns>
        public DataTable Read_ALL()
        {
            string _strQuery =
                "SELECT H.code 학급코드, H.name 학급, " +
                "T.member_id \"담당 선생님 아이디\", T.name \"담당 선생님\" " +
                "FROM Hakgeup H " +
                "LEFT JOIN Tutor T ON H.tutor_id = T.member_id " +
                "ORDER BY 학급 ASC ";

            return ReadTable(_strQuery, "Hakgeup");
        }
        public string Read_Specific_Name(int hakGeupCode)
        {
            string _strQuery =
                "SELECT H.name " +
                $"FROM HakGeup H WHERE H.code = {hakGeupCode} ";
            return Convert.ToString(ReadScalar(_strQuery));

        }

        public DataTable Read_Distinct(string aField, string aSeed)
        {
            string _strQuery =
                "SELECT H.code 학급코드 " +
                "FROM HakGeup H ";

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition(aField), aSeed);
            }
            return ReadTable(_strQuery, "HakGeup");
        }
        private string GetStringFormat_Of_QueryCondition(string aField)
        {
            return "WHERE H.code LIKE '%{0}%' ";
        }

    }
}
