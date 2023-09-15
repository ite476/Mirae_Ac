using Lib.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiraePro.Manager
{
    internal class ComponentManager
    {
        internal void SetCategoryCbox_WithHakgeup(ComboBox aComboBox, bool includeALLCategory = false)
        {
            DataTable _dt = App.Instance().DBManager.ReadHakgeup();

            aComboBox.Items.Clear();
            if (includeALLCategory) 
            { aComboBox.Items.Add(new ComboItem("전체", "")); }

            foreach (DataRow _dr in _dt.Rows)
            {
                string hakgeup_name = Convert.ToString(_dr["학급"]);
                string hakgeup_code = Convert.ToString(_dr["학급코드"]);
                aComboBox.Items.Add(new ComboItem(hakgeup_name, hakgeup_code));
            }

            if (_dt.Rows.Count > 0)
            { aComboBox.SelectedIndex = 0; }
        }
    }
}
