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

namespace Mirae_Tutor.Manager
{
    internal class ComponentManager
    {        
        internal void SetComboBox_AssignedHakGeup_BySessionID(ComboBox aComboBox)
        {
            string SID = App.Instance().SessionManager.SessionID;
            DataTable dt = App.Instance().DBManager.HakGeup.Read_ByTutorID(SID);
            int Count = App.Instance().DBManager.HakGeup.Read_Count(SID);
            
            aComboBox.Items.Clear();

            if (Count > 1)
            {
                ComboItem theComboItem = new ComboItem("전체", "");
                aComboBox.Items.Add(theComboItem);
            }            

            foreach(DataRow dr in dt.Rows)
            {
                string H_Code = Convert.ToString(dr["학급코드"]);
                string H_Name = Convert.ToString(dr["학급"]);
                ComboItem theComboItem = new ComboItem(H_Name, H_Code);
                aComboBox.Items.Add(theComboItem);
            }

            if (dt.Rows.Count > 0) { aComboBox.SelectedIndex = 0; }
        }

        internal void Set_ImageAndTag_OnPictureBox(PictureBox aPbox, string _image_file)
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

        internal void MouseHover_InteractiveControl(object sender)
        {
            if (sender is Control)
            {
                (sender as Control).BackColor = Color.LightGray;
            }

        }

        internal void MouseLeave_InteractiveControl(object sender)
        {
            if (sender is Control)
            {
                (sender as Control).BackColor = SystemColors.Control;
            }
        }


        public void Click_Label_Show_TextBox(object sender)
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
        public void tbox_TextChanged(object sender, EventArgs e)
        {
            tbox_TextChanged(sender, e, "");
        }
        public void tbox_TextChanged(object sender, EventArgs e, string strDefault)
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
