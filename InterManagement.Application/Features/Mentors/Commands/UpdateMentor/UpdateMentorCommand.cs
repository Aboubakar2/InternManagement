using InterManagement.Application.Features.Mentors.DTOs;

namespace InterManagement.Application.Features.Mentors.Commands.UpdateMentor
{
    public class UpdateMentorCommand
    {
        public int Id { get; set; }
        public UpdateMentorDto Data { get; set; }

        public UpdateMentorCommand(int id, UpdateMentorDto data)
        {
            Id   = id;
            Data = data;
        }
    }
}
