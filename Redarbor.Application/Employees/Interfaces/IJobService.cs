using Redarbor.Application.Employees.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redarbor.Application.Employees.Interfaces
{
    public interface IJobService
    {
        Task<JobDto> GetById(int id);
    }
}
