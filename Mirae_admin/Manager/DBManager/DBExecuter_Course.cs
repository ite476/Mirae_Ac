using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_admin.Manager.DBManager
{
    internal class DBExecuter_Course : DBExecuter_Base
    {
        public DBExecuter_Course(DBManager theDBmgr) : base(theDBmgr) 
        {
            
        }

        /// <summary>
        /// { 학급코드 | 학급 | 요일 | 교시 | 담당 선생님 아이디 | 담당 선생님 | 과목 }
        /// </summary>
        /// <param name="aField"></param>
        /// <param name="aSeed"></param>
        /// <returns></returns>
        public DataTable Read(string aField, string aSeed)
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
                _strQuery += string.Format(GetStringFormat_For_QueryCondition(aField), aSeed);
            }
            return ReadTable(_strQuery, "Course");
        }
        private string GetStringFormat_For_QueryCondition(string aField)
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
        
        
        public DataTable Read_Distinct(string aField, string aSeed)
        {
            string _strQuery =
                "SELECT DISTINCT hakgeup_code 학급코드 " +
                "FROM course ";

            if (Exist_String(aSeed))
            {
                _strQuery += string.Format(GetStringFormat_For_QueryCondition(aField), aSeed);
            }
            return ReadTable(_strQuery, "Course");
        }
        
        
        public DataRow Read_Specific(int? current_HakGeupCode, int aWeekday, int aGyosi)
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


        public int Insert(Course data)
        {
            Validator v_v = App.Instance().Validator;
            string _strQuery =
            #region ...
                "INSERT INTO course ( " +
                "hakgeup_code, weekday, gyosi " +
                (Exist_String(data.Tutor_ID) ? ", tutor_id " : "") +
                (Exist_String(data.Subject_Name) ? ", name " : "") +
                ") VALUES ( " +
                $"{data.HakGeup_Code}, {data.Weekday}, {data.Gyosi} " +
                (Exist_String(data.Tutor_ID) ? $", '{data.Tutor_ID}' " : "") +
                (Exist_String(data.Subject_Name) ? $", '{data.Subject_Name}' " : "") +
                ") ";
            #endregion

            return ExecuteAndCommit(_strQuery);
        }


        public int Modify(Course data)
        {
            string _strQuery =
            #region ...
                "UPDATE Course "
                + "SET "
                + $"tutor_id = {Get_DBString_OrNull(data.Tutor_ID)}, "
                + $"name = {Get_DBString_OrNull(data.Subject_Name)} "
                + $"WHERE hakgeup_code = {data.HakGeup_Code} and weekday = {data.Weekday} and gyosi = {data.Gyosi} ";
            #endregion

            return ExecuteAndCommit(_strQuery);
        }


        public int Delete(Course data)
        {
            string _strQuery =
                "DELETE FROM course " +
                $"WHERE hakgeup_code = '{data.HakGeup_Code}' " +
                $"AND weekday = '{data.Weekday}' " +
                $"AND gyosi = '{data.Gyosi}' ";

            return ExecuteAndCommit(_strQuery);
        }
    }
}
