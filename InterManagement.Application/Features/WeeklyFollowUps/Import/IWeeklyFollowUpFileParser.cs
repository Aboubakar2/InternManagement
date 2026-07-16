using InterManagement.Application.Features.WeeklyFollowUps.Commands.ImportWeeklyFollowUps;

namespace InterManagement.Application.Features.WeeklyFollowUps.Import
{
    public interface IWeeklyFollowUpFileParser
    {
        
        Task<List<ParsedFollowUpRow>> ParseAsync(Stream fileStream, string fileExtension);
    }
}
