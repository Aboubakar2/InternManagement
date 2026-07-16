namespace InterManagement.Domain.Exceptions
{
    public class MentorNotFoundException : DomainException
    {
        public MentorNotFoundException(int id)
            : base($"Le mentor avec l'identifiant {id} est introuvable")
        { }
    }

    public class MentorAlreadyExistsException : DomainException
    {
        public MentorAlreadyExistsException(string email)
            : base($"Un mentor avec l'email {email} existe déjà")
        { }
    }

    public class MentorNotActiveException : DomainException
    {
        public MentorNotActiveException(int id)
            : base($"Le mentor avec l'identifiant {id} n'est pas actif")
        { }
    }
}