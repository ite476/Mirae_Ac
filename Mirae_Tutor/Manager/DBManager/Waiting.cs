using System;
using System.Data;

namespace Mirae_Tutor.Manager.DBManager
{
    public class Waiting
    {
        public string Member_ID;
        public string Step;
        public int? Score;
        public string Name;
        public string Gender;
        public string Contact;
        public string Address;
        public string Picture;
        public string Parent_ID;
        public string Tutor_ID;

        public string Parent_Contact;
        public string Tutor_Name;

        public Waiting(
            string member_ID, string step, int? score,
            string name, string gender, string contact,
            string address, string picture, string parent_ID, 
            string tutor_ID, string parent_contact, string tutor_name)
        {
            Member_ID = member_ID;
            Step = step;
            Score = score;
            Name = name;
            Gender = gender;
            Contact = contact;
            Address = address;
            Picture = picture;
            Parent_ID = parent_ID;
            Tutor_ID = tutor_ID;
            Parent_Contact = parent_contact;
            Tutor_Name = tutor_name;
        }
        public Waiting(DataRow aDataRow)
        {

            Member_ID = GetString_FromNullableDBValue(aDataRow["아이디"]);
            Step = GetString_FromNullableDBValue(aDataRow["상태"]);
            Score = GetInt_FromNullableDBValue(aDataRow["입학 점수"]);
            Name = GetString_FromNullableDBValue(aDataRow["이름"]);
            Gender = GetString_FromNullableDBValue(aDataRow["성별"]);
            Contact = GetString_FromNullableDBValue(aDataRow["연락처"]);
            Address = GetString_FromNullableDBValue(aDataRow["주소"]);
            Picture = GetString_FromNullableDBValue(aDataRow["사진"]);
            Parent_ID = GetString_FromNullableDBValue(aDataRow["보호자 아이디"]);
            Tutor_ID = GetString_FromNullableDBValue(aDataRow["담당 선생님 아이디"]);
            Parent_Contact = GetString_FromNullableDBValue(aDataRow["보호자 연락처"]);
            Tutor_Name = GetString_FromNullableDBValue(aDataRow["담당 선생님"]);


        }

        private int? GetInt_FromNullableDBValue(object DBValue)
        {
            if (DBValue == DBNull.Value || DBValue == null)
            {
                return null;
            }
            return Convert.ToInt32(DBValue);
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
