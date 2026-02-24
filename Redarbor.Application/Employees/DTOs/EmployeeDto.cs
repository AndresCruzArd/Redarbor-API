using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Application.Employees.DTOs;

public class EmployeeDto
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Email { get; set; }
    public int PortalId { get; set; }
    public int RoleId { get; set; }
    public int StatusId { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Fax{ get; set; }
    public string Telephone { get; set; }
    public DateTime CreatedOn { get; set; }
}