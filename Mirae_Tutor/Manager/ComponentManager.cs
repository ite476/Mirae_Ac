using Lib.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_Tutor.Manager
{
    internal class ComponentManager
    {
        internal void SetCategoryCbox(ComboBox aComboBox, bool isIncludingALLCategory = false)
        {
            DataTable _dt = App.Instance().DBManager.ReadCategory();

            aComboBox.Items.Clear();
            if (isIncludingALLCategory) 
            { aComboBox.Items.Add(new ComboItem("전체", "")); }

            foreach (DataRow _dr in _dt.Rows)
            {
                string _ctg_code = Convert.ToString(_dr["ctg_code"]);
                string _ctg_name = Convert.ToString(_dr["ctg_name"]);
                aComboBox.Items.Add(new ComboItem(_ctg_name, _ctg_code));
            }

            if (_dt.Rows.Count > 0)
            { aComboBox.SelectedIndex = 0; }
        }
    }
}
