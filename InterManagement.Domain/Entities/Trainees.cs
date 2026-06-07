using InterManagement.Domain.Exceptions;

namespace InterManagement.Domain.Entities
{
    public class Trainee :  User
    {
        
        public string University { get;  set; } = string.Empty;
        public string   Specialty { get;  set; } = string.Empty;
        public string Theme { get;  set;} = string.Empty;
        public DateOnly StartDate { get;  set; } 
        public DateOnly EndDate { get;  set; }
        public  TraineeStatus Status { get;  set;} = TraineeStatus.InProgress;

        public  Trainee () {}

        public Trainee (string firstName, string lastName, string email , string university, string specialite, string theme, DateOnly startDate, DateOnly endDate, TraineeStatus status)
            : base(firstName, lastName, email, UserRole.Trainee)    
        {
            
                    
                        // ── Champs obligatoires ────────────────────
            if (string.IsNullOrWhiteSpace(university))
                throw new DomainException("L'université est obligatoire");

            if (string.IsNullOrWhiteSpace(specialite))
                throw new DomainException("La spécialité est obligatoire");

            if (string.IsNullOrWhiteSpace(theme))
                throw new DomainException("Le thème est obligatoire");

            // ── Règle métier dates ─────────────────────
            if (endDate <= startDate)
                throw new DomainException("La date de fin doit être après la date de début");

            if (startDate < DateOnly.FromDateTime(DateTime.Today))
                throw new DomainException("La date de début ne peut pas être dans le passé");


            University = university;
            Specialty = specialite;
            Theme = theme;
            StartDate = startDate;
            EndDate = endDate;
            Status     = TraineeStatus.InProgress;


            




            
        }

        



    }


}
