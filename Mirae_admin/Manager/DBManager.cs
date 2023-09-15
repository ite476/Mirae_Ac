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

        #region <<< 직원 데이터 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// ID / 비밀번호로 직원 로그인 시도 결과 DataTable 반환
        /// </summary>
        /// <param name="aID"></param>
        /// <param name="aPassword"></param>
        /// <returns></returns>
        public DataTable ReadStaff(string aID, string aPassword)
        {
            string _strFormat =
                " SELECT stf_ID, stf_Name, Stf_Date_Register, Stf_Gender, "
                + "CASE WHEN Stf_Password = '{1}' THEN 1 ELSE 0 END isCorrectPassword, "
                + "CASE WHEN Stf_Date_Retire is null THEN 1 WHEN Stf_Date_Retire > Sysdate THEN 1 ELSE 0 END isNotRetired, "
                + "CASE WHEN Stf_Work_State = 'ON' THEN 1 ELSE 0 END isOnWork "
                + "FROM Bp_Staff "
                + "WHERE stf_id = '{0}' "
                ;
            string _strQuery = string.Format(_strFormat, aID, aPassword);

            return ReadTable(_strQuery, "Staff");

        }

        /// <summary>
        /// 검색 테이블 Bp_Staff : 출력 필드 { Stf_ID, Stf_Name, Stf_Date_Register, Stf_Date_Retire, Stf_Work_State, Stf_Gender }
        /// </summary>
        /// <param name="Field"></param>
        /// <param name="aKeyword"></param>
        /// <returns></returns>
        public DataTable SearchStaff(string aKeyword, string Field = "Stf_ID", bool includePicture = false)
        {
            string _TableName = "Staff";

            string _strFormat =
                "SELECT Stf_ID, Stf_Name, Stf_Date_Register, Stf_Date_Retire, Stf_Work_State, Stf_Gender "
                + ((includePicture) ? ", Stf_Picture " : "")
                + "FROM BP_Staff ";

            if (aKeyword.Length > 0)
            {
                if (Field.ToLower() == "stf_id")
                {
                    _strFormat += "WHERE {0} = '{1}' ";
                }
                else
                {
                    _strFormat += "WHERE {0} LIKE '%{1}%' ";
                }

            }


            string _strQuery = string.Format(_strFormat, Field, aKeyword);

            return ReadTable(_strQuery, _TableName);

        }

        /// <summary>
        /// BP_Staff : { Stf_ID, Stf_Name, Stf_Password, Stf_Date_Register, Stf_Date_Retire, Stf_Work_State, Stf_Gender, Stf_Picture } 
        /// </summary>
        /// <param name="aKeyword"></param>
        /// <returns></returns>
        public DataRow SearchStaff(string aKeyword)
        {
            string _TableName = "Staff";

            string _strFormat =
                "SELECT Stf_ID, Stf_Name, Stf_Password, Stf_Date_Register, Stf_Date_Retire, Stf_Work_State, Stf_Gender, Stf_Picture "
                + "FROM BP_Staff ";


            if (aKeyword.Length > 0)
            {
                _strFormat += "WHERE Stf_ID = '{0}' "; ;
            }

            string _strQuery = string.Format(_strFormat, aKeyword);
            DataTable _dt = ReadTable(_strQuery, _TableName);
            foreach (DataRow _dr in _dt.Rows)
            {
                return _dr;
            }
            return null;
        }

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
        #endregion

        #region <<< 장르 데이터 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        internal DataTable ReadCategory()
        {
            string _strQuery = "SELECT Ctg_Code, Ctg_Name FROM BP_Category";

            return ReadTable(_strQuery, "BP_Category");
        }


        #endregion

        #region <<< 도서 데이터 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// <para>
        /// aComparison >> {"==", "=", "LIKE"} :: { "==", "LIKE" }는 문자열로 판단함</para>
        /// <para>
        /// aSeed 문자열 변환 시 길이가 0 이면 전체 반환</para>
        /// <para>
        /// 반환 필드명 { Bk_Code, Bk_Title, Bk_Writer, Bk_Publisher, Bk_Price, Bk_Year_Publish, 
        /// Bk_Date_Register, Bk_Date_Delete, Bk_Picture, Ctg.Ctg_Code, Ctg.Ctg_Name, Bk_State }</para>
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aComparison"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        internal DataTable ReadBook(string aField, string aComparison = "=", string aSeed = "")
        {
            string _strQuery = "SELECT "
                

                + "Bk_Code, Bk_Title, Bk_Writer, Bk_Publisher, Bk_Price, Bk_Year_Publish, "
                + "Bk_Date_Register, Bk_Date_Delete, Bk_Picture, Ctg.Ctg_Code, Ctg.Ctg_Name, "
                + "nvl(( "
                    + "SELECT case when Rnt_Date_Return is null and sysdate <= Rnt_Date_Limit  then '대여중' "
                    + "when Rnt_Date_Return is null then '연체중' end "
                    + "FROM BP_Rent Rnt "
                    + "WHERE Rnt.Bk_Code = Bk.Bk_Code ), '대여가능') Bk_State "
                + "FROM BP_Book Bk "
                + "JOIN BP_Category Ctg " + "ON Bk.Ctg_Code = Ctg.Ctg_Code ";
            if (aSeed.Length > 0)
            {
                string _Seed = aSeed;

                switch (aComparison)
                {
                    case "==":
                        aComparison = "=";
                        _Seed = $"'{_Seed}'";
                        break;
                    case "LIKE":
                        _Seed = $"'%{_Seed}%'";
                        break;
                    default:
                        break;
                }

                _strQuery += $"WHERE Bk.{aField} {aComparison} {_Seed}";
            }

            return ReadTable(_strQuery, "BP_Book");

        }

        internal int AddBook(
            string ctg_code, int seq_book, string bk_title, string bk_writer, string bk_publisher,
            int bk_price, int bk_year_publish, DateTime bk_date_register, string bk_picture)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                string _strQuery =
                    "INSERT INTO BP_Book( "
                    + "bk_code, "
                    + "bk_title, "
                    + "bk_writer, "
                    + "bk_publisher, "
                    + "bk_price, "
                    + "bk_year_publish, "
                    + "bk_date_register, "
                    + "bk_picture, "
                    + "ctg_code "
                    + ") VALUES( "
                        + $"'{ctg_code}{seq_book:0000}', "
                        + $"'{bk_title}', "
                        + $"'{bk_writer}', "
                        + $"'{bk_publisher}', "
                        + $"{bk_price}, "
                        + $"{bk_year_publish}, "
                        + $"'{(bk_date_register).ToString("yyyy-MM-dd")}', "
                        + $"{MakeToClobQuery(bk_picture)}, "
                        + $"'{ctg_code}'"
                    + ") ";
                return m_OracleAssist.ExcuteQuery(_strQuery);
            }            
        }

        internal int ModifyBook(
            string bk_code, string bk_title, string bk_writer, string bk_publisher, 
            int bk_price, int bk_year_publish, DateTime bk_date_register, string bk_picture, string ctg_code)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                string _strQuery = 
                    "UPDATE bp_book SET " + 
                    $"bk_code = '{bk_code}', " + 
                    $"bk_title = '{bk_title}', " + 
                    $"bk_writer = '{bk_writer}', " + 
                    $"bk_publisher = '{bk_publisher}', " + 
                    $"bk_price = {bk_price}, " + 
                    $"bk_year_publish = {bk_year_publish}, " + 
                    $"bk_date_register = '{bk_date_register.ToString("yyyy-MM-dd")}', " + 
                    $"bk_picture = {MakeToClobQuery(bk_picture)}, " + 
                    $"ctg_code = '{ctg_code}' "+ $"WHERE bk_code = '{bk_code}' ";

                return m_OracleAssist.ExcuteQuery(_strQuery);
            }
            return _result;
        }

        #endregion

        #region <<< 회원 데이터 관련 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        /// <summary>
        /// <para>
        /// aComparison >> {"==", "=", "LIKE"} :: { "==", "LIKE" }는 문자열로 판단함</para>
        /// <para>
        /// aSeed 문자열 변환 시 길이가 0 이면 전체 반환</para>
        /// <para>
        /// 반환 필드명 { Mbr.Mbr_Ucode, Mbr_Name, Mbr_ID, Mbr_Password, Mbr_Gender, Mbr_Contact, Mbr_Address, Mbr_Picture, Mbr_Date_Ban, Count_Rent, Count_OverDue }
        /// </para>
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aComparison"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        internal DataTable ReadMember(string aField, string aComparison, object aSeed)
        {
            string _strQuery =
                "WITH Mbr_Count AS ( " +
                "SELECT Mbr.Mbr_Ucode, count(Rnt_ucode) - count(Rnt_Date_Return) Count_Rent, " +
                    "count(nvl2(Rnt_Date_Return, 0, 1)) Count_OverDue " +
                "FROM BP_Member Mbr JOIN BP_Rent Rnt ON Mbr.Mbr_Ucode = Rnt.Mbr_Ucode " +
                "GROUP BY Mbr.Mbr_Ucode ) " +
                "SELECT Mbr.Mbr_Ucode, Mbr_Name, Mbr_ID, Mbr_Password, Mbr_Gender, Mbr_Contact, Mbr_Address, " +
                    "Mbr_Picture, Mbr_Date_Ban, " +
                    "nvl(Count_Rent, 0) Count_Rent, nvl(Count_OverDue, 0) Count_OverDue " +
                "FROM BP_Member Mbr " +
                "LEFT JOIN Mbr_Count Cnt ON Mbr.Mbr_Ucode = Cnt.Mbr_Ucode " +
                ((aField == "bk_title") ? $"JOIN BP_Rent Rnt ON Mbr.Mbr_Ucode = Rnt.MBr_Ucode " : "");

            if (Convert.ToString(aSeed).Length > 0)
            {
                string _Seed = Convert.ToString(aSeed);

                switch (aComparison)
                {
                    case "==":
                        aComparison = "=";
                        _Seed = $" '{_Seed}' ";
                        break;
                    case "LIKE":
                        _Seed = $" '%{_Seed}%' ";
                        break;
                    default:
                        _Seed = $" {_Seed} ";
                        break;
                }

                switch(aField)
                {
                    case "bk_title":
                        _strQuery += $"WHERE Rnt.{aField} {aComparison} {_Seed} ";
                        break;
                    case "count_rent":
                    case "count_overdue":
                        aField = $" nvl({aField},0) ";
                        _strQuery += $"WHERE {aField} {aComparison} {_Seed}";
                        break;
                    default:
                        _strQuery += $"WHERE Mbr.{aField} {aComparison} {_Seed} ";                        
                        break;
                }                
                
            }
            return ReadTable(_strQuery, "BP_Member");
        }

        internal int AddMember(
            int mbr_ucode, string mbr_id, string mbr_name, string mbr_password, 
            string mbr_contact, string mbr_address, string mbr_gender, string mbr_picture)
        {
            int _result = 0;

            DbConnection _Connection = m_OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                string _strColumns = "",
                       _strValues = "";

                _strColumns += "mbr_ucode, ";
                _strValues += $"'{mbr_ucode}', ";

                _strColumns += "mbr_id, ";
                _strValues += $" '{mbr_id}', ";

                _strColumns += "mbr_name, ";
                _strValues += $" '{mbr_name}', ";

                _strColumns += "mbr_password, ";
                _strValues += $" '{mbr_password}', ";

                _strColumns += "mbr_contact, ";
                _strValues += $" '{mbr_contact}', ";

                _strColumns += "mbr_address, ";
                _strValues += $" '{mbr_address}', ";

                _strColumns += "mbr_gender, ";
                _strValues += $" '{mbr_gender}', ";

                _strColumns += "mbr_picture ";
                _strValues += $" {MakeToClobQuery(mbr_picture)} ";


                string _strQuery = $"INSERT INTO BP_Member ( {_strColumns} ) VALUES ( {_strValues} ) ";

                return m_OracleAssist.ExcuteQuery(_strQuery);
            }


            throw new NotImplementedException();
        }


        internal void SearchTest()
        {
            string _strQuery = " SELECT * FROM member ";

            MessageBox.Show(ReadTable(_strQuery,"TEST").ToString());
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


            if (Check_Str_Exists(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtStudentQuery(aField), aSeed);
            }

            return ReadTable(_strQuery, "student");
        }        

        bool Check_Str_Exists(string aStr) 
        {
            return (aStr != null || aStr.Length > 0);
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
        internal DataTable ReadTutor(string aField, string aSeed)
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

            if (Check_Str_Exists(aSeed))
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

        

        internal DataTable ReadWaiting(string aField, string aSeed,ComboBox cbox_Seed)
        {            
            string _strQuery =
                "" +
                "아이디 이름 상태 담당 선생님 입학 점수 성별 연락처 보호자 연락처 주소 사진";
            if (Check_Str_Exists(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_Of_QueryCondition_AtWaitingQuery(aField, cbox_Seed), aSeed);
            }
            throw new NotImplementedException();
        }

        private string GetStringFormat_Of_QueryCondition_AtWaitingQuery(string aField, ComboBox cbox_Seed)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
