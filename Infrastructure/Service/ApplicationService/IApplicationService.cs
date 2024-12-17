using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.ApplicationService;

public interface IApplicationService
{
    Task<Response<List<Application>>> GetAll();
    Task<Response<Application>> GetById(int id);
    Task<Response<bool>> Create(Application application);
    Task<Response<bool>> Update(Application application);
    Task<Response<bool>> Delete(int id);
}