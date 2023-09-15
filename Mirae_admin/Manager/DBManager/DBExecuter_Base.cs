using Lib.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_admin.Manager.DBManager
{
    internal class DBExecuter_Base
    {
        protected DBManager DBManager { get; set; }

        public DBExecuter_Base(DBManager theDBmgr)
        {
            DBManager = theDBmgr;
        }

        OracleAssist OracleAssist {
            get { return DBManager.m_OracleAssist; }
        }

        #region <<< 공통기능 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        protected class FieldNotFoundException : Exception
        {
            public FieldNotFoundException() : base("검색하려는 필드 명이 설정되지 않았습니다. ") { }
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

        protected bool Exist_DataTable_Rows(DataTable dt)
        {
            return dt != null && dt.Rows != null && dt.Rows.Count > 0;
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
        protected bool Exist_String(string aStr)
        {
            return (aStr != null && aStr.Length > 0);
        }
        protected bool isNotNull(object aObject)
        {
            return aObject != null;
        }
        #endregion
    }
}
