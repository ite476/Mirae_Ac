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

namespace Mirae_admin.Manager
{
    public class ComponentManager
    {
        public void SetCombobox_WithHakgeup(ComboBox aComboBox, bool includeALLCategory = false)
        {
            DataTable _dt = App.Instance().DBManager.HakGeup.Read_ALL();

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

        public void MouseHover_InteractiveControl(object sender)
        {
            if (sender is Control)
            {
                (sender as Control).BackColor = Color.LightGray;
            }
            
        }

        public void MouseLeave_InteractiveControl(object sender)
        {
            if(sender is Control)
            {
                (sender as Control).BackColor = SystemColors.Control;
            }            
        }

        public void Click_Label_ToShow_TextBox(object sender)
        {
            if (sender.GetType() != typeof(Label))
            {
                throw new Exception("Not A Label Called Click_Label_Show_TextBox");
            }
            Label senderLabel = sender as Label;
            senderLabel.Tag = ShowTextBox_OnLabel(senderLabel);
        }
        TextBox ShowTextBox_OnLabel(Label aLabel)
        {
            TextBox aTbox = new TextBox();

            aLabel.Visible = false;
            aLabel.Parent.Controls.Add(aTbox);

            aTbox.Location = aLabel.Location;
            aTbox.Size = aLabel.Size;
            aTbox.Dock = DockStyle.Fill;
            aTbox.Text = aLabel.Text;
            aTbox.Visible = true;
            aTbox.Tag = aLabel;
            aTbox.Focus();
            aTbox.BringToFront();

            aTbox.TextChanged += tbox_TextChanged;
            aTbox.KeyDown += Check_DoneEdit;

            return aTbox;
        }
        void tbox_TextChanged(object sender, EventArgs e)
        {
            tbox_TextChanged(sender, e, "");
        }
        void tbox_TextChanged(object sender, EventArgs e, string strDefault)
        {
            TextBox senderTbox = (sender as TextBox);
            if (senderTbox.Tag != null)
            {
                Label tagLabel = (senderTbox.Tag as Label);
                string theText = senderTbox.Text;
                if (theText == null || theText.Length == 0)
                {
                    tagLabel.Text = strDefault;
                }
                else
                {
                    tagLabel.Text = theText;
                }

            }
        }
        private void Check_DoneEdit(object sender, KeyEventArgs e)
        {
            if (isPressEnter(e))
            {
                TextBox senderTbox = (sender as TextBox);
                if (senderTbox.Tag != null)
                {
                    Label tagLabel = (senderTbox.Tag as Label);
                    tagLabel.Visible = true;
                }
                senderTbox.Visible = false;
            }
        }
        private bool isPressEnter(KeyEventArgs e)
        {
            return e.KeyCode == Keys.Enter;
        }

    }
}
