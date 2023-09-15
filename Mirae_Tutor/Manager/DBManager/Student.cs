using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mirae_Tutor.Manager.DBManager
{
    internal class Student
    {
        public string MemberID;
        public string Name;
        public string Gender;
        public string Contact;
        public string Address;
        public string Picture;
        public DateTime Date_Register;
        public int HakGeupCode;
        public string ParentID;
        public string HakGeupName { get; internal set; }
        public string ParentName { get; internal set; }
        public string ParentContact { get; internal set; }

        public Student(string 아이디, string 이름, string 성별, string 연락처, 
            string 주소, string 사진, DateTime 등록일, int 학급코드, string 보호자아이디,
            string 학급명, string 보호자연락처)
        {
            this.MemberID = 아이디;
            this.Name = 이름;
            this.Gender = 성별;
            this.Contact = 연락처;
            this.Address = 주소;
            this.Picture = 사진;
            this.Date_Register = 등록일;
            this.HakGeupCode = 학급코드;
            this.ParentID = 보호자아이디;

            this.HakGeupName = 학급명;
            this.ParentContact = 보호자연락처;
        }

    }
}
