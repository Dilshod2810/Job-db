using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.Service.QueryService;
using Infrastructure.Service.UserService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QueryController(IQueryService queryService) : ControllerBase
{
    [HttpGet("Average")]
    public async Task<Response<int>> Average()
    {
        var response = await queryService.Average();
        return response;
    }


    [HttpGet("Status")]
    public async Task<Response<string>> Status(string status)
    {
        var response = await queryService.Status(status);
        return response;
    }

    [HttpGet("Count")]
    public async Task<Response<int>> Count(int id)
    {
        var response = await queryService.Count(id);
        return response;
    }

    // [HttpGet("DeleteUser")]
    // public async Task<Response<bool>> Delete(int id)
    // {
    //     var response = await queryService.Delete(id);
    //     return response;
    // }
    //
    //
    // [HttpGet("DeleteUser")]
    // public async Task<Response<bool>> Delete(int id)
    // {
    //     var response = await queryService.Delete(id);
    //     return response;
    // }
}