using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Redarbor.Application.Employees.DTOs;
using Redarbor.Application.Employees.Services;

namespace Redarbor.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeService _service;

    public EmployeesController(EmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "➡  Obtiene la lista completa de empleados")]
    public async Task<IActionResult> GetAll()
    {
        var employees = await _service.GetAllAsync();
        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    [SwaggerOperation(Summary = "➡  Obtiene un empleado por su ID")]
    public async Task<IActionResult> GetById(int id)
    {
        var employee = await _service.GetByIdAsync(id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [AllowAnonymous] // solo para hacer pruebas de creacion
    [HttpPost]
    [SwaggerOperation(Summary = "➡  Crea un nuevo empleado")]
    public async Task<IActionResult> Create([FromBody] CreateEmployeeRequest request)
    {
        var result = await _service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut("{id:int}")]
    [SwaggerOperation(Summary = "➡  Actualiza un empleado existente")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeRequest request)
    {
        await _service.UpdateAsync(id, request);
        return NoContent();
    }

    [HttpPut("{id:int}/change-password")]
    [SwaggerOperation(Summary = "➡  Cambia la contraseña de un empleado")]
    public async Task<IActionResult> ChangePassword(int id, [FromBody] ChangePasswordRequest request)
    {
        await _service.ChangePasswordAsync(id, request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    [SwaggerOperation(Summary = "➡  Elimina un empleado (soft delete)")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}