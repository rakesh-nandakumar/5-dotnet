namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int RegNo { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int MobilePhone { get; set; }
        public int HomePhone { get; set; }
        public string ParentName { get; set; } = string.Empty;
        public string NIC { get; set; } = string.Empty;
        public int ContactNo { get; set; }
    }
}
