namespace Mirae_admin.Manager.DBManager
{
    public class Tutor
    {
        public string Member_ID;
        public string Name;
        public string Gender;
        public string Contact;
        public string Address;
        public string Subject;
        public string Picture;
        public Tutor(string member_ID, string name, string gender, 
            string contact, string address, string subject, string picture)
        {
            Member_ID = member_ID;
            Name = name;
            Gender = gender;
            Contact = contact;
            Address = address;
            Subject = subject;
            Picture = picture;
        }
    }

}
