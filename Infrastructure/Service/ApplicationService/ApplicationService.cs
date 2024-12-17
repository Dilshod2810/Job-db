using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service.ApplicationService;

public class ApplicationService(DapperContext context):IApplicationService
{
    public async Task<Response<List<Application>>> GetAll()
    {
        string sql = "select * from applications;";
        var res = await context.Connection().QueryAsync<Application>(sql);
        return new Response<List<Application>>(res.ToList());
    }

    public async Task<Response<Application>> GetById(int id)
    {
        string sql = "select * from applications where jobid = @Id";
        var res = await context.Connection().QuerySingleOrDefaultAsync<Application>(sql, new { Id = id });
        return res == null
            ? new Response<Application>(HttpStatusCode.NotFound, "Application not found")
            : new Response<Application>(HttpStatusCode.OK, "Application already exists");
    }

    public async Task<Response<bool>> Create(Application job)
    {
        string sql =
            "insert into applications(jobid, applicantid, resume, status, country, createdat, updatedat) values(@JobId, @ApplicantId, @Resume, @Status, @Country, @CreatedAt, @UpdatedAt);";
        var res = await context.Connection().ExecuteAsync(sql, job);
        return res == 0
            ? new Response<bool>(HttpStatusCode.Created, "Application is created successufully")
            : new Response<bool>(HttpStatusCode.NotFound, "Application is not created");
    }

    public async Task<Response<bool>> Update(Application job)
    {
        string sql =
            "update applications set jobid=@JobId, applicantid=@Title, resume=@Resume, status=@Status, createdat=@CreatedAt, updatedat=@UpdatedAt where applicantid=@ApplicantId;";
        var res = await context.Connection().ExecuteAsync(sql, job);
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "Application updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "Application not found");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        string sql = "delete from applications where applicantid=@Id;";
        var job = GetById(id).Result.Data;
        if (job == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "Application not found");
        }

        var res = await context.Connection().ExecuteAsync(sql, new { Id = id });
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "Application deleted")
            : new Response<bool>(HttpStatusCode.NotFound, "Application not found");
    }
}