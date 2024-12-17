using Infrastructure.ApiResponse;

namespace Infrastructure.Service.QueryService;

public interface IQueryService
{
    Task<Response<int>> Average();
    Task<Response<string>> Status(string status);
    Task<Response<int>> Count(int id);
    Task<Response<decimal>> HighSalary();
    Task<Response<decimal>> LowSalary();
    // Task<Response<int>> CountCity();
}