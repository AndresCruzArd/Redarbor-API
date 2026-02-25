using Redarbor.Domain.Entities;

namespace Redarbor.Domain.Interfaces;

public interface IJobRepository
{
    Task<Job?> GetById(int id);
}