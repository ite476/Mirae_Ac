using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_Tutor.Manager.DBManager
{
    internal class DBExecuter_Tutor :DBExecuter_Base
    {
        public DBExecuter_Tutor(DBManager dBManager) : base(dBManager) { }

        /// <summary>
        /// 보유 필드 : {아이디 | 이름 | 담당과목 | 성별 | 연락처 | 주소 | 사진 | 주간 수업 수 | 담당 학급 수 | 상담 학생 수}
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        public DataTable Read(string aField = null, string aSeed = null)
        {

            string _strQuery =
            #region ...
                "WITH Count_Hakgeup AS ( " +
                "SELECT tutor_id id, count(code) count_hakgeup " +
                "FROM HakGeup GROUP BY tutor_id) " +
                ", Count_Waiting AS ( " +
                "SELECT tutor_id id, count(Waiting.member_id) count_waiting " +
                "FROM Waiting GROUP BY tutor_id) " +
                ", Count_Course AS ( " +
                "SELECT tutor_id id, count(course.hakgeup_code) count_course " +
                "FROM Course GROUP BY tutor_id " +
                ") " +
                "SELECT T.member_id 아이디, T.name 이름, T.subject 담당과목, " +
                "CASE WHEN T.gender = 'M' THEN '남성' " +
                "WHEN T.gender = 'W' or T.gender = 'F' THEN '여성' " +
                "ELSE NULL END 성별, " +
                "T.contact 연락처, T.address 주소, T.picture 사진, " +
                "nvl(count_course,0) \"주간 수업 수\", nvl(count_hakgeup,0) \"담당 학급 수\", nvl(count_waiting,0) \"상담 학생 수\" " +
                "FROM Tutor T " +
                "LEFT JOIN Count_Course C ON T.member_id = C.id " +
                "LEFT JOIN Count_HakGeup H ON T.member_id = H.id " +
                "LEFT JOIN Count_Waiting W ON T.member_id = W.id ";
            #endregion

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition(aField), aSeed);
            }

            return ReadTable(_strQuery, "Tutor");
        }
        private string GetStringFormat_Of_QueryCondition(string aField)
        {
            switch (aField)
            {
                case "아이디":
                    return "WHERE T.member_id LIKE '%{0}%' ";
                case "이름":
                    return "WHERE T.name LIKE '%{0}%' ";
                case "담당과목":
                    return "WHERE T.subject LIKE '%{0}%' ";
                case "연락처":
                    return "WHERE T.contact LIKE '%{0}%' ";
                default:
                    throw new FieldNotFoundException();
            }
        }


        public string Read_Name(string tutor_id)
        {
            string _strQuery =
                "SELECT T.name " +
                $"FROM Tutor T WHERE T.member_id = '{tutor_id}' ";
            return Convert.ToString(ReadScalar(_strQuery));
        }


        public Tutor Read_Specific(string sessionID)
        {
            string _strQuery =
            #region ...
                "SELECT T.member_id 아이디, T.name 이름," +
                "CASE WHEN T.gender = 'M' THEN '남성' " +
                "WHEN T.gender = 'W' THEN '여성' " +
                "ELSE NULL END 성별," +
                "T.contact 연락처, T.address 주소, T.subject 과목, T.picture 사진 " +
                "FROM Tutor T " +
                $"WHERE T.member_id = '{sessionID}' ";
            #endregion

            DataTable dt = ReadTable(_strQuery, "Tutor");

            if (Exist_DataTable_Rows(dt))
            { return GetTutorBy_DataRow(dt.Rows[0]); }
            else
            { return null; }
        }
        private Tutor GetTutorBy_DataRow(DataRow dr)
        {
            return new Tutor(
                    GetString_FromDBValue(dr["아이디"]),
                    GetString_FromDBValue(dr["이름"]),
                    GetString_FromDBValue(dr["성별"]),
                    GetString_FromDBValue(dr["연락처"]),
                    GetString_FromDBValue(dr["주소"]),
                    GetString_FromDBValue(dr["과목"]),
                    GetString_FromDBValue(dr["사진"])
                    );
        }

        public int Modify(Tutor thePersonnel)
        {
            string _strQuery =
            #region ...
                "UPDATE Tutor SET " +
                $"name = '{thePersonnel.Name}', " +
                $"gender = {Get_DBGender(thePersonnel.Gender)}, " +
                $"contact = '{thePersonnel.Contact}', " +
                $"address = '{thePersonnel.Address}', " +
                $"subject = '{thePersonnel.Subject}', " +
                $"picture = {MakeToClobQuery(thePersonnel.Picture)} " +

                $"WHERE member_id = '{thePersonnel.Member_ID}' ";
            #endregion

            return ExecuteAndCommit(_strQuery);
        }
        public int Modify_PasswordToo(Tutor thePersonnel, string newPassword)
        {
            string _strUpdatePassword = 
                "UPDATE Member SET " +
                $"password = '{newPassword}' " +
                $"WHERE ID = '{thePersonnel.Member_ID}' ";

            string _strUpdateTutor =
                "UPDATE Tutor SET " +
                $"name = '{thePersonnel.Name}', " +
                $"gender = {Get_DBGender(thePersonnel.Gender)}, " +
                $"contact = '{thePersonnel.Contact}', " +
                $"address = '{thePersonnel.Address}', " +
                $"subject = '{thePersonnel.Subject}', " +
                $"picture  = {MakeToClobQuery(thePersonnel.Picture)} " +
                $"WHERE member_id = '{thePersonnel.Member_ID}' ";

            ArrayList arrayList = new ArrayList()
            {
                _strUpdatePassword, _strUpdateTutor
            };

            int result = ExecuteAndCommit_MultipleQueries(arrayList);
            if (result >= arrayList.Count)
            {
                return 1;
            }
            else if (result < 0)
            {
                return result;
            }
            else
            {
                return -1;
            }

        }

    }
}
