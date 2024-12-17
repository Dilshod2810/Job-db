using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet("GetAllUsers")]
    public async Task<Response<List<User>>> GetAll()
    {
        var response = await userService.GetAll();
        return response;
    }
    [HttpGet("GetById/{id}")]
    public async Task<Response<User>> GetCarById(int id)
    {
        return userService.GetById(id).Result;
    }

    [HttpPost("AddUser")]
    public async Task<Response<bool>> Create(User user)
    {
        var response = await userService.Create(user);
        return response;
    }

    [HttpPut("UpdateUser")]
    public async Task<Response<bool>> Update(User user)
    {
        var response = await userService.Update(user);
        return response;
    }

    [HttpDelete("DeleteUser")]
    public async Task<Response<bool>> Delete(int id)
    {
        var response = await userService.Delete(id);
        return response;
    }
}