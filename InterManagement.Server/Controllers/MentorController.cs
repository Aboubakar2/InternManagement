using InterManagement.Application.Features.Mentors.Commands.CreateMentor;
using InterManagement.Application.Features.Mentors.Commands.UpdateMentor;
using InterManagement.Application.Features.Mentors.Commands.DeleteMentor;
using InterManagement.Application.Features.Mentors.Queries.GetMentors;
using InterManagement.Application.Features.Mentors.Queries.GetMentorById;
using InterManagement.Application.Features.Mentors.DTOs;
using InterManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace InterManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MentorController : ControllerBase
    {
        private readonly CreateMentorHandler  _createHandler;
        private readonly UpdateMentorHandler  _updateHandler;
        private readonly DeleteMentorHandler  _deleteHandler;
        private readonly GetMentorsHandler    _getHandler;
        private readonly GetMentorByIdHandler _getByIdHandler;

        public MentorController(
            CreateMentorHandler  createHandler,
            UpdateMentorHandler  updateHandler,
            DeleteMentorHandler  deleteHandler,
            GetMentorsHandler    getHandler,
            GetMentorByIdHandler getByIdHandler)
        {
            _createHandler  = createHandler;
            _updateHandler  = updateHandler;
            _deleteHandler  = deleteHandler;
            _getHandler     = getHandler;
            _getByIdHandler = getByIdHandler;
        }

        // GET api/mentor
        [HttpGet]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? department)
        {
            var query  = new GetMentorsQuery { Department = department };
            var result = await _getHandler.Handle(query);
            return Ok(result);
        }

        // GET api/mentor/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query  = new GetMentorByIdQuery(id);
            var result = await _getByIdHandler.Handle(query);
            return Ok(result);
        }

        // POST api/mentor
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateMentorDto dto)
        {
            var command = new CreateMentorCommand(dto);
            var result  = await _createHandler.Handle(command);
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        // PUT api/mentor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateMentorDto dto)
        {
            var command = new UpdateMentorCommand(id, dto);
            var result  = await _updateHandler.Handle(command);
            return Ok(result);
        }

        // DELETE api/mentor/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteMentorCommand(id);
            await _deleteHandler.Handle(command);
            return NoContent();
        }
    }
}
