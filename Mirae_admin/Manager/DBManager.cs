using Lib.Control;
using Lib.DB;
using MiraePro.Windows.Pop;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


        //4000자 이상 문자열 ToClob으로 처리하기
        public string MakeToClobQuery(string aSrc)
        {
            return MakeToClobQuery(aSrc, 4000);
        }
        public string MakeToClobQuery(string aSrc, int aBlock)
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

        /// <summary>
        /// Connection 포함
        /// </summary>
        /// <param name="aQuery"></param>
        /// <param name="aTableName"></param>
        /// <returns></returns>
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

        internal int GetSequence(string aSequence)
        {
            string _strQuery = $"SELECT {aSequence}.nextval FROM DUAL ";
            return Convert.ToInt32(ReadScalar(_strQuery));
        }
        #endregion



        

        public int ExecuteAndCommit(string aQuery)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {                
                return m_OracleAssist.ExcuteQuery(aQuery);
            }
        }


        /// <summary>
        /// 보유 필드 : { 아이디 | 학생명 | 성별 | 연락처 | 주소 | 사진 | 등록일 | 학급명 | 보호자 연락처 | 출석률 | 평균 성적 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        public DataTable ReadStudent(string aField, string aSeed)
        {
            string _strQuery = 
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
                "SELECT S.member_id 아이디, S.name 학생명, " +
                    "CASE WHEN S.gender = 'M' THEN '남성' " +
                    "WHEN S.gender = 'W' or S.gender = 'F' THEN '여성' " +
                    "ELSE NULL END 성별, " +
                    "S.contact 연락처, S.address 주소, S.picture 사진, S.date_register 등록일, H.name 학급명, " +
                    "nvl(P.contact,'-') \"보호자 연락처\", nvl(attend_rate,0) 출석률, nvl(avg_score,0) \"평균 성적\" " +
                "FROM student S " +
                "JOIN HakGeup H ON HakGeup_code = H.code " +
                "LEFT JOIN Parent P ON parent_id = P.member_id " +
                "LEFT JOIN Student_Avg_Score SAS ON S.member_id = SAS.member_id " +
                "LEFT JOIN Student_Attend_Rate SAR ON S.member_id = SAR.member_id ";


            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtStudentQuery(aField), aSeed);
            }

            return ReadTable(_strQuery, "student");
        }        

        bool Exist_String(string aStr) 
        {
            return (aStr != null && aStr.Length > 0);
        }

        private string GetStringFormat_Of_QueryCondition_AtStudentQuery(string aField)
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

        /// <summary>
        /// 보유 필드 : {아이디 | 이름 | 담당과목 | 성별 | 연락처 | 주소 | 사진 | 주간 수업 수 | 담당 학급 수 | 상담 학생 수}
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        public DataTable ReadTutor(string aField = null, string aSeed = null)
        {
            
            string _strQuery = 
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

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtTutorQuery(aField), aSeed);
            }

            return ReadTable(_strQuery, "Tutor");
        }

        private string GetStringFormat_Of_QueryCondition_AtTutorQuery(string aField)
        {
            switch (aField)
            {
                case "아이디":
                    return "WHERE T.member_id LIKE '%{0}%' ";
                case "이름":
                    return "WHERE T.name LIKE '%{0}%' ";
                case "담당과목":
                    return "WHERE T.subject LIKE '%{0}%'";
                case "연락처":
                    return "WHERE T.contact LIKE '%{0}%'";
                default:
                    throw new FieldNotFoundException();
            }            
        }


        /// <summary>
        /// { 아이디 | 이름 | 상태 | 담당 선생님 | 입학 점수 | 성별 | 연락처 | 보호자 연락처 | 주소 | 사진 | 담당 선생님 아이디 | 보호자 아이디 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <param name="cbox_Seed"></param>
        /// <returns></returns>
        public DataTable ReadWaiting(string aField, string aSeed)
        {
            string _strQuery =
                "SELECT W.member_id 아이디, W.name 이름, W.step 상태, " +
                "nvl(T.name,'배정 안됨') \"담당 선생님\", W.score \"입학 점수\", " +
                "CASE WHEN W.gender = 'M' THEN '남성' " +
                "WHEN W.gender = 'W' or W.gender = 'F' THEN '여성' " +
                "ELSE NULL END 성별, W.contact 연락처, " +
                "nvl(P.contact,'-') \"보호자 연락처\", W.address 주소, W.picture 사진, " +
                "T.member_id \"담당 선생님 아이디\", P.member_id \"보호자 아이디\" " +
                "FROM Waiting W " +
                "LEFT JOIN Parent P ON W.parent_id = P.member_id " +
                "LEFT JOIN Tutor T ON W.tutor_id = T.member_id ";
            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtWaitingQuery(aField), aSeed);
            }
            return ReadTable(_strQuery, "Waiting");
        }

        private string GetStringFormat_Of_QueryCondition_AtWaitingQuery(string aField)
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
                    return "WHERE W.step = '{0}'";
                default:
                    throw new FieldNotFoundException();
            }
        }

        internal int ModifyWaiting(
            string member_id, string step, int score, 
            string name, string gender, string contact, 
            string address, string picture, string parent_id, string tutor_id)
        {

            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                string DB_GenderValue;
                switch (gender)
                {
                    case "남성":
                        DB_GenderValue = "'M'"; break;
                    case "여성":
                        DB_GenderValue = "'W'"; break;
                    default:
                        DB_GenderValue = "NULL"; break;
                }
                string _strQuery = "UPDATE Waiting "
                + "SET "
                + $"member_id = '{member_id}', "
                + $"step = '{step}', "
                + $"score = " + ((score > -1) ? $"{score}, " : "NULL, ")
                + $"name = '{name}', "
                + $"gender = {DB_GenderValue}, " 
                + $"contact = '{contact}', "
                + $"address = '{address}', "
                + $"parent_id = " + ( (Exist_String(parent_id))? $"'{parent_id}', " : "NULL, " )
                + $"tutor_id = " + ((Exist_String(tutor_id)) ? $"'{tutor_id}', " : "NULL, ")
                + $"picture = {MakeToClobQuery(picture)} "

                + $"WHERE member_id = '{member_id}' ";

                return m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        public DataTable ReadHakgeup()
        {
            string _strQuery = 
                "SELECT H.code 학급코드, H.name 학급, " +
                "T.member_id \"담당 선생님 아이디\", T.name \"담당 선생님\" " +
                "FROM Hakgeup H " +
                "LEFT JOIN Tutor T ON H.tutor_id = T.member_id " +
                "ORDER BY 학급 ASC ";

            return ReadTable(_strQuery, "Hakgeup");
        }

        public DataTable ReadCourse(string aField, string aSeed)
        {
            string _strQuery =
                "SELECT H.code 학급코드, H.name 학급, " +
                    "CASE " +
                        "WHEN C.weekday = 1 THEN 'Sun' " +
                        "WHEN C.weekday = 2 THEN 'Mon' " +
                        "WHEN C.weekday = 3 THEN 'Tue' " +
                        "WHEN C.weekday = 4 THEN 'Wed' " +
                        "WHEN C.weekday = 5 THEN 'Thu' " +
                        "WHEN C.weekday = 6 THEN 'Fri' " +
                        "WHEN C.weekday = 7 or C.weekday = 0 THEN 'Sat' " +
                    "ELSE NULL END 요일, " +
                    "C.gyosi 교시, T.member_id \"담당 선생님 아이디\", T.name \"담당 선생님\", C.name 과목 " +
                "FROM Course C " +
                "JOIN Hakgeup H ON H.code = C.hakgeup_code " +
                "LEFT JOIN Tutor T ON T.member_id = C.tutor_id ";
            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtCourseQuery(aField), aSeed);
            }
            return ReadTable(_strQuery, "Course");
        }

        private string GetStringFormat_Of_QueryCondition_AtCourseQuery(string aField)
        {
            switch (aField) 
            {
                case "학급 선택":
                    return "WHERE H.code = '{0}' ";
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
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtCourseQuery(aField), aSeed);
            }
            return ReadTable(_strQuery, "Course");
        }

        internal DataTable ReadCourse_Specific(int? current_HakGeupCode, int aWeekday, int aGyosi)
        {
            string _strQuery =
                "SELECT H.code 학급코드, H.name 학급, " +
                    "CASE " +
                        "WHEN C.weekday = 1 THEN 'Sun' " +
                        "WHEN C.weekday = 2 THEN 'Mon' " +
                        "WHEN C.weekday = 3 THEN 'Tue' " +
                        "WHEN C.weekday = 4 THEN 'Wed' " +
                        "WHEN C.weekday = 5 THEN 'Thu' " +
                        "WHEN C.weekday = 6 THEN 'Fri' " +
                        "WHEN C.weekday = 7 or C.weekday = 0 THEN 'Sat' " +
                    "ELSE NULL END 요일, " +
                    "C.gyosi 교시, T.member_id \"담당 선생님 아이디\", T.name \"담당 선생님\", C.name 과목 " +
                "FROM Course C " +
                "JOIN Hakgeup H ON H.code = C.hakgeup_code " +
                "LEFT JOIN Tutor T ON T.member_id = C.tutor_id " +
                $"WHERE H.code = {current_HakGeupCode} and C.weekday = {aWeekday} and C.gyosi = {aGyosi} ";
            return ReadTable(_strQuery, "Course");
        }

        internal string ReadHakgeupName(int hakGeupCode)
        {
            string _strQuery = 
                "SELECT H.name " +
                $"FROM HakGeup H WHERE H.code = {hakGeupCode} ";
            return Convert.ToString(ReadScalar(_strQuery));
            
        }
        public class Course
        {
            public int Code;
            public int Weekday;
            public int Gyosi;
            public string Tutor_id;
            public string name;
            public Course(int Code, int Weekday, int Gyosi, string name, string tutor_id)
            {
                this.Code = Code;
                this.Weekday = Weekday;
                this.Gyosi = Gyosi;
                this.name = name;
                this.Tutor_id = tutor_id;
            }

            internal bool isVaild()
            {
                return (name != null && name.Length > 0) 
                    && Tutor_id != null;
            }
        }
        public int AddCourse(Course data)
        {
            string _strQuery =
                "INSERT INTO course ( " +
                "hakgeup_code, weekday, gyosi " +
                (Exist_String(data.Tutor_id)? ", tutor_id " : "") +
                (Exist_String(data.name)? ", name ": "" ) +
                ") VALUES ( " +
                $"{data.Code}, {data.Weekday}, {data.Gyosi} " +
                (Exist_String(data.Tutor_id) ? $", '{data.Tutor_id}' " : "")+
                (Exist_String(data.name) ? $", {data.name} " : "") +
                ") ";

            return ExecuteAndCommit(_strQuery);
        }

        internal int ModifyCourse(Course data)
        {
            string _strQuery =
                "UPDATE Course "
                + "SET "
                + "tutor_id = " + (Exist_String(data.Tutor_id) ? $"'{data.Tutor_id}', " : "NULL, ")
                + "name = " + (Exist_String(data.name) ? $"'{data.name}' " : "NULL ")
                + $"WHERE hakgeup_code = {data.Code} and weekday = {data.Weekday} and gyosi = {data.Gyosi} " ;
                
            return ExecuteAndCommit(_strQuery) ;
        }

        internal string ReadTutor_Name(string tutor_id)
        {
            string _strQuery =
                "SELECT T.name " +
                $"FROM Tutor T WHERE T.member_id = '{tutor_id}' ";
            return Convert.ToString(ReadScalar(_strQuery));
        }
    }
}
