using System.Net;
using Dapper;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service.QueryService;

public class QueryService(DapperContext context):IQueryService
{
    public async Task<Response<int>> Average()
    {
        string sql = "select avg(salary) from jobs";
        var res = await context.Connection().ExecuteAsync(sql);
        return new Response<int>(res);
    }
    

    public async Task<Response<string>> Status(string status)
    {
        string sql = "select * from applications where status=@status";
        var res = await context.Connection().QueryAsync(sql, new { Status = status });
        return res == null
            ? new Response<string>(HttpStatusCode.NotFound, "Not found")
            : new Response<string>(HttpStatusCode.Found, "Found");

    }

    public async Task<Response<int>> Count(int id)
    {
        string sql = "select count(applicantid) from jobs where employerid=@id; ";
        var res = await context.Connection().ExecuteAsync(sql, new { Id = id });
        return new Response<int>(res);
    }

    public async Task<Response<decimal>> HighSalary()
    {
        string sql = "select * from jobs order by salary asc limit 1;";
        var res = await context.Connection().QuerySingleOrDefaultAsync<decimal>(sql);
        return new Response<decimal>(res);
    }

    public async Task<Response<decimal>> LowSalary()
    {
        string sql = "select * from jobs order by salary desc limit 1;";
        var res = await context.Connection().QuerySingleOrDefaultAsync<decimal>(sql);
        return new Response<decimal>(res);
    }

    // public async Task<Response<int>> CountCity(string city)
    // {
    //     string sql = "select count(applicationid)"
    // }
}