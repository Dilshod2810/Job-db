using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service.ApplicationService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController(IApplicationService applicationService) : ControllerBase
{
    [HttpGet("GetAlljobs")]
    public async Task<Response<List<Application>>> GetAll()
    {
        var response = await applicationService.GetAll();
        return response;
    }

    [HttpGet("GetById/{id}")]
    public async Task<Response<Application>> GetCarById(int id)
    {
        return applicationService.GetById(id).Result;
    }

    [HttpPost("AddApplication")]
    public async Task<Response<bool>> Create(Application application)
    {
        var response = await applicationService.Create(application);
        return response;
    }

    [HttpPut("UpdateApplication")]
    public async Task<Response<bool>> Update(Application application)
    {
        var response = await applicationService.Update(application);
        return response;
    }

    [HttpDelete("DeleteApplication")]
    public async Task<Response<bool>> Delete(int id)
    {
        var response = await applicationService.Delete(id);
        return response;
    }
}