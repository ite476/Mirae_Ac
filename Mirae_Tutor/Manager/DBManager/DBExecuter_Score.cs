using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_Tutor.Manager.DBManager
{
    internal class DBExecuter_Score:DBExecuter_Base
    {
        public DBExecuter_Score(DBManager dBManager) : base(dBManager) { }

        public DataTable Read_ByStudentID(string sID)
        {
            string _strQuery =
                "SELECT name 시험명, date_test 시험일자, " +
                "korean 국어, math 수학, english 영어, " +
                "history 한국사, social 사회탐구, science 과학탐구 " +
                "FROM Score " +
                $"WHERE student_id = '{sID}' ";

            return ReadTable(_strQuery, "Score");
        }

        public int Insert(Score theScore)
        {
            string _strQuery =
                "INSERT INTO Score ( " +
                "student_id, " +
                "name, " +
                "date_test, " +
                "korean, math, english, " +
                "history, social, science " +
                ") VALUES ( " +
                $"'{theScore.StudentID}', '{theScore.TestName}', '{theScore.Date.ToString("yyyy-MM-dd")}', " +
                $"{theScore.Korean}, {theScore.Math}, {theScore.English}, " +
                $"{theScore.History}, {theScore.Social}, {theScore.Science} " +
                ") ";

            return ExecuteAndCommit(_strQuery);
        }
        public int Modify(Score theScore)
        {
            string _strQuery =
                "UPDATE Score SET " +
                $"name = '{theScore.TestName}', " +
                $"date_test = '{theScore.Date.ToString("yyyy-MM-dd")}', " +
                $"korean = {theScore.Korean}, " +
                $"math = {theScore.Math}, " +
                $"english = {theScore.English}, " +
                $"history = {theScore.History}, " +
                $"social = {theScore.Social}, " +
                $"science = {theScore.Science} " +
                $"WHERE student_id = '{theScore.StudentID}' ";

            return ExecuteAndCommit(_strQuery);
        }
        public int Delete(Score theScore)
        {
            string _strQuery = 
                "DELETE FROM Score " +
                $"WHERE student_id = '{theScore.StudentID}' " +
                $"AND date_test = '{theScore.Date.ToString("yyyy-MM-dd")}' ";

            return ExecuteAndCommit(_strQuery); ;
        }

        

        

        
    }
}
