using Domain.Models;
using Infrastructure.ApiResponse;

namespace Infrastructure.Service.UserService;

public interface IUserService
{
    Task<Response<List<User>>> GetAll();
    Task<Response<User>> GetById(int id);
    Task<Response<bool>> Create(User user);
    Task<Response<bool>> Update(User user);
    Task<Response<bool>> Delete(int id);
}