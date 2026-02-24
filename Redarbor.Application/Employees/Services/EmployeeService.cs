using Redarbor.Application.Employees.DTOs;
using Redarbor.Application.Employees.Interfaces;
using Redarbor.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Application.Employees.Services;

public class EmployeeService
{
    private readonly IEmployeeWriteRepository _writeRepository;
    private readonly IEmployeeReadRepository _readRepository;

    public EmployeeService(
        IEmployeeWriteRepository writeRepository,
        IEmployeeReadRepository readRepository)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
    }

    public async Task<EmployeeDto> CreateAsync(CreateEmployeeRequest request)
    {
        ValidateCreateRequest(request);

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var employee = new Employee(
            request.CompanyId,
            request.Email,
            hashedPassword, 
            request.PortalId,
            request.RoleId,
            request.StatusId,
            request.Username,
            request.Fax,
            request.Name,
            request.Telephone
        );

        var created = await _writeRepository.AddAsync(employee);

        return new EmployeeDto
        {
            Id = created.Id,
            CompanyId = created.CompanyId,
            Email = created.Email,
            PortalId = created.PortalId,
            RoleId = created.RoleId,
            StatusId = created.StatusId,
            Username = created.Username,
            CreatedOn = created.CreatedOn,
            Name = created.Name,
            Fax = created.Fax,
            Telephone = created.Telephone
        };
    }

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        => await _readRepository.GetAllAsync();

    public async Task<EmployeeDto?> GetByIdAsync(int id)
        => await _readRepository.GetByIdAsync(id);

    public async Task UpdateAsync(int id, UpdateEmployeeRequest request)
    {
        var employee = await _writeRepository.GetByIdAsync(id); 

        if (employee is null)
            throw new Exception("Employee not found");

        if (request.CompanyId.HasValue)
            employee.UpdateCompany(request.CompanyId.Value);

        if (!string.IsNullOrWhiteSpace(request.Email))
            employee.UpdateEmail(request.Email);

        if (request.PortalId.HasValue)
            employee.UpdatePortal(request.PortalId.Value);

        if (request.RoleId.HasValue)
            employee.UpdateRole(request.RoleId.Value);

        if (request.StatusId.HasValue)
            employee.UpdateStatus(request.StatusId.Value);

        if (!string.IsNullOrWhiteSpace(request.Username))
            employee.UpdateUsername(request.Username);

        if (!string.IsNullOrWhiteSpace(request.Name))
            employee.UpdateName(request.Name);

        if (!string.IsNullOrWhiteSpace(request.Fax))
            employee.UpdateFax(request.Fax);

        if (!string.IsNullOrWhiteSpace(request.Telephone))
            employee.UpdateTelephone(request.Telephone);       

        await _writeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _writeRepository.GetByIdAsync(id);

        if (employee is null)
            throw new Exception("Employee not found");

        employee.DeleteOn();

        await _writeRepository.DeleteAsync(employee);
    }

    public async Task ChangePasswordAsync(int id, ChangePasswordRequest request)
    {
        var employee = await _writeRepository.GetByIdAsync(id);

        if (employee is null)
            throw new Exception("Employee not found");

        if (request.NewPassword.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters");

        if (request.NewPassword != request.ConfirmNewPassword)
            throw new ArgumentException("Passwords do not match");

        if (!BCrypt.Net.BCrypt.Verify(request.CurrentPassword, employee.Password))
            throw new UnauthorizedAccessException("Invalid credentials");

        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);

        employee.UpdatePassword(hashedPassword);

        await _writeRepository.UpdateAsync(employee);
    }

    private void ValidateCreateRequest(CreateEmployeeRequest request)
    {
        if (request.CompanyId <= 0)
            throw new ArgumentException("CompanyId is required");

        if (string.IsNullOrWhiteSpace(request.Email))
            throw new ArgumentException("Email is required");

        if (string.IsNullOrWhiteSpace(request.Password))
            throw new ArgumentException("Password is required");

        if (request.PortalId <= 0)
            throw new ArgumentException("PortalId is required");

        if (request.RoleId <= 0)
            throw new ArgumentException("RoleId is required");

        if (request.StatusId <= 0)
            throw new ArgumentException("StatusId is required");

        if (string.IsNullOrWhiteSpace(request.Username))
            throw new ArgumentException("Username is required");

        if (string.IsNullOrWhiteSpace(request.Name))
            throw new ArgumentException("Username is required");

        if (string.IsNullOrWhiteSpace(request.Fax))
            throw new ArgumentException("Username is required");

        if (string.IsNullOrWhiteSpace(request.Telephone))
            throw new ArgumentException("Username is required");
    }
}