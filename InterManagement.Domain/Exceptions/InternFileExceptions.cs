namespace InterManagement.Domain.Exceptions
{
    public class InternFileNotFoundException : DomainException
    {
        public InternFileNotFoundException(int id)
            : base($"Le fichier avec l'ID {id} n'a pas été trouvé")
        { }
    }

    public class InternFileAlreadyExistsException : DomainException
    {
        public InternFileAlreadyExistsException(string fileName)
            : base($"Le fichier {fileName} existe déjà pour ce stagiaire")
        { }
    }

    public class InternFileTypeNotAllowedException : DomainException
    {
        public InternFileTypeNotAllowedException(string fileType)
            : base($"Le type de fichier {fileType} n'est pas autorisé")
        { }
    }
}