using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data;
using Lib.Frame;
using Lib.Utility;
using Mirae_Tutor.Manager.DBManager;

namespace Mirae_Tutor.Manager
{

    class App {

        private static App _instance;

        protected App() {
            InitializeManagers();
        }

        public static App Instance() {
            //다중쓰레드에서는 정상적으로 동작안하는 코드입니다. 
            //다중 쓰레드 경우에는 동기화가 필요합니다. 
            if (_instance == null) {
                _instance = new App();
            } 
            return _instance;
        }


        private MainForm m_MainForm;
        public MainForm MainForm {
            get { return m_MainForm; }
            set { m_MainForm = value; }
        }

        private DBManager.DBManager m_DBManager;
        public DBManager.DBManager DBManager
        {
            get { return m_DBManager; }
            set { m_DBManager = value; }
        }
        public SessionManager SessionManager { get; set; }
        public FileManager FileManager { get; set; }
        public ComponentManager ComponentManager { get; set; }
        public MouseHitManager MouseHitManager { get; set; }
        public Validator Validator { get; set; }
        internal void InitializeManagers()
        {
            this.DBManager = new DBManager.DBManager();
            this.SessionManager = new SessionManager();
            this.FileManager = new FileManager();
            this.ComponentManager = new ComponentManager();
            this.MouseHitManager = new MouseHitManager();
            this.Validator = new Validator();

            INIT_DBConnection_Settings();
        }
        private void INIT_DBConnection_Settings()
        {
            IniAssist vIniAssist = new IniAssist();
            vIniAssist.Path = System.IO.Directory.GetCurrentDirectory() + "/SchemaSetup.ini";

            if (!System.IO.File.Exists(vIniAssist.Path))
            {
                vIniAssist.WriteString("db", "IP", "192.168.0.13");
                vIniAssist.WriteInteger("db", "Port", 1521);
                vIniAssist.WriteString("db", "ID", "MiraeDB");
                vIniAssist.WriteString("db", "Password", "kb603");
                vIniAssist.WriteString("db", "Schema", "xe");
            }

            this.SetDBConfig(
                vIniAssist.ReadString("db", "IP"),
                vIniAssist.ReadInteger("db", "Port"),
                vIniAssist.ReadString("db", "ID"),
                vIniAssist.ReadString("db", "Password"),
                vIniAssist.ReadString("db", "Schema"));

            this.DBManager.SetConnectInfo(db_IP, db_Port, db_ID, db_Password, db_Schema);
        }


        //public bool ShowMessage(string message) {
        //    bool _bresult = true;
        //    if (m_MessageVisible) {
        //        MessagePop _pop = new MessagePop();
        //        _pop.Initialize(VSL.Windows.Frame.ePopMode.None, message);
        //        if (_pop.ShowDialog() != System.Windows.Forms.DialogResult.OK) { _bresult = false; } else { }
        //    }
        //    else { }
        //    return _bresult;
        //}

        private bool m_MessageVisible = false;
        public bool MessageVisible { get { return m_MessageVisible; } set { m_MessageVisible = value; } }

        

        void fun()
        {
            System.Data.OracleClient.OracleBFile test = null ;
            SqlCommand cmd = null ;
            DataRow dr = null ;
        }

        public string db_IP;
        public int db_Port;
        public string db_ID;
        public string db_Password;
        public string db_Schema;
        public void SetDBConfig(string aIP, int aPort, string aID, string aPassword, string aSchema)
        {
            IniAssist IniAssist = new IniAssist();
            IniAssist.WriteString("db", "IP", aIP);
            IniAssist.WriteInteger("db", "Port", aPort);
            IniAssist.WriteString("db", "ID", aID);
            IniAssist.WriteString("db", "Password", aPassword);
            IniAssist.WriteString("db", "Schema", aSchema);

            db_IP = aIP;
            db_Port = aPort;
            db_ID = aID;
            db_Password = aPassword;
            db_Schema = aSchema;

            this.DBManager.SetConnectInfo(db_IP, db_Port, db_ID, db_Password, db_Schema);
        }

        public void ShowError_OnConstruction() 
        {
            MessageBox.Show("미구현 기능입니다.");
        }

        

    }
}
