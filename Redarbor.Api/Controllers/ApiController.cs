using Microsoft.AspNetCore.Mvc;
using Redarbor.Application.Employees.DTOs;
using Redarbor.Application.Employees.Services;
using Redarbor.Infrastructure.Security;
using Swashbuckle.AspNetCore.Annotations;

namespace Redarbor.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(
            AuthService authService,
            JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        /// <summary>
        /// Autentica un usuario y genera un JWT válido.
        /// </summary>
        [HttpPost("login")]
        [SwaggerOperation(Summary = "➡  Autenticación de usuario y generación de JWT")] 
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var employee = await _authService.LoginAsync(request);

            if (employee == null)
                return Unauthorized("Credenciales inválidas");            

            var token = _jwtService.GenerateToken(employee);

            return Ok(new
            {
                token,
                username = employee.Username
            });
        }
    }
}