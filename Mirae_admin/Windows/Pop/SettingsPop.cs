using Lib.DB;
using Lib.Frame;
using Lib.Utility;
using Mirae_admin.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mirae_admin.Windows.Pop
{
    public partial class SettingsPop : MasterPop
    {
        public SettingsPop()
        {
            InitializeComponent();
            INIT_Setup();
        }
        private void INIT_Setup()
        {            
            ServerIP = App.Instance().db_IP;
            ServerPort = App.Instance().db_Port;
            DataBaseID = App.Instance().db_ID;
            DataBasePassword = App.Instance().db_Password;
            SchemaName = App.Instance().db_Schema;
        }

        string ServerIP { 
            get { return tbox_ServerIP.Text; } 
            set { tbox_ServerIP.Text = value; }
        }
        int ServerPort { 
            get { return Convert.ToInt32(tbox_ServerPort.Text); }
            set { tbox_ServerPort.Text = Convert.ToString(value); }
        }
        string DataBaseID { 
            get { return tbox_DataBaseID.Text; }
            set { tbox_DataBaseID.Text = value; }
        }
        string DataBasePassword { 
            get { return tbox_DataBasePassword.Text; }
            set { tbox_DataBasePassword.Text = value; }
        }
        string SchemaName { 
            get { return tbox_SchemaName.Text; }
            set { tbox_SchemaName.Text = value; }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            OracleAssist _OracleAssist = new OracleAssist(
                ServerIP, ServerPort, DataBaseID, DataBasePassword, SchemaName);
            bool _Success = _OracleAssist.TestConnection();
            if (_Success)
            {
                MessageBox.Show("오라클 접속성공");
            }
            else
            {
                MessageBox.Show("오라클 접속실패");
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            App.Instance().SetDBConfig(
                ServerIP, ServerPort, DataBaseID, DataBasePassword, SchemaName);
            DialogResult = DialogResult.OK;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
