using Lib.Control;
using Lib.DB;
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

        
      
        internal int ModifyStaff(
            string stf_org_id, string stf_id, string stf_name, string stf_password, string stf_gender,
            DateTime stf_date_register, DateTime stf_date_retire, bool isRetire, string stf_work_state, string stf_picture)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                string _strQuery = "UPDATE bp_staff "
                + "SET "
                + $"stf_id = '{stf_id}', "
                + $"stf_name = '{stf_name}', "
                + $"stf_password = '{stf_password}', "
                + $"stf_date_register = '{stf_date_register.ToString("yyyy-MM-dd")}', "
                + $"stf_date_retire = '{((isRetire) ? stf_date_retire.ToString("yyyy-MM-dd") : "NULL")}', "
                + $"stf_work_state = '{stf_work_state}', "
                + $"stf_gender = '{stf_gender}', "
                + $"stf_picture = {MakeToClobQuery(stf_picture)} "
                + $"WHERE stf_id = '{stf_org_id}' ";

                return m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        internal int AddStaff(
            string stf_id, string stf_name, string stf_password, string stf_gender,
            DateTime stf_date_register, DateTime stf_date_retire, bool abRetire, string stf_work_state, string stf_picture)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                string _strQuery =
                    "INSERT INTO bp_staff( "
                    + "stf_id, "
                    + "stf_name, "
                    + "stf_password, "
                    + "stf_date_register, "
                    + ((abRetire) ? "stf_date_retire, " : "")
                    + "stf_work_state, "
                    + "stf_gender, "
                    + "stf_picture "
                    + ") VALUES( "
                    + $"'{stf_id}', "
                    + $"'{stf_name}', "
                    + $"'{stf_password}', "
                    + $"'{stf_date_register.ToString("yyyy-MM-dd")}', "
                    + ((abRetire) ? $"' {stf_date_retire.ToString("yyyy-MM-dd")} ', " : "")
                    + $"'{stf_work_state}', "
                    + $"'{stf_gender}', "
                    + $"{MakeToClobQuery(stf_picture)} "
                    + ") ";

                return m_OracleAssist.ExcuteQuery(_strQuery);
            }

            return _result;
        }
        

        /// <summary>
        /// 보유 필드 : { 아이디 | 학생명 | 성별 | 연락처 | 주소 | 사진 | 등록일 | 학급명 | 보호자 연락처 | 출석률 | 평균 성적 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        internal DataTable ReadStudent(string aField, string aSeed)
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
        internal DataTable ReadTutor(string aField = null, string aSeed = null)
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
        internal DataTable ReadWaiting(string aField, string aSeed,ComboBox cbox_Seed = null)
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
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtWaitingQuery(aField, cbox_Seed), aSeed);
            }
            return ReadTable(_strQuery, "Waiting");
        }

        private string GetStringFormat_Of_QueryCondition_AtWaitingQuery(string aField, ComboBox cbox_Seed)
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
                    string cbox_SeedString = cbox_Seed.SelectedItem.ToString();
                    switch (cbox_SeedString) {
                        case "상담":
                        case "입학 테스트":
                        case "입학 대기":
                            return $"WHERE W.step = '{cbox_SeedString}'";
                        default:
                            throw new IndexOutOfRangeException();
                    }
                    break;
                    
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

        internal DataTable ReadCategory()
        {
            throw new NotImplementedException();
        }

        internal DataTable ReadCourse(string aField, string aSeed, ComboBox aComboBox)
        {
            throw new NotImplementedException();
        }
    }
}
