using Org.BouncyCastle.Crypto.Generators;
using Redarbor.Application.Employees.DTOs;
using Redarbor.Application.Employees.Interfaces;
using Redarbor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Application.Employees.Services
{
    public class AuthService
    {
        private readonly IEmployeeWriteRepository _writeRepository;

        public AuthService(IEmployeeWriteRepository writeRepository)
        {
            _writeRepository = writeRepository;
        }

        public async Task<Employee?> LoginAsync(LoginRequest request)
        {
            var employee = await _writeRepository.GetByUsernameAsync(request.Username);

            if (employee == null)
                return null;

            var isValid = BCrypt.Net.BCrypt.Verify(request.Password, employee.Password);
                       

            if (!isValid)
                return null;

            employee.RegisterLogin();
            await _writeRepository.UpdateAsync(employee);

            return employee;
        }
    }
}
