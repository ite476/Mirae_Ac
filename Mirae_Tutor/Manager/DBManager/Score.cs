using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_Tutor.Manager.DBManager
{
    internal class Score
    {
        public string StudentID;
        public string TestName;
        public DateTime Date;
        public int Korean;
        public int Math;
        public int English;
        public int History;
        public int Social;
        public int Science;

        public Score(string studentID, string testName, DateTime date, 
            int korean, int math, int english, int history, int social, int science)
        {
            StudentID = studentID;
            TestName = testName;
            Date = date;
            Korean = korean;
            Math = math;
            English = english;
            History = history;
            Social = social;
            Science = science;
        }

        public static Score 
            Convert_ToScore(string memberID, object selectedItem, DateTime theDateTime, 
            object Kor, object Mth, object Eng, object His, object Soc, object Sci)
        {
            try
            {
                return new Score(memberID, Convert.ToString(selectedItem), theDateTime,
                Convert.ToInt32(Kor), Convert.ToInt32(Mth), Convert.ToInt32(Eng),
                Convert.ToInt32(His), Convert.ToInt32(Soc), Convert.ToInt32(Sci));
            }
            catch 
            {
                throw new Exception("The Input is Not Convertible Into Int32!!");
            }            
        }

        public static Score GetScore(string sID, DataRow dr)
        {
            string 시험명 = Convert.ToString(dr["시험명"]);
            DateTime 시험일자 = Convert.ToDateTime(dr["시험일자"]);
            int 국어 = Convert.ToInt16(dr["국어"]);
            int 수학 = Convert.ToInt16(dr["수학"]);
            int 영어 = Convert.ToInt16(dr["영어"]);
            int 한국사 = Convert.ToInt16(dr["한국사"]);
            int 사회탐구 = Convert.ToInt16(dr["사회탐구"]);
            int 과학탐구 = Convert.ToInt16(dr["과학탐구"]);

            return new Score(sID, 시험명, 시험일자, 국어, 수학, 영어, 한국사, 사회탐구, 과학탐구);
        }
    }
}
