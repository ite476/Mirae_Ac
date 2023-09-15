using Lib.Control;
using Lib.DB;
using Mirae_Tutor.Manager.DBManager;
using Mirae_Tutor.Windows.Pop;
using Mirae_Tutor.Windows.View;
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

namespace Mirae_Tutor.Manager.DBManager
{
    partial class DBManager
    {
        public DBExecuter_Login Login { get; set; }
        public DBExecuter_Course Course { get; set; }
        public DBExecuter_HakGeup HakGeup { get; set; }
        public DBExecuter_Waiting Waiting { get; set; }
        public DBExecuter_Tutor Tutor { get; set; }
        public DBExecuter_Student Student { get; set; }
        public DBExecuter_Score Score { get; set; }
        
        
        public OracleAssist OracleAssist { get; set; }
        public DBManager()
        {
            this.Course = new DBExecuter_Course(this);
            this.HakGeup = new DBExecuter_HakGeup(this);
            this.Waiting = new DBExecuter_Waiting(this);
            this.Tutor = new DBExecuter_Tutor(this);
            this.Student = new DBExecuter_Student(this);
            this.Login = new DBExecuter_Login(this);
            this.Score = new DBExecuter_Score(this);
        }        
        
        

       
        public void SetConnectInfo(string aAddr, int aPort, string aId, string aPwd, string aDataBase)
        {
            OracleAssist = new OracleAssist(aAddr, aPort, aId, aPwd, aDataBase);
        }

        /*
        public int GetSequence(string aSequence)
        {
            string _strQuery = $"SELECT {aSequence}.nextval FROM DUAL ";
            return Convert.ToInt32(ReadScalar(_strQuery));
        }        


        //4000자 이상 문자열 ToClob으로 처리하기
        protected string MakeToClobQuery(string aSrc)
        {
            return MakeToClobQuery(aSrc, 4000);
        }
        protected string MakeToClobQuery(string aSrc, int aBlock)
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
        
        
        
        protected DataTable ReadTable(string aQuery, string aTableName)
        {
            DataTable _dt = null;
            DbConnection _Connection = OracleAssist.NewConnection();

            if (_Connection == null)
            {
                return null;
            }
            else
            {
                _dt = OracleAssist.SelectQuery(_Connection, aQuery, aTableName);
            }
            return _dt;
        }       
        
        protected object ReadScalar(string aQuery)
        {
            DbConnection _Connection = OracleAssist.NewConnection();
            if (_Connection == null)
            {
                return -999;
            }
            else
            {
                return OracleAssist.ExcuteScalar(_Connection, aQuery);
            }
        }
        
        
        protected int ExecuteAndCommit(string aQuery)
        {
            int _result = 0;

            DbConnection _Connection = OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                return OracleAssist.ExcuteQuery(aQuery);
            }
        }
        protected int ExecuteAndCommit_MultipleQueries(ArrayList Queries)
        {
            int _result = 0;

            DbConnection _Connection = OracleAssist.NewConnection();

            if (_Connection == null) { return -999; }
            else
            {
                return OracleAssist.ExcuteArrayQuery(Queries);
            }
            
        }


        protected string Get_DBGender(string gender)
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

        protected string GetString_FromDBValue(object DBValue)
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

        protected int? GetInt_FromDBValue(object DBValue)
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

        protected string Get_DBString_OrNull(string String_DBValue)
        {
            return (Exist_String(String_DBValue) ? $"'{String_DBValue}' " : "NULL ");
        }


        protected bool Exist_DataTable_Rows(DataTable dt)
        {
            return dt != null && dt.Rows != null && dt.Rows.Count > 0;
        }
        
        protected bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }
*/

    }
}
