using Lib.Control;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
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
            DataTable _dt = App.Instance().DBManager.ReadHakgeup_All();

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

        public void Set_ImageAndTag_OnPictureBox(PictureBox aPbox, string _image_file = null)
        {
            byte[] _byte;

            if (_image_file == null || _image_file.Length == 0)
            {
                _byte = App.Instance().FileManager.HexStringToByteArray(App.Instance().FileManager.DefaultImage);
                aPbox.Tag = null;
            }
            else
            {
                _byte = App.Instance().FileManager.HexStringToByteArray(_image_file);
                aPbox.Tag = _image_file;
            }

            aPbox.Image = new Bitmap(new MemoryStream(_byte));
        }
    }
}
