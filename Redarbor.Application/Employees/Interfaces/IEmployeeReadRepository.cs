using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Redarbor.Application.Employees.DTOs;

namespace Redarbor.Application.Employees.Interfaces;

public interface IEmployeeReadRepository
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync();
    Task<EmployeeDto?> GetByIdAsync(int id);
}