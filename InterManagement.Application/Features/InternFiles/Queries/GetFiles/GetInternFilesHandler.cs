using InterManagement.Application.Features.InternFiles.DTOs;
using InterManagement.Domain.Entities;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.InternFiles.Queries.GetInternFiles
{
    public class GetInternFilesHandler
    {
        private readonly IInternFileRepository _repository;

        public GetInternFilesHandler(IInternFileRepository repository)
        {
            _repository = repository;   
        }

        public async Task<IEnumerable<InternFileDto>> Handle(
            GetInternFilesQuery query)
        {
            IEnumerable<InternFile> files;

            if (query.TraineeId.HasValue && query.FileType != null)
                files = await _repository.GetByTypeAsync(
                    query.TraineeId.Value,
                    query.FileType);
            else if (query.TraineeId.HasValue)
                files = await _repository
                    .GetByTraineeAsync(query.TraineeId.Value);
            else
                files = await _repository.GetAllAsync();

            return files.Select(f => new InternFileDto
            {
                Id          = f.Id,
                FileName    = f.FileName,
                FilePath    = f.FilePath,
                FileType    = f.FileType,
                ImportedAt  = f.ImportedAt,
                TraineeId   = f.TraineeId,
                TraineeName = $"{f.Trainee.FirstName} {f.Trainee.LastName}"
            });
        }
    }
}
