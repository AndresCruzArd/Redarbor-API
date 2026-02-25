using Redarbor.Application.Employees.DTOs;
using Redarbor.Application.Employees.Interfaces;
using Redarbor.Domain.Interfaces;
namespace Redarbor.Application.Services;

public class JobService : IJobService
{
    private readonly IJobRepository _repository;

    public JobService(IJobRepository repository)
    {
        _repository = repository;
    }

    public async Task<JobDto> GetById(int id)
    {
        var job = await _repository.GetById(id);

        if (job == null)
            throw new Exception("Job not found");

        return new JobDto(job.Id, job.Title);
    }
}