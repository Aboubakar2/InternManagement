using InterManagement.Application.Features.Mentors.DTOs;

namespace InterManagement.Application.Features.Mentors.Commands.CreateMentor
{
    public class CreateMentorCommand
    {
        public CreateMentorDto Data { get; set; }

        public CreateMentorCommand(CreateMentorDto data)
        {
            Data = data;
        }
    }
}
