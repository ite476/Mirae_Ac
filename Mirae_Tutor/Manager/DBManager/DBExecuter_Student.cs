using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_Tutor.Manager.DBManager
{
    internal class DBExecuter_Student:DBExecuter_Base
    {
        public DBExecuter_Student(DBManager dBManager) : base(dBManager) { }

        /// <summary>
        /// 보유 필드 : { 아이디 | 학생명 | 성별 | 연락처 | 주소 | 사진 | 등록일 | 학급명 | 보호자 연락처 | 출석률 | 평균 성적 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        private DataTable Read(string aField, string aSeed)
        {
            string _strQuery = GetSelectQuery();
            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_Student(aField), aSeed);
            }

            return ReadTable(_strQuery, "student");
        }
        private static string GetSelectQuery()
        {
            string _strQuery =
            #region ...
                "WITH Student_Days AS ( " +
                "SELECT member_id , " +
                "TRUNC(SYSDATE) - TRUNC(date_register) days_count " +
                "FROM Student " +
                "), Student_Attend_Rate AS ( " +
                "SELECT S.member_id, " +
                "CAST (count(C.datetime_in) / days_count AS Number(6,2) ) attend_rate " +
                "FROM Student S " +
                "JOIN Student_Days SD ON S.member_id = SD.member_id " +
                "JOIN ChoolSeok C ON S.member_id = C.student_id " +
                "GROUP BY S.member_id, S.date_register, SD.days_count " +
                "), Student_Avg_Score AS ( " +
                "SELECT member_id, CAST(AVG(korean + math + english + history + social + science) AS Number(6,2)) avg_score " +
                "FROM Student " +
                "JOIN Score ON member_id = student_id " +
                "GROUP BY member_id ) " +
                ", Student_Total_Payment As ( " +
                "SELECT member_id, sum(pay_amount) total_pay " +
                "FROM pay " +
                "JOIN student ON member_id = student_id " +
                "GROUP BY member_id ) " +
                "SELECT S.member_id \"학생 아이디\", S.name  학생, " +
                "CASE WHEN S.gender = 'M' THEN '남성' " +
                "WHEN S.gender = 'W' or S.gender = 'F' THEN '여성' " +
                "ELSE NULL END 성별, " +
                "S.contact 연락처, S.address 주소, S.picture 사진, S.date_register \"학원 등록일\", " +
                "H.code \"학급 코드\", H.name 학급, " +
                "nvl(P.member_id, '-') \"보호자 아이디\", nvl(P.contact,'-') \"보호자 연락처\", " +
                "nvl(attend_rate,0) 출석률, nvl(avg_score,0) \"평균 성적\", nvl(total_pay,0) \"총 납부액\" " +
                "FROM student S " +
                "JOIN HakGeup H ON HakGeup_code = H.code " +
                "LEFT JOIN Parent P ON parent_id = P.member_id " +
                "LEFT JOIN Student_Avg_Score SAS ON S.member_id = SAS.member_id " +
                "LEFT JOIN Student_Attend_Rate SAR ON S.member_id = SAR.member_id " +
                "LEFT JOIN Student_Total_Payment STP ON S.member_id = STP.member_id ";
            #endregion
            return _strQuery;
        }

        public Student Read_Specific(string theID)
        {
            DataTable dt = Read("학생 아이디", theID);

            if (dt != null || dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                string 아이디 = Convert.ToString(dr["학생 아이디"]);
                string 이름 = Convert.ToString(dr["학생"]);
                string 성별 = Convert.ToString(dr["성별"]);
                string 연락처 = Convert.ToString(dr["연락처"]);
                string 주소 = Convert.ToString(dr["주소"]);
                string 사진 = Convert.ToString(dr["사진"]);
                DateTime 등록일 = Convert.ToDateTime(dr["학원 등록일"]);
                int 학급코드 = Convert.ToInt32(dr["학급 코드"]);
                string 보호자아이디 = Convert.ToString(dr["보호자 아이디"]);
                string 학급명 = Convert.ToString(dr["학급"]);
                string 보호자연락처 = Convert.ToString(dr["보호자 연락처"]);
                return new Student(아이디, 이름, 성별, 연락처, 주소, 사진, 등록일, 학급코드, 보호자아이디, 학급명, 보호자연락처);
            }

            return null;


        }
        public DataTable Read_AssignedToSessionID(string aField, string aSeed)
        {
            string _strQuery = GetSelectQuery();
            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_Student(aField), aSeed);
                _strQuery += $"AND H.tutor_id = '{App.Instance().SessionManager.SessionID}' ";
            }
            else
            {
                _strQuery += $"WHERE H.tutor_id = '{App.Instance().SessionManager.SessionID}' ";
            }


            return ReadTable(_strQuery, "Student");
        }

        private string GetStringFormat_Of_QueryCondition_Student(string aField)
        {
            switch (aField)
            {
                case "아이디":
                    return "WHERE S.member_id LIKE '%{0}%' ";
                case "학생 아이디":
                    return "WHERE S.member_id = '{0}' ";
                case "학생명":
                    return "WHERE S.name LIKE '%{0}%' ";
                case "학급명":
                    return "WHERE H.code = '{0}' ";
                case "연락처":
                    return "WHERE S.contact LIKE '%{0}%' ";
                case "담당교사명":
                    return
                        "JOIN Tutor T ON H.tutor_id = T.member_id " +
                        "WHERE T.name LIKE '%{0}%' ";
                default:
                    throw new FieldNotFoundException();
            }
        }

        

        public int Insert_ByWaitingID(string aMemberID, int aHakGeupCode)
        {
            Waiting thePersonnel = DBManager.Waiting.Read_Specific(aMemberID);
            return Insert_FromWaiting(thePersonnel, aHakGeupCode);
        }
        private int Insert_FromWaiting(Waiting aPersonnel, int aHakGeupCode)
        {
            string _strUpdateMemberQuery =
                "UPDATE Member SET " +
                "membergroup_code = 4 " +
                $"WHERE id = '{aPersonnel.Member_ID}' ";
            string _strInsertStudentQuery =
                "INSERT INTO Student (" +
                GetStrigQuery_StudentFieldNames_AsWaiting(aPersonnel) +
                ") VALUES ( " +
                GetStringQuery_StudentFieldValues_AsWaiting(aPersonnel, aHakGeupCode) +
                ") ";
            string _strDeleteWaitingQuery =
                "DELETE FROM Waiting " +
                $"WHERE member_id = '{aPersonnel.Member_ID}' ";

            ArrayList _Transaction_Queries = new ArrayList
            {
                _strUpdateMemberQuery,
                _strInsertStudentQuery,
                _strDeleteWaitingQuery
            };
            int result = ExecuteAndCommit_MultipleQueries(_Transaction_Queries);
            if (result >= 3)
            {
                return 1;
            }
            else if (result < 0)
            {
                return result;
            }
            return 0;
        }
        private string GetStrigQuery_StudentFieldNames_AsWaiting(Waiting aPersonnel)
        {

            return
                "member_id, " +
                "date_register, " +
                "hakgeup_code " +
                (Exist_String(aPersonnel.Name) ? ", name " : "") +
                (Exist_String(aPersonnel.Gender) ? ", gender " : "") +
                (Exist_String(aPersonnel.Contact) ? ", contact " : "") +
                (Exist_String(aPersonnel.Address) ? ", address " : "") +
                (Exist_String(aPersonnel.Picture) ? ", picture " : "") +
                (Exist_String(aPersonnel.Parent_ID) ? ", parent_id " : "");
        }
        private string GetStringQuery_StudentFieldValues_AsWaiting(Waiting aPersonnel, int aHakGeupCode)
        {
            return
                $"'{aPersonnel.Member_ID}', " +
                $"SYSDATE, " +
                $"{aHakGeupCode} " +
                (Exist_String(aPersonnel.Name) ? $", '{aPersonnel.Name}' " : "") +
                (Exist_String(aPersonnel.Gender) ? $", {Get_DBGender(aPersonnel.Gender)} " : "") +
                (Exist_String(aPersonnel.Contact) ? $", '{aPersonnel.Contact}' " : "") +
                (Exist_String(aPersonnel.Address) ? $", '{aPersonnel.Address}' " : "") +
                (Exist_String(aPersonnel.Picture) ? $", {MakeToClobQuery(aPersonnel.Picture)} " : "") +
                (Exist_String(aPersonnel.Parent_ID) ? $", '{aPersonnel.Parent_ID}' " : "");
        }

        

    }
}
