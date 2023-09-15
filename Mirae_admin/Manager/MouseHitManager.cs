﻿using Lib.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiraePro.Manager
{
    internal class MouseHitManager
    {
        public void Show_CMenu_At_MouseCursor(MouseEventArgs e, DataGridView dataGridView, 
            out DataRow selectedDataRow, ContextMenuStrip contextMenuStrip, bool isTestRun = false)
        {
            DataGridView.HitTestInfo _hitTestInfo = dataGridView.HitTest(e.X, e.Y);
            if (isValidHit(dataGridView, out selectedDataRow, _hitTestInfo) || isTestRun)
            { contextMenuStrip.Show(dataGridView.PointToScreen(e.Location)); }
        }

        bool isValidHit(DataGridView theDataGridView, out DataRow selectedDataRow, 
            DataGridView.HitTestInfo theHitTestInfo)
        {
            bool isValidHit = false;
            selectedDataRow = null;
            if (theHitTestInfo != null)
            {
                int _row_index = theHitTestInfo.RowIndex;
                if (_row_index < theDataGridView.Rows.Count
                    && _row_index >= 0)
                {
                    theDataGridView.Rows[_row_index].Selected = true;
                    selectedDataRow = GridAssist.SelectedRow(theDataGridView, _row_index);
                    isValidHit = true;
                }
            }
            return isValidHit;
        }
    }
}
