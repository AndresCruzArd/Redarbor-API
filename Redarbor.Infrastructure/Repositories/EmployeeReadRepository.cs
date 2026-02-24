using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Redarbor.Application.Employees.DTOs;
using Redarbor.Application.Employees.Interfaces;
using System.Data;

namespace Redarbor.Infrastructure.Repositories;

public class EmployeeReadRepository : IEmployeeReadRepository
{
    private readonly string _connectionString;

    public EmployeeReadRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
    {
        using var connection = Connection;

        var sql = @"SELECT Id, CompanyId, Email, PortalId, RoleId, StatusId, Username, CreatedOn
                    FROM Employees
                    WHERE DeletedOn IS NULL";

        return await connection.QueryAsync<EmployeeDto>(sql);
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        using var connection = Connection;

        var sql = @"SELECT Id, CompanyId, Email, PortalId, RoleId, StatusId, Username, CreatedOn
                    FROM Employees
                    WHERE Id = @Id AND DeletedOn IS NULL";

        return await connection.QueryFirstOrDefaultAsync<EmployeeDto>(sql, new { Id = id });
    }
}