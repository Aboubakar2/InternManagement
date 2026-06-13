namespace InterManagement.Application.Features.Phases.Queries.GetPhases
{
    public class GetPhasesQuery
    {
        public int? TraineeId { get; set; }
        // null    → toutes les phases
        // int     → phases d'un stagiaire précis
    }
}