using InterManagement.Application.Features.Admins.Commands.CreateAdmin;
using InterManagement.Application.Features.Admins.Commands.UpdateAdmin;
using InterManagement.Application.Features.Admins.Commands.DeleteAdmin;
using InterManagement.Application.Features.Admins.Queries.GetAdmins;
using InterManagement.Application.Features.Admins.Queries.GetAdminById;
using InterManagement.Application.Features.Admins.DTOs;
using InterManagement.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace InterManagement.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly CreateAdminHandler  _createHandler;
        private readonly UpdateAdminHandler  _updateHandler;
        private readonly DeleteAdminHandler  _deleteHandler;
        private readonly GetAdminsHandler    _getHandler;
        private readonly GetAdminByIdHandler _getByIdHandler;

        public AdminController(
            CreateAdminHandler  createHandler,
            UpdateAdminHandler  updateHandler,
            DeleteAdminHandler  deleteHandler,
            GetAdminsHandler    getHandler,
            GetAdminByIdHandler getByIdHandler)
        {
            _createHandler  = createHandler;
            _updateHandler  = updateHandler;
            _deleteHandler  = deleteHandler;
            _getHandler     = getHandler;
            _getByIdHandler = getByIdHandler;
        }

        // GET api/admin
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query  = new GetAdminsQuery();
            var result = await _getHandler.Handle(query);
            return Ok(result);
        }

        // GET api/admin/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query  = new GetAdminByIdQuery(id);
            var result = await _getByIdHandler.Handle(query);
            return Ok(result);
        }

        // POST api/admin
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateAdminDto dto)
        {
            var command = new CreateAdminCommand(dto);
            var result  = await _createHandler.Handle(command);
            return CreatedAtAction(
                nameof(GetById),
                new { id = result.Id },
                result);
        }

        // PUT api/admin/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateAdminDto dto)
        {
            var command = new UpdateAdminCommand(id, dto);
            var result  = await _updateHandler.Handle(command);
            return Ok(result);
        }

        // DELETE api/admin/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAdminCommand(id);
            await _deleteHandler.Handle(command);
            return NoContent();
        }
    }
}
