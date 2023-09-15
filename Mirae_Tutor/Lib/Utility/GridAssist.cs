using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib.Utility
{
    public static class GridAssist
    {


        public static void SetAuto_GridView_FromSourceTable
            (DataGridView aGridView, DataTable aSourceDataTable, Dictionary<string, string> aDictionary = null)
        {
            DataTable _target_Table = GetTable_FromGrid(aGridView);
            _target_Table.Rows.Clear();

            foreach (DataRow _sourceDataRow in aSourceDataTable.Rows)
            {
                DataRow _target_Row = _target_Table.NewRow();
                foreach (DataColumn _target_Column in _target_Table.Columns)
                {
                    string _target_Name = _target_Column.ColumnName;
                    Type _target_Type = _target_Column.DataType;

                    if (aDictionary != null)
                    {
                        if (aDictionary.ContainsKey(_target_Name))
                        {
                            string _source_Name = aDictionary[_target_Name];
                            SetValue(_sourceDataRow[_source_Name], _target_Row, _target_Name, _target_Type);
                        }

                    }
                    else
                    {
                        if (aSourceDataTable.Columns.Contains(_target_Name))
                        { SetValue(_sourceDataRow[_target_Name], _target_Row, _target_Name, _target_Type); }
                    }
                }
                _target_Table.Rows.Add(_target_Row);
            }

        }

        private static DataRow GetTargetRow()
        {
            throw new NotImplementedException();
        }

        private static DataTable GetTable_FromGrid(DataGridView aGridView)
        {
            return (aGridView.DataSource as DataSet).Tables[aGridView.DataMember];
        }

        public static void SetValue(object aSrc, DataRow aTarRow, string aTarName, Type aTarType)
        {
            Type _SrcType = aSrc.GetType();
            //Type _TarType = aTar.GetType();
            if (_SrcType == aTarType)
            {
                aTarRow[aTarName] = aSrc;
            }
            else if (_SrcType == typeof(System.Decimal) && aTarType == typeof(System.Int32))
            {
                aTarRow[aTarName] = Convert.ToInt32(aSrc);
            }
            else if (_SrcType == typeof(System.Decimal) && aTarType == typeof(System.Double))
            {
                aTarRow[aTarName] = Convert.ToDouble(aSrc);
            }
        }

        public static String GetGridSortQuery(DataGridView aGirdView)
        {
            String _SortQuery = "";
            DataGridViewColumn _Column = aGirdView.SortedColumn;

            if (_Column != null)
            {
                String _SortFieldName = _Column.DataPropertyName;

                SortOrder _SortOrder = aGirdView.SortOrder;
                if (_SortOrder == SortOrder.Ascending)
                {
                    _SortQuery = String.Format(" {0} ASC", _SortFieldName);
                }
                else
                {
                    _SortQuery = String.Format(" {0} DESC", _SortFieldName);
                }
            }

            return _SortQuery;
        }

        public static DataRow SelectedRow(DataGridView aGridView)
        {
            DataRow _Row = null;
            DataTable _Table = null;
            String _TableName = aGridView.DataMember;
            if (aGridView.DataSource is DataSet)
            {
                DataSet _DataSet = aGridView.DataSource as DataSet;
                _Table = _DataSet.Tables[_TableName];
            }
            else if (aGridView.DataSource is DataTable)
            {
                _Table = aGridView.DataSource as DataTable;
            }

            if (_Table != null)
            {
                String _SortQuery = GetGridSortQuery(aGridView);
                DataRow[] _SortedRows = _Table.Select("", _SortQuery);

                int _SelectedIndex = -1;
                if (aGridView.CurrentRow != null)
                {
                    _SelectedIndex = aGridView.CurrentRow.Index;
                }

                if (_SelectedIndex >= 0 && _SelectedIndex < _SortedRows.Length)
                {
                    _Row = _SortedRows[_SelectedIndex];
                }

            }


            return _Row;
        }

        public static DataRow SelectedRow(DataGridView aGridView, int _SelectedIndex)
        {
            DataRow _Row = null;
            DataTable _Table = null;
            String _TableName = aGridView.DataMember;
            if (aGridView.DataSource is DataSet)
            {
                DataSet _DataSet = aGridView.DataSource as DataSet;
                _Table = _DataSet.Tables[_TableName];
            }
            else if (aGridView.DataSource is DataTable)
            {
                _Table = aGridView.DataSource as DataTable;
            }

            if (_Table != null)
            {
                String _SortQuery = GetGridSortQuery(aGridView);
                DataRow[] _SortedRows = _Table.Select("", _SortQuery);

                //int _SelectedIndex = -1;
                //if (aGridView.CurrentRow != null)
                //{
                //    _SelectedIndex = aGridView.CurrentRow.Index;
                //}

                if (_SelectedIndex >= 0 && _SelectedIndex < _SortedRows.Length)
                {
                    _Row = _SortedRows[_SelectedIndex];
                }

            }


            return _Row;
        }
        public static DataRow SortedRow(DataGridView aGridView, int _SelectedIndex)
        {
            DataRow _Row = null;
            DataTable _Table = null;
            String _TableName = aGridView.DataMember;
            if (aGridView.DataSource is DataSet)
            {
                DataSet _DataSet = aGridView.DataSource as DataSet;
                _Table = _DataSet.Tables[_TableName];
            }
            else if (aGridView.DataSource is DataTable)
            {
                _Table = aGridView.DataSource as DataTable;
            }
            if (_Table != null)
            {
                String _SortQuery = GetGridSortQuery(aGridView);
                DataRow[] _SortedRows = _Table.Select("", _SortQuery);

                if (_SelectedIndex >= 0 && _SelectedIndex < _SortedRows.Length)
                {
                    _Row = _SortedRows[_SelectedIndex];
                }
            }

            return _Row;
        }

        //public static void CheckRow(object sender, DataTable aTable, DataGridViewCellEventArgs e) { 
        //    DataGridView _GridView = (DataGridView)sender;
        //    object _source = _GridView.DataSource as object;
        //    if (_source == null) { } else if (_source is DataSet) { } else if (_source) { }
        //}

        //}
        //private void MainGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    int _iRow = e.RowIndex;
        //    int _iColumn = e.ColumnIndex;
        //    if (_iColumn == -1)
        //    {
        //        if (_iRow == -1)
        //        {
        //            m_grid_check_all = !m_grid_check_all;
        //            foreach (DataRow _src in DisplaySet.Tables["AccessGroupTable"].Rows)
        //            {
        //                _src["grd_select"] = m_grid_check_all;
        //            }
        //        }
        //        else
        //        {
        //            DataRow _row = GridAssist.SelectedRow(MainGridView);
        //            if (_row != null)
        //            {
        //                _row["grd_select"] = !Convert.ToBoolean(_row["grd_select"]);
        //            }
        //            bool _check_all = true;
        //            foreach (DataRow _src in DisplaySet.Tables["AccessGroupTable"].Rows)
        //            {
        //                if (Convert.ToBoolean(_src["grd_select"]) == false) { _check_all = false; break; }
        //            }
        //            m_grid_check_all = _check_all;
        //        }

        //        MainGridView.Invalidate();
        //    }
        //}

        //private void MainGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{

        //    Image _image = null;

        //    int _iRow = e.RowIndex;
        //    int _iColumn = e.ColumnIndex;
        //    if (_iColumn == -1)
        //    {
        //        if (_iRow == -1)
        //        {
        //            if (m_grid_check_all)
        //            {
        //                _image = (Image)(Properties.Resources.check);
        //            }
        //            else
        //            {
        //                _image = (Image)(Properties.Resources.uncheck);
        //            }
        //        }
        //        else
        //        {
        //            DataRow _r = GridAssist.SortedRow(MainGridView, _iRow);
        //            if (Convert.ToBoolean(_r["grd_select"]))
        //            {

        //                _image = (Image)(Properties.Resources.check);
        //            }
        //            else
        //            {
        //                _image = (Image)(Properties.Resources.uncheck);
        //            }
        //        }

        //        if (_image != null)
        //        {
        //            e.PaintBackground(e.CellBounds, false); // 클리어
        //            int _point_x = e.CellBounds.X + (e.CellBounds.Width - _image.Width) / 2;
        //            int _point_y = e.CellBounds.Y + (e.CellBounds.Height - _image.Height) / 2;

        //            e.Graphics.DrawImage(_image, _point_x, _point_y, 15, 15);
        //            e.Handled = true;
        //        }
        //    }


        //}

    }
}
