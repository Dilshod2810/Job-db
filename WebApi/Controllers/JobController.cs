using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service.JobService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController(IJobService jobService) : ControllerBase
{
    [HttpGet("GetAllUsers")]
    public async Task<Response<List<Job>>> GetAll()
    {
        var response = await jobService.GetAll();
        return response;
    }

    [HttpGet("GetById/{id}")]
    public async Task<Response<Job>> GetCarById(int id)
    {
        return jobService.GetById(id).Result;
    }

    [HttpPost("AddJob")]
    public async Task<Response<bool>> Create(Job job)
    {
        var response = await jobService.Create(job);
        return response;
    }

    [HttpPut("UpdateJob")]
    public async Task<Response<bool>> Update(Job job)
    {
        var response = await jobService.Update(job);
        return response;
    }

    [HttpDelete("DeleteJob")]
    public async Task<Response<bool>> Delete(int id)
    {
        var response = await jobService.Delete(id);
        return response;
    }
}