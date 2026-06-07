using InterManagement.Domain.Exceptions;



namespace InterManagement.Domain.Entities
{
    public class Mentor : User
    {
        public string  Department { get; set; } = string.Empty;
        public string Speciality { get; set; } = string.Empty;

        public Mentor () {}

        public Mentor (string firstName, string lastName, string email, string department, string speciality)
            : base(firstName, lastName, email, UserRole.Mentor) 
        {
            Department = department;
            Speciality = speciality;
        }
    
    }

}