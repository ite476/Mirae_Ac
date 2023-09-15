using System;
using System.Data;

namespace Mirae_Tutor.Manager.DBManager
{
    public class Course
    {
        public int HakGeup_Code { get; set; }
        public string HakGeup_Name { get; set; }
        public int Weekday { get; set; }
        public int Gyosi { get; set; }
        public string Tutor_id { get; set; }
        public string Tutor_Name { get; set; }
        public string Subject_Name { get; set; }
        public Course(int Code, int Weekday, int Gyosi, string name, string tutor_id, string tutor_name = null, string hakgeup_name = null)
        {
            this.HakGeup_Code = Code;
            this.Weekday = Weekday;
            this.Gyosi = Gyosi;
            this.Subject_Name = name;
            this.Tutor_id = tutor_id;
            this.Tutor_Name = tutor_name;
            this.HakGeup_Name = hakgeup_name;
        }
        public Course(DataRow aDataRow)
        {
            this.HakGeup_Code = Convert.ToInt32(aDataRow[0]);
            this.HakGeup_Name = Convert.ToString(aDataRow[1]);
            this.Weekday = Convert.ToInt32(aDataRow[2]);
            this.Gyosi = Convert.ToInt32(aDataRow[3]);
            this.Subject_Name = GetString_FromNullableDBValue(aDataRow["과목"]);
            this.Tutor_id = GetString_FromNullableDBValue(aDataRow["담당 선생님 아이디"]);
            this.Tutor_Name = GetString_FromNullableDBValue(aDataRow["담당 선생님"]);
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
