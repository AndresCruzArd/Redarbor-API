using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Redarbor.Application.Employees.Interfaces;
using Redarbor.Domain.Entities;
using Redarbor.Infrastructure.Persistence;

namespace Redarbor.Infrastructure.Repositories;

public class EmployeeWriteRepository : IEmployeeWriteRepository
{
    private readonly RedarborDbContext _context;

    public EmployeeWriteRepository(RedarborDbContext context)
    {
        _context = context;
    }

    public async Task<Employee> AddAsync(Employee employee)
    {
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
        return employee;
    }

    public async Task<Employee?> GetByIdAsync(int id)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == id && e.DeletedOn == null);
    }

    public async Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Employee employee)
    {
        _context.Employees.Update(employee); // soft delete
        await _context.SaveChangesAsync();
    }

    public async Task<Employee?> GetByUsernameAsync(string username)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(x => x.Username == username && x.DeletedOn == null);
    }
}