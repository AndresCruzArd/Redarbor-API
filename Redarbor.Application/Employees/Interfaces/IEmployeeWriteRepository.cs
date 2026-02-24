using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Redarbor.Domain.Entities;

namespace Redarbor.Application.Employees.Interfaces;

public interface IEmployeeWriteRepository
{
    Task<Employee> AddAsync(Employee employee);
    Task<Employee?> GetByIdAsync(int id);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(Employee employee);
    Task<Employee?> GetByUsernameAsync(string username);
}