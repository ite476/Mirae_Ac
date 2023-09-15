using Lib.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Manager
{
    internal class MouseHitManager
    {
        public void Show_CMenu_At_MouseCursor(MouseEventArgs e, DataGridView dataGridView, DataRow currentDataRow, ContextMenuStrip contextMenuStrip, bool isTestRun = false)
        {
            DataGridView.HitTestInfo _hitTestInfo = dataGridView.HitTest(e.X, e.Y);
            if (isValidHit(dataGridView, currentDataRow, _hitTestInfo) || isTestRun)
            { contextMenuStrip.Show(dataGridView.PointToScreen(e.Location)); }
        }

        bool isValidHit(DataGridView theDataGridView, DataRow currentDataRow, DataGridView.HitTestInfo theHitTestInfo)
        {
            bool isValidHit = false;
            if (theHitTestInfo != null)
            {
                int _row_index = theHitTestInfo.RowIndex;
                if (_row_index < theDataGridView.Rows.Count
                    && _row_index >= 0)
                {
                    theDataGridView.Rows[_row_index].Selected = true;
                    currentDataRow = GridAssist.SelectedRow(theDataGridView, _row_index);
                    isValidHit = true;
                }
            }
            return isValidHit;
        }
    }
}
