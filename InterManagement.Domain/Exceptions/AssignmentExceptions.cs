namespace InterManagement.Domain.Exceptions
{
    public class AssignmentNotFoundException : DomainException
    {
        public AssignmentNotFoundException(int id)
            : base($"L'affectation  avec cet Stagiaire {id} n'a pas été trouvée")
        { }
    }

    public class AssignmentAlreadyExistsException : DomainException
    {
        public AssignmentAlreadyExistsException(
            int traineeId, int mentorId, int phaseId)
            : base($"Une affectation existe déjà pour le stagiaire {traineeId}, le mentor {mentorId}, la phase {phaseId}")
        { }
    }

    public class AssignmentNotActiveException : DomainException
    {
        public AssignmentNotActiveException(int id)
            : base($"L'affectation  avec cet Stagiaire {id} n'est pas active")
        { }
    }
}