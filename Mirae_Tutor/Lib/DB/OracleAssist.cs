using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OracleClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace Lib.DB
{
    class OracleAssist
    {
        private String m_connectString = "";
        protected OracleConnection m_sqlConnection = null;

        //접속        
        //OracleConnection  접속
        //OracleTransaction rollback commit 연동
        //OracleDataAdapter 문자열 방식 쿼리실행
        //OracleCommand     객체방식 쿼리실행
        public OracleAssist()
        {
            m_connectString = "";
        }

        public OracleAssist(String aHost, int aPort, string aID, string aPWD, string aDatabase)
        {
            m_connectString = string.Format(@"Data Source={0}:{1}/{2};User ID={3};Password={4}", aHost, aPort, aDatabase, aID, aPWD);
            m_sqlConnection = new OracleConnection(m_connectString);

        }
        public String MakeConnectString(string aHost, int aPort, string aID, string aPWD, string aDatabase)
        {
            if (aPort < 0)
            {
                aPort = 1521;
            }

            m_connectString = String.Format(@"Data Source={0}:{1}/{2};User ID={3};Password={4}", aHost, aPort, aDatabase, aID, aPWD);

            //string sql = "Data Source=127.0.0.1:1521/xe;User ID=hr;Password=hr";
            return m_connectString;
        }

        public bool TestConnection()
        {
            bool _success = false;
            try
            {
                m_sqlConnection.Open();
                _success = true;
                m_sqlConnection.Close();
            }
            catch { _success = false; }

            return _success;
        }

        public DbConnection NewConnection()
        {

            OracleConnection _connection = null;
            try
            {
                _connection = GetNewConnection();
                _connection.Open();
                _connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (_connection != null)
                {
                    _connection.Close();
                }
            }

            return _connection as DbConnection;
        }

        public OracleConnection GetNewConnection()
        {
            return new OracleConnection(m_connectString);
        }

        public DataTable SelectQuery(DbConnection _db_connection,
            string aQuery, string TableName)
        {
            OracleConnection connection = _db_connection as OracleConnection;

            DataTable _DataTable = new DataTable();
            try
            {
                if (connection == null)
                {
                    connection = GetNewConnection();
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                OracleDataAdapter _SqlAdapter
                    = new OracleDataAdapter(aQuery, connection);

                int _count = _SqlAdapter.Fill(_DataTable);
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                connection.Close();
            }

            try
            {
                if (TableName.Length > 0)
                {
                    _DataTable.TableName = TableName;
                }
                else { }
            }
            catch { }
            return _DataTable;
        }


        public DataSet SelectQueryDataSet(DbConnection _db_connection, ArrayList aQueryArray)
        {
            OracleConnection connection = _db_connection as OracleConnection;

            DataSet _DataSet = new DataSet();

            try
            {
                if (connection == null)
                {
                    connection = GetNewConnection();
                }
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                //MySqlDataAdapter oddaResult = new MySqlDataAdapter(query, connection);
                foreach (object _QueryItem in aQueryArray)
                {
                    string _tablename = "";
                    string _query = "";
                    if (_QueryItem is KeyValuePair<string, string>)
                    {
                        KeyValuePair<string, string> _KeyValue = (KeyValuePair<string, string>)_QueryItem;
                        _tablename = _KeyValue.Key;
                        _query = _KeyValue.Value;
                    }
                    else if (_QueryItem is string)
                    {
                        _query = _QueryItem as string;
                    }
                    DataTable _table = new DataTable();
                    OracleCommand command = new OracleCommand(_query, connection);
                    command.CommandTimeout = 300;
                    OracleDataAdapter _SqlAdapter = new OracleDataAdapter(command);
                    int _count = _SqlAdapter.Fill(_table);
                    if (_count > 0)
                    {
                        _table.TableName = _tablename;
                        _DataSet.Tables.Add(_table);
                    }
                }



                //connection.Close();
            }
            catch (OracleException ex)
            {
                Console.WriteLine(ex.Message);

                //throw ex;
            }
            finally
            {
                connection.Close();
            }

            try
            {
                //if (TableName.Length > 0)
                //{
                //    _DataSet.DataSetName = TableName;
                //}
                //else
                //{
                //    //_DataSet.DataSetName = GetTableNameFromQuery(aQuery);
                //}
            }
            catch { }

            return _DataSet;
        }


        //public DataSet SelectQueryDataSet(string aQuery) {
        //    DataSet _DataSet = new DataSet();
        //    DataTable _DataTable = SelectQuery(aQuery);
        //    _DataSet.Tables.Add(_DataTable);
        //    return _DataSet;
        //}

        public int ExcuteQuery(string aQuery)
        {
            int _count = 1;
            OracleConnection _connection = GetNewConnection();
            _connection.Open();
            OracleTransaction _trans = _connection.BeginTransaction();
            try
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.Connection = _connection;
                _cmd.Transaction = _trans;
                _cmd.CommandText = aQuery;
                _cmd.ExecuteNonQuery();
                _trans.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _trans.Rollback();
                _count = -1;
            }
            finally
            {
                _connection.Close();
            }

            return _count;
        }

        public int ExcuteArrayQuery(DbConnection _db_connection, ArrayList aQueryArray)
        {
            OracleConnection _connection = _db_connection as OracleConnection;
            if (m_sqlConnection.State == ConnectionState.Open)
            {
                _connection = GetNewConnection();
            }
            else
            {
                _connection = m_sqlConnection;
            }

            _connection.Open();
            OracleTransaction trans = _connection.BeginTransaction();
            int affectedRows = 0;
            try
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.Connection = _connection;
                _cmd.Transaction = trans;

                foreach (string query in aQueryArray)
                {
                    _cmd.CommandText = query;
                    _cmd.ExecuteNonQuery();
                    affectedRows += 1;
                }
                trans.Commit();

                _connection.Close();
            }
            catch //(OleDbException ex)
            {
                trans.Rollback();
            }
            finally
            {
                m_sqlConnection.Close();
            }

            return affectedRows;
        }

        public int ExcuteArrayQuery(ArrayList aQueryArray)
        {
            OracleConnection _connection;
            if (m_sqlConnection.State == ConnectionState.Open)
            {
                _connection = GetNewConnection();
            }
            else
            {
                _connection = m_sqlConnection;
            }

            _connection.Open();
            OracleTransaction trans = _connection.BeginTransaction();
            int affectedRows = 0;
            try
            {
                OracleCommand _cmd = new OracleCommand();
                _cmd.Connection = _connection;
                _cmd.Transaction = trans;

                foreach (string query in aQueryArray)
                {
                    _cmd.CommandText = query;
                    _cmd.ExecuteNonQuery();
                    affectedRows += 1;
                }
                trans.Commit();

                _connection.Close();
            }
            catch //(OleDbException ex)
            {
                trans.Rollback();
            }
            finally
            {
                m_sqlConnection.Close();
            }

            return affectedRows;
        }


        public int ExcuteCommand(SqlCommand aCommand)
        {
            ArrayList _CommandArray = new ArrayList();
            _CommandArray.Add(aCommand);
            return ExcuteArrayCommand(_CommandArray);
        }

        public int ExcuteArrayCommand(ArrayList aCommandArray)
        {
            OracleConnection _connection;
            if (m_sqlConnection.State == ConnectionState.Open)
            {
                _connection = GetNewConnection();
            }
            else
            {
                _connection = m_sqlConnection;
            }

            _connection.Open();
            OracleTransaction trans = _connection.BeginTransaction();
            int affectedRows = 0;
            try
            {
                foreach (OracleCommand _cmd in aCommandArray)
                {
                    _cmd.Connection = _connection;
                    _cmd.Transaction = trans;
                    affectedRows += _cmd.ExecuteNonQuery();
                    //idx += 1;
                }
                trans.Commit();
                _connection.Close();
            }
            catch (OracleException ex)
            {
                ////Console.WriteLine(ex.Message);
                ////Console.WriteLine("KOledb.cs 214~222 Line : Execute Ole Command Fail");
                trans.Rollback();
            }
            finally
            {
                m_sqlConnection.Close();
            }

            return affectedRows;
        }


        public object ExcuteScalar(DbConnection _db_connection, string aQuery)
        {
            object _result = null;
            DataRow _DataRow = ReadQuery(_db_connection, aQuery);
            if (_DataRow != null)
            {
                _result = _DataRow[0];
            }
            return _result;
        }

        public DataRow ReadQuery(DbConnection _db_connection, String aQuery)
        {
            DataRow _DataRow = null;
            DataTable _DataTable = SelectQuery(_db_connection, aQuery, "");
            if (_DataTable.Rows.Count > 0) { _DataRow = _DataTable.Rows[0]; }
            //_DataTable.Rows.InsertAt(_DataRow, 0);
            return _DataRow;
        }

    }
}
