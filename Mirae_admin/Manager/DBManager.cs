using Lib.Control;
using Lib.DB;
using MiraePro.Windows.Pop;
using MiraePro.Windows.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MiraePro.Manager
{
    class DBManager
    {
        class FieldNotFoundException : Exception
        {
            public FieldNotFoundException() : base("검색하려는 필드 명이 설정되지 않았습니다. ") { }
        }

        #region <<< 멤버 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        private OracleAssist m_OracleAssist { get; set; }
        #endregion

        #region <<< 공통기능 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        public void SetConnectInfo(string aAddr, int aPort, string aId, string aPwd, string aDataBase)
        {
            m_OracleAssist = new OracleAssist(aAddr, aPort, aId, aPwd, aDataBase);
        }

        public int GetSequence(string aSequence)
        {
            string _strQuery = $"SELECT {aSequence}.nextval FROM DUAL ";
            return Convert.ToInt32(ReadScalar(_strQuery));
        }
        


        //4000자 이상 문자열 ToClob으로 처리하기
        private string MakeToClobQuery(string aSrc)
        {
            return MakeToClobQuery(aSrc, 4000);
        }
        private string MakeToClobQuery(string aSrc, int aBlock)
        {
            string _result = "";
            if (aSrc == null || aSrc.Length == 0)
            {
                _result = "''";
            }
            else
            {
                int _len = aSrc.Length;
                int _count = (_len + aBlock - 1) / aBlock;
                for (int _idx = 0; _idx < _count; _idx++)
                {
                    if (_result.Length > 0) { _result += "||"; }
                    int _start = _idx * aBlock;
                    int _size = _len - _start;
                    if (_size > aBlock) { _size = aBlock; }
                    _result += string.Format(" TO_CLOB('{0}') "
                        , aSrc.Substring(_start, _size));

                }
            }
            return _result;
        }        
        private DataTable ReadTable(string aQuery, string aTableName)
        {
            DataTable _dt = null;
            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null)
            {
                return null;
            }
            else
            {
                _dt = m_OracleAssist.SelectQuery(_Connection, aQuery, aTableName);
            }
            return _dt;
        }
        private object ReadScalar(string aQuery)
        {
            DbConnection _Connection = m_OracleAssist.NewConnection();
            if (_Connection == null)
            {
                return -999;
            }
            else
            {
                return m_OracleAssist.ExcuteScalar(_Connection, aQuery);
            }
        }
        private int ExecuteAndCommit(string aQuery)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                return m_OracleAssist.ExcuteQuery(aQuery);
            }
        }
        private int ExecuteAndCommit_MultipleQueries(ArrayList Queries)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                return m_OracleAssist.ExcuteArrayQuery(Queries);
            }
            
        }
        
        private string Get_DBGender(string gender)
        {
            switch (gender)
            {
                case "남성":
                    return "'M'";
                case "여성":
                    return "'W'";
                default:
                    return "NULL";
            }
        }

        private bool Exist_DataTable_Rows(DataTable dt)
        {
            return dt != null && dt.Rows != null && dt.Rows.Count > 0;
        }
        private string GetString_FromDBValue(object DBValue)
        {
            if (DBValue == DBNull.Value)
            {
                return null;
            }
            else
            {
                return Convert.ToString(DBValue);
            }
        }
        private int? GetInt_FromDBValue(object DBValue)
        {
            if (DBValue == DBNull.Value)
            {
                return null;
            }
            else
            {
                return Convert.ToInt32(DBValue);
            }
        }

        private string Get_DBString_OrNull(string String_DBValue)
        {
            return (Exist_String(String_DBValue) ? $"'{String_DBValue}' " : "NULL ");
        }
        private bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }

        #endregion

        #region <<< 로그인 기능용 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        
        internal AdminLoginView.LoginAttemptCode Check_ValidID_ForAdmin_ByDB(string aID, string aPassword)
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

        #endregion

        #region <<< 학생 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 보유 필드 : { 아이디 | 학생명 | 성별 | 연락처 | 주소 | 사진 | 등록일 | 학급명 | 보호자 연락처 | 출석률 | 평균 성적 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        public DataTable ReadStudent(string aField, string aSeed)
        {
            
            string _strQuery = 
            #region ...
                "WITH Student_Attend_Rate AS ( " + 
                    "SELECT member_id, 0 attend_rate " +
                    "FROM Student " +
                    "JOIN ChoolSeok ON member_id = student_id " +
                    "GROUP BY member_id ) " +
                ", Student_Avg_Score AS ( " +
                    "SELECT member_id, avg(korean + math + english + history + social + science) avg_score " +
                    "FROM Student " +
                    "JOIN Score ON member_id = student_id " +
                    "GROUP BY member_id ) " +
                ", Student_Total_Payment As ( " +
                    "SELECT member_id, sum(pay_amount) total_pay " +
                    "FROM pay JOIN student ON member_id = student_id " +
                    "GROUP BY member_id ) " +
                "SELECT S.member_id 아이디, S.name 학생명, " +
                    "CASE WHEN S.gender = 'M' THEN '남성' " +
                    "WHEN S.gender = 'W' or S.gender = 'F' THEN '여성' " +
                    "ELSE NULL END 성별, " +
                    "S.contact 연락처, S.address 주소, S.picture 사진, S.date_register 등록일, H.name 학급명, " +
                    "nvl(P.contact,'-') \"보호자 연락처\", nvl(attend_rate,0) 출석률, " +
                    "nvl(avg_score,0) \"평균 성적\", nvl(total_pay,0) \"총 납부액\" " +
                "FROM student S " +
                "JOIN HakGeup H ON HakGeup_code = H.code " +
                "LEFT JOIN Parent P ON parent_id = P.member_id " +
                "LEFT JOIN Student_Avg_Score SAS ON S.member_id = SAS.member_id " +
                "LEFT JOIN Student_Attend_Rate SAR ON S.member_id = SAR.member_id " +
                "LEFT JOIN Student_Total_Payment STP ON S.member_id = STP.member_id ";
            #endregion

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_Student(aField), aSeed);
            }

            return ReadTable(_strQuery, "student");
        }                
        private string GetStringFormat_Of_QueryCondition_Student(string aField)
        {
            switch (aField)
            {
                case "아이디":
                    return "WHERE S.member_id LIKE '%{0}%' ";
                case "학생명":
                    return "WHERE S.name LIKE '%{0}%' ";
                case "학급명":
                    return "WHERE H.name LIKE '%{0}%' ";
                case "담당교사명":
                    return 
                        "JOIN Tutor T ON H.tutor_id = T.member_id " +
                        "WHERE T.name LIKE '%{0}%' ";
                default:
                    throw new FieldNotFoundException();
            }
        }

        public int AddStudent_FromWaiting(string aMemberID, int aHakGeupCode)
        {
            Waiting thePersonnel = ReadWaiting_Specific(aMemberID);
            return AddStudent_FromWaiting(thePersonnel, aHakGeupCode);
        }
        public int AddStudent_FromWaiting(Waiting aPersonnel, int aHakGeupCode)
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
            MessageBox.Show(result.ToString());
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

        

        private bool isNotNull(object aObject)
        {
            return aObject != null;
        }

        #endregion

        #region <<< 교직원 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// 보유 필드 : {아이디 | 이름 | 담당과목 | 성별 | 연락처 | 주소 | 사진 | 주간 수업 수 | 담당 학급 수 | 상담 학생 수}
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        public DataTable ReadTutor(string aField = null, string aSeed = null)
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
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_Tutor(aField), aSeed);
            }

            return ReadTable(_strQuery, "Tutor");
        }
        private string GetStringFormat_Of_QueryCondition_Tutor(string aField)
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

        internal string ReadTutor_Name(string tutor_id)
        {
            string _strQuery =
                "SELECT T.name " +
                $"FROM Tutor T WHERE T.member_id = '{tutor_id}' ";
            return Convert.ToString(ReadScalar(_strQuery));
        }        

        public class Tutor
        {
            public string Member_ID;
            public string Name;
            public string Gender;
            public string Contact;
            public string Address;
            public string Subject;
            public string Picture;
            public Tutor(string member_ID, string name, string gender, string contact, string address, string subject, string picture)
            {
                Member_ID = member_ID;
                Name = name;
                Gender = gender;
                Contact = contact;
                Address = address;
                Subject = subject;
                Picture = picture;
            }
        }
        
        public Tutor ReadTutor_Specific(string sessionID)
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

        public int ModifyTutor(Tutor thePersonnel)
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

        #endregion

        #region <<< 신청학생 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // Waiting ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// { 아이디 | 이름 | 상태 | 담당 선생님 | 입학 점수 | 성별 | 연락처 | 보호자 연락처 | 주소 | 사진 | 담당 선생님 아이디 | 보호자 아이디 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <param name="cbox_Seed"></param>
        /// <returns></returns>
        public DataTable ReadWaiting(string aField, string aSeed)
        {
            string _strQuery = GetQuery_DefaultFor_Waiting();            

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_Waiting(aField), aSeed);
            }
            return ReadTable(_strQuery, "Waiting");
        }
        private string GetQuery_DefaultFor_Waiting()
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
        private string GetStringFormat_Of_QueryCondition_Waiting(string aField)
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

        internal int ReadWaiting_NumberOf_Unassigned()
        {
            string _strQuery =
                "SELECT COUNT(member_id) " +
                "FROM Waiting " +
                "WHERE tutor_id is null ";
            return Convert.ToInt32(ReadScalar(_strQuery));
        }

        public class Waiting
        {
            public string Member_ID;
            public string Step;
            public int? Score;
            public string Name;
            public string Gender;
            public string Contact;
            public string Address;
            public string Picture;
            public string Parent_ID;
            public string Tutor_ID;

            public string Parent_Contact;
            public string Tutor_Name;

            public Waiting(
                string member_ID, string step, int? score, 
                string name, string gender, string contact, 
                string address, string picture, string parent_ID, string tutor_ID,
                string parent_contact, string tutor_name)
            {
                Member_ID = member_ID;
                Step = step;
                Score = score;
                Name = name;
                Gender = gender;
                Contact = contact;
                Address = address;
                Picture = picture;
                Parent_ID = parent_ID;
                Tutor_ID = tutor_ID;
                Parent_Contact = parent_contact;
                Tutor_Name = tutor_name;
            }
            public Waiting(DataRow aDataRow)
            {
                
                Member_ID = GetString_FromNullableDBValue(aDataRow["아이디"]);
                Step = GetString_FromNullableDBValue(aDataRow["상태"]);
                Score = GetInt_FromNullableDBValue(aDataRow["입학 점수"]);
                Name = GetString_FromNullableDBValue(aDataRow["이름"]);
                Gender = GetString_FromNullableDBValue(aDataRow["성별"]);
                Contact = GetString_FromNullableDBValue(aDataRow["연락처"]);
                Address = GetString_FromNullableDBValue(aDataRow["주소"]);
                Picture = GetString_FromNullableDBValue(aDataRow["사진"]);
                Parent_ID = GetString_FromNullableDBValue(aDataRow["보호자 아이디"]);
                Tutor_ID = GetString_FromNullableDBValue(aDataRow["담당 선생님 아이디"]);
                Parent_Contact = GetString_FromNullableDBValue(aDataRow["보호자 연락처"]);
                Tutor_Name = GetString_FromNullableDBValue(aDataRow["담당 선생님"]);


            }

            private int? GetInt_FromNullableDBValue(object DBValue)
            {
                if (DBValue == DBNull.Value || DBValue == null)
                {
                    return null;
                }
                return Convert.ToInt32(DBValue);
            }

            private string GetString_FromNullableDBValue(object DBValue)
            {
                if (DBValue == DBNull.Value || DBValue == null)
                {
                    return null;
                }
                return Convert.ToString(DBValue);
            }
        }

        public Waiting ReadWaiting_Specific(string aMember_ID)
        {
            string _strQuery = GetQuery_DefaultFor_Waiting() +
                $"WHERE W.member_id = '{aMember_ID}' ";

            DataTable dt = ReadTable(_strQuery, "Waiting");

            if (Exist_DataTable_Rows(dt))
            { return new Waiting(dt.Rows[0]); }
            else
            { return null; }
        }        
                
        internal int ModifyWaiting(Waiting thePersonnel)
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

        #endregion

        #region <<< 학급 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // HakGeup ///////////////////////////////////////////////////////////////////////////////////////////////////
        public class HakGeup
        {
            int HakGeup_Code;
            string HakGeup_Name;
            string Tutor_ID;
            string Tutor_Name;
            public HakGeup(int hakGeup_Code, string hakGeup_Name, string tutor_ID, string tutor_Name)
            {
                HakGeup_Code = hakGeup_Code;
                HakGeup_Name = hakGeup_Name;
                Tutor_ID = tutor_ID;
                Tutor_Name = tutor_Name;
            } 
            public HakGeup(DataRow aDataRow)
            {
                HakGeup_Code = Convert.ToInt32(aDataRow["학급코드"]);
                HakGeup_Name = Convert.ToString(aDataRow["학급"]);
                Tutor_ID = GetString_FromNullableDBValue(aDataRow["담당 선생님 아이디"]);
                Tutor_Name = GetString_FromNullableDBValue(aDataRow["담당 선생님"]);
            }
            private string GetString_FromNullableDBValue(object DBValue)
            {
                if (DBValue == DBNull.Value || DBValue == null)
                {
                    return null;
                }
                return Convert.ToString(DBValue);
            }
        }

        /// <summary>
        /// {학급코드 | 학급 | 담당 선생님 아이디 | 담당 선생님 }
        /// </summary>
        /// <returns></returns>
        public DataTable ReadHakGeup_All()
        {
            string _strQuery = 
                "SELECT H.code 학급코드, H.name 학급, " +
                "T.member_id \"담당 선생님 아이디\", T.name \"담당 선생님\" " +
                "FROM Hakgeup H " +
                "LEFT JOIN Tutor T ON H.tutor_id = T.member_id " +
                "ORDER BY 학급 ASC ";

            return ReadTable(_strQuery, "Hakgeup");
        }
        internal string ReadHakGeupName(int hakGeupCode)
        {
            string _strQuery =
                "SELECT H.name " +
                $"FROM HakGeup H WHERE H.code = {hakGeupCode} ";
            return Convert.ToString(ReadScalar(_strQuery));

        }

        public DataTable ReadHakGeup_Distinct(string aField, string aSeed)
        {
            string _strQuery =
                "SELECT H.code 학급코드 " +
                "FROM HakGeup H ";

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_HakGeup(aField), aSeed);
            }
            return ReadTable(_strQuery, "HakGeup");
        }

        private string GetStringFormat_Of_QueryCondition_HakGeup(string aField)
        {
            return "WHERE H.code LIKE '%{0}%' ";
        }

        #endregion

        #region <<< 수업 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        // Course ///////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// { 학급코드 | 학급 | 요일 | 교시 | 담당 선생님 아이디 | 담당 선생님 | 과목 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        public DataTable ReadCourse(string aField, string aSeed)
        {
            string _strQuery =
            #region ...
                "SELECT H.code 학급코드, H.name 학급, C.weekday 요일, " +
                "C.gyosi 교시, T.member_id \"담당 선생님 아이디\", T.name \"담당 선생님\", C.name 과목 " +
                "FROM Course C " +
                "JOIN Hakgeup H ON H.code = C.hakgeup_code " +
                "LEFT JOIN Tutor T ON T.member_id = C.tutor_id ";
            #endregion

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_Course(aField), aSeed);
            }
            return ReadTable(_strQuery, "Course");
        }
        private string GetStringFormat_Of_QueryCondition_Course(string aField)
        {
            switch (aField)
            {
                case "학급 선택":
                case "학급코드":
                    return "WHERE H.code = {0} ";
                case "학급명":
                    return "WHERE H.name LIKE '%{0}%' ";
                case "담당 선생님":
                    return "WHERE T.name LIKE '%{0}%' ";
                default:
                    throw new FieldNotFoundException();
            }
        }

        public DataTable ReadCourse_Distinct(string aField, string aSeed)
        {
            string _strQuery =
                "SELECT DISTINCT hakgeup_code 학급코드 " +
                "FROM course ";

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_Course(aField), aSeed);
            }
            return ReadTable(_strQuery, "Course");
        }
        
        internal DataRow ReadCourse_Specific(int? current_HakGeupCode, int aWeekday, int aGyosi)
        {
            string _strQuery =
            #region ...
                "SELECT H.code 학급코드, H.name 학급, C.weekday 요일, " +
                "C.gyosi 교시, T.member_id \"담당 선생님 아이디\", T.name \"담당 선생님\", C.name 과목 " +
                "FROM Course C " +
                "JOIN Hakgeup H ON H.code = C.hakgeup_code " +
                "LEFT JOIN Tutor T ON T.member_id = C.tutor_id " +
                $"WHERE H.code = {current_HakGeupCode} and C.weekday = {aWeekday} and C.gyosi = {aGyosi} ";
            #endregion

            DataTable _Result = ReadTable(_strQuery, "Course");

            if (_Result != null && _Result.Rows.Count == 1)
            {
                return _Result.Rows[0];
            }
            else if (_Result != null && _Result.Rows.Count > 1)
            {
                throw new Exception("Too many Rows Found On DataBase");
            }            

            return null;
        }

        public class Course
        {
            public int HakGeup_Code { get; set; }
            public string HakGeup_Name { get; set; }
            public int Weekday { get; set; }
            public int Gyosi { get; set; }
            public string Tutor_id { get; set; }
            public string Tutor_Name { get; set; }
            public string Subject_Name { get; set; }
            public Course(int Code, int Weekday, int Gyosi, string name, string tutor_id, string tutor_name = null, string hakgeup_name = null)
            {
                this.HakGeup_Code = Code;
                this.Weekday = Weekday;
                this.Gyosi = Gyosi;
                this.Subject_Name = name;
                this.Tutor_id = tutor_id;
                this.Tutor_Name = tutor_name;
                this.HakGeup_Name = hakgeup_name;
            }
            public Course(DataRow aDataRow)
            {
                this.HakGeup_Code = Convert.ToInt32(aDataRow[0]);
                this.HakGeup_Name = Convert.ToString(aDataRow[1]);
                this.Weekday = Convert.ToInt32(aDataRow[2]);
                this.Gyosi = Convert.ToInt32(aDataRow[3]);                
                this.Subject_Name = GetString_FromNullableDBValue(aDataRow["과목"]);
                this.Tutor_id = GetString_FromNullableDBValue(aDataRow["담당 선생님 아이디"]);
                this.Tutor_Name = GetString_FromNullableDBValue(aDataRow["담당 선생님"]);
            }
            private string GetString_FromNullableDBValue(object DBValue)
            {
                if (DBValue == DBNull.Value || DBValue == null)
                {
                    return null;
                }
                return Convert.ToString(DBValue);
            }
        }
        public int AddCourse(Course data)
        {
            Validator v_v = App.Instance().Validator;
            string _strQuery =
            #region ...
                "INSERT INTO course ( " +
                "hakgeup_code, weekday, gyosi " +
                (Exist_String(data.Tutor_id)? ", tutor_id " : "") +
                (Exist_String(data.Subject_Name)? ", name ": "" ) +
                ") VALUES ( " +
                $"{data.HakGeup_Code}, {data.Weekday}, {data.Gyosi} " +
                (Exist_String(data.Tutor_id) ? $", '{data.Tutor_id}' " : "")+
                (Exist_String(data.Subject_Name) ? $", '{data.Subject_Name}' " : "") +
                ") ";
            #endregion

            return ExecuteAndCommit(_strQuery);
        }
        internal int ModifyCourse(Course data)
        {
            string _strQuery =
            #region ...
                "UPDATE Course "
                + "SET "
                + $"tutor_id = {Get_DBString_OrNull(data.Tutor_id)}, "
                + $"name = {Get_DBString_OrNull(data.Subject_Name)} "
                + $"WHERE hakgeup_code = {data.HakGeup_Code} and weekday = {data.Weekday} and gyosi = {data.Gyosi} " ;
            #endregion

            return ExecuteAndCommit(_strQuery) ;
        }
        internal int DeleteCourse(Course data)
        {
            string _strQuery = 
                "DELETE FROM course " +
                $"WHERE hakgeup_code = '{data.HakGeup_Code}' " +
                $"AND weekday = '{data.Weekday}' " +
                $"AND gyosi = '{data.Gyosi}' ";

            return ExecuteAndCommit (_strQuery) ;
        }

        #endregion
    }
}
