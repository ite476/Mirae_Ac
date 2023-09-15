using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_admin.Manager.DBManager
{
    internal class DBExecuter_Waiting :DBExecuter_Base
    {
        public DBExecuter_Waiting(DBManager dBManager) : base(dBManager) { }

        /// <summary>
        /// { 아이디 | 이름 | 상태 | 담당 선생님 | 입학 점수 | 성별 | 연락처 | 보호자 연락처 | 주소 | 사진 | 담당 선생님 아이디 | 보호자 아이디 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <param name="cbox_Seed"></param>
        /// <returns></returns>
        public DataTable Read(string aField, string aSeed)
        {
            string _strQuery = GetQuery_Default();

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition(aField), aSeed);
            }
            _strQuery += "ORDER BY T.name ASC ";

            return ReadTable(_strQuery, "Waiting");
        }
        private string GetQuery_Default()
        {
            return "SELECT W.member_id 아이디, W.name 이름, W.step 상태, " +
            #region ...
                "T.name \"담당 선생님\", W.score \"입학 점수\", " +
                "CASE WHEN W.gender = 'M' THEN '남성' " +
                "WHEN W.gender = 'W' or W.gender = 'F' THEN '여성' " +
                "ELSE NULL END 성별, W.contact 연락처, " +
                "P.contact \"보호자 연락처\", W.address 주소, W.picture 사진, " +
                "T.member_id \"담당 선생님 아이디\", P.member_id \"보호자 아이디\" " +
                "FROM Waiting W " +
                "LEFT JOIN Parent P ON W.parent_id = P.member_id " +
                "LEFT JOIN Tutor T ON W.tutor_id = T.member_id ";
            #endregion
        }
        private string GetStringFormat_Of_QueryCondition(string aField)
        {
            switch (aField)
            {
                case "이름":
                    return "WHERE W.name LIKE '%{0}%' ";
                case "담당 선생님":
                    return "WHERE T.name LIKE '%{0}%' ";
                case "연락처":
                    return "WHERE W.contact LIKE '%{0}%' ";
                case "아이디":
                    return "WHERE W.member_id = '{0}' ";
                case "상태":
                    return "WHERE W.step = '{0}' ";
                default:
                    throw new FieldNotFoundException();
            }
        }

        
        public int Read_NumberOf_Unassigned()
        {
            string _strQuery =
                "SELECT COUNT(member_id) " +
                "FROM Waiting " +
                "WHERE tutor_id is null ";
            return Convert.ToInt32(ReadScalar(_strQuery));
        }


        public Waiting Read_Specific(string aMember_ID)
        {
            string _strQuery = GetQuery_Default() +
                $"WHERE W.member_id = '{aMember_ID}' ";

            DataTable dt = ReadTable(_strQuery, "Waiting");

            if (Exist_DataTable_Rows(dt))
            { return new Waiting(dt.Rows[0]); }
            else
            { return null; }
        }


        public int Modify(Waiting thePersonnel)
        {
            string _strQuery =
            #region ...
                "UPDATE Waiting "
            + "SET "
            + $"member_id = '{thePersonnel.Member_ID}', "
            + $"step = '{thePersonnel.Step}', "
            + $"score = " + ((thePersonnel.Score > -1) ? $"{thePersonnel.Score}, " : "NULL, ")
            + $"name = '{thePersonnel.Name}', "
            + $"gender = {Get_DBGender(thePersonnel.Gender)}, "
            + $"contact = '{thePersonnel.Contact}', "
            + $"address = '{thePersonnel.Address}', "
            + $"parent_id = " + ((Exist_String(thePersonnel.Parent_ID)) ? $"'{thePersonnel.Parent_ID}', " : "NULL, ")
            + $"tutor_id = " + ((Exist_String(thePersonnel.Tutor_ID)) ? $"'{thePersonnel.Tutor_ID}', " : "NULL, ")
            + $"picture = {MakeToClobQuery(thePersonnel.Picture)} "

            + $"WHERE member_id = '{thePersonnel.Member_ID}' ";
            #endregion

            return ExecuteAndCommit(_strQuery);
        }
    }
}
