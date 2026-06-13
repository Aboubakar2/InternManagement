namespace InterManagement.Domain.Exceptions
{
    public class PhaseNotFoundException : DomainException
    {
        public PhaseNotFoundException(int id)
            : base($"Phase avec Id {id} est introuvable")
        { }
    }

    public class PhaseAlreadyCompletedException : DomainException
    {
        public PhaseAlreadyCompletedException(int id)
            : base($"Phase avec Id {id} est déjà terminée")
        { }
    }

    public class PhaseCancelledException : DomainException
    {
        public PhaseCancelledException(int id)
            : base($"Phase avec Id {id} est annulée")
        { }
    }
}
