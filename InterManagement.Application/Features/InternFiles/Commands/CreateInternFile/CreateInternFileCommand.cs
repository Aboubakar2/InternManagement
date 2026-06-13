using InterManagement.Application.Features.InternFiles.DTOs;

namespace InterManagement.Application.Features.InternFiles.Commands.CreateInternFile
{
    public class CreateInternFileCommand
    {
        public CreateInternFileDto Data { get; set; }

        public CreateInternFileCommand(CreateInternFileDto data)
        {
            Data = data;
        }
    }
}