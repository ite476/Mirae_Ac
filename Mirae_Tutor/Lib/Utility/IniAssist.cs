using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using static System.Collections.Specialized.BitVector32;

namespace Lib.Utility {

    class IniAssist {
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileSection(string lpAppName, byte[] lpReturnedString, int nSize, string lpFileName);

        private string m_Path = @"c:\\test.ini";

        public string Path {
            get { return m_Path; }
            set { m_Path = value; }
        }

        //m_iniAssist = new IniAssist();
        //m_iniAssist.Path = System.IO.Directory.GetCurrentDirectory() + "/information.ini";

        public IniAssist() {
        }

        public IniAssist(String aPath) {
            m_Path = aPath;
        }

        /*
        // INI파일읽기함수(섹션설정)
        public string[] GetIniValue1(string Section)

        {

            byte[] ba = new byte[255];

            uint Flag = GetPrivateProfileSection(Section, ba, 255, Path);

            return Encoding.Default.GetString(ba).Split(new char[1] { '\0' }, StringSplitOptions.RemoveEmptyEntries);

        }
        */


        // INI파일읽기함수(섹션,키값설정)
        public string GetIniValue(string Section, string Key) {

            StringBuilder sb = new StringBuilder(500);

            int Flag = GetPrivateProfileString(Section, Key, "", sb, 500, Path);

            return sb.ToString();

        }



        // INI파일쓰기함수(섹션,키값설정)
        public long SetIniValue(string Section, string Key, string Value) {
            return (WritePrivateProfileString(Section, Key, Value, Path));
        }

        public long WriteString(string aSection, string aKey, string aValue) {
            return (WritePrivateProfileString(aSection, aKey, aValue, Path));
        }

        public long WriteInteger(string aSection, string aKey, int aValue) {
            return (WritePrivateProfileString(aSection, aKey, aValue.ToString(), Path));
        }
        public string ReadString(string aSection, string aKey, string aDefault) {
            StringBuilder sb = new StringBuilder(500);

            int Flag = GetPrivateProfileString(aSection, aKey, aDefault, sb, 500, Path);

            return sb.ToString();
        }
        public String ReadString(string Section, string Key) {

            StringBuilder sb = new StringBuilder(500);

            int Flag = GetPrivateProfileString(Section, Key, "", sb, 500, Path);

            return sb.ToString();
        }

        public int ReadInteger(string Section, string Key) {
            StringBuilder sb = new StringBuilder(500);

            int Flag = GetPrivateProfileString(Section, Key, "", sb, 500, Path);
            String _strBuffer = sb.ToString();
            if (_strBuffer.Length > 0) {
                return Convert.ToInt32(_strBuffer);
            }
            else { return 0; }
        }

        public int ReadInteger(string Section, string Key, int aDefault) {
            StringBuilder sb = new StringBuilder(500);

            int Flag = GetPrivateProfileString(Section, Key, aDefault.ToString(), sb, 500, Path);
            String _strBuffer = sb.ToString();
            if (_strBuffer.Length > 0) {
                return Convert.ToInt32(_strBuffer);
            }
            else { return 0; }
        }
    }
}
