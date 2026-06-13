namespace InterManagement.Domain.Exceptions
{
    public class FeedbackNotFoundException : DomainException
    {
        public FeedbackNotFoundException(int id)
            : base($"Feedback with Id {id} was not found")
        { }
    }
}