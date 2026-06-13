using InterManagement.Application.Features.InternFiles.DTOs;
using InterManagement.Domain.Exceptions;
using InterManagement.Domain.Repositories;

namespace InterManagement.Application.Features.InternFiles.Queries.GetInternFileById
{
    public class GetInternFileByIdHandler
    {
        private readonly IInternFileRepository _repository;

        public GetInternFileByIdHandler(
            IInternFileRepository repository)
        {
            _repository = repository;
        }

        public async Task<InternFileDto> Handle(
            GetInternFileByIdQuery query)
        {
            var file = await _repository
                .GetByIdAsync(query.Id);
            if (file == null)
                throw new InternFileNotFoundException(query.Id);

            return new InternFileDto
            {
                Id          = file.Id,
                FileName    = file.FileName,
                FilePath    = file.FilePath,
                FileType    = file.FileType,
                ImportedAt  = file.ImportedAt,
                TraineeId   = file.TraineeId,
                TraineeName = $"{file.Trainee.FirstName} {file.Trainee.LastName}"
            };
        }
    }
}
