using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.JobService;

public interface IJobService
{
    Task<Response<List<Job>>> GetAll();
    Task<Response<Job>> GetById(int id);
    Task<Response<bool>> Create(Job job);
    Task<Response<bool>> Update(Job job);
    Task<Response<bool>> Delete(int id);
}