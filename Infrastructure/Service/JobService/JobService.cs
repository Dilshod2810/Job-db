using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service.JobService;

public class JobService(DapperContext context) : IJobService
{
    public async Task<Response<List<Job>>> GetAll()
    {
        string sql = "select * from jobs;";
        var res = await context.Connection().QueryAsync<Job>(sql);
        return new Response<List<Job>>(res.ToList());
    }

    public async Task<Response<Job>> GetById(int id)
    {
        string sql = "select * from jobs where jobid = @Id";
        var res = await context.Connection().QuerySingleOrDefaultAsync<Job>(sql, new { Id = id });
        return res == null
            ? new Response<Job>(HttpStatusCode.NotFound, "Job not found")
            : new Response<Job>(HttpStatusCode.OK, "Job already exists");
    }

    public async Task<Response<bool>> Create(Job job)
    {
        string sql =
            "insert into jobs(employerid, title, description, salary, country, city, status, createdat, updatedat) values(@EmployerId, @Title, @Description, @Salary, @Country, @City, @Status, @CreatedAt, @UpdatedAt);";
        var res = await context.Connection().ExecuteAsync(sql, job);
        return res == 0
            ? new Response<bool>(HttpStatusCode.Created, "Job is created successufully")
            : new Response<bool>(HttpStatusCode.NotFound, "Job is not created");
    }

    public async Task<Response<bool>> Update(Job job)
    {
        string sql =
            "update jobs set employerid=@EmployerId, title=@Title, description=@Description, salary=@Salary, country=@Country, city=@City, status=@Status, createdat=@CreatedAt, updatedat=@UpdatedAt where jobid=@JobId;";
        var res = await context.Connection().ExecuteAsync(sql, job);
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "Job updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Job not found");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        string sql = "delete from jobs where jobid=@Id;";
        var job = GetById(id).Result.Data;
        if (job == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Job not found");
        }

        var res = await context.Connection().ExecuteAsync(sql, new { Id = id });
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "Job deleted")
            : new Response<bool>(HttpStatusCode.NotFound, "Job not found");
    }
}