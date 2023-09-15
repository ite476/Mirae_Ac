using System;
using System.Data;

namespace Mirae_Tutor.Manager.DBManager
{ 
    public class HakGeup
    {
        int HakGeup_Code;
        string HakGeup_Name;
        string Tutor_ID;
        string Tutor_Name;
        public HakGeup(int hakGeup_Code, string hakGeup_Name, string tutor_ID, string tutor_Name)
        {
            HakGeup_Code = hakGeup_Code;
            HakGeup_Name = hakGeup_Name;
            Tutor_ID = tutor_ID;
            Tutor_Name = tutor_Name;
        }
        public HakGeup(DataRow aDataRow)
        {
            HakGeup_Code = Convert.ToInt32(aDataRow["학급코드"]);
            HakGeup_Name = Convert.ToString(aDataRow["학급"]);
            Tutor_ID = GetString_FromNullableDBValue(aDataRow["담당 선생님 아이디"]);
            Tutor_Name = GetString_FromNullableDBValue(aDataRow["담당 선생님"]);
        }
        private string GetString_FromNullableDBValue(object DBValue)
        {
            if (DBValue == DBNull.Value || DBValue == null)
            {
                return null;
            }
            return Convert.ToString(DBValue);
        }
    }       
    
}
