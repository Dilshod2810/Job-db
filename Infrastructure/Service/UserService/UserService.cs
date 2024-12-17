using System.Net;
using Dapper;
using Domain.Models;
using Infrastructure.ApiResponse;
using Infrastructure.DataContext;

namespace Infrastructure.Service.UserService;

public class UserService(DapperContext context):IUserService
{
    public async Task<Response<List<User>>> GetAll()
    {
        string sql = "select * from users;";
        var res = await context.Connection().QueryAsync<User>(sql);
        return new Response<List<User>>(res.ToList());
    }

    public async Task<Response<User>> GetById(int id)
    {
        string sql = "select * from users where userid = @Id";
        var res = await context.Connection().QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        return res == null
            ? new Response<User>(HttpStatusCode.NotFound, "User not found")
            : new Response<User>(HttpStatusCode.OK, "User already exists");
    }

    public async Task<Response<bool>> Create(User user)
    {
        string sql =
            "insert into users(fullname, email, phone, role, createdat) values(@FullName, @Email, @Phone, @Role, @CreatedAt);";
        var res = await context.Connection().ExecuteAsync(sql, user);
        return res == 0
            ? new Response<bool>(HttpStatusCode.Created, "User is created successufully")
            : new Response<bool>(HttpStatusCode.NotFound, "User is not created");
    }

    public async Task<Response<bool>> Update(User user)
    {
        
        string sql = "update users set fullname=@FullName, email=@Email, phone=@Phone, role=@Role, createdat=@CreateAt where userid=@UserId;";
        var res = await context.Connection().ExecuteAsync(sql, user);
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "User updated successfully")
            : new Response<bool>(HttpStatusCode.NotFound, "User not found");
    }

    public async Task<Response<bool>> Delete(int id)
    {
        string sql = "delete from users where userid=@Id;";
        var user = GetById(id).Result.Data;
        if (user == null)
        {
            return new Response<bool>(HttpStatusCode.NotFound, "User not found");
        }

        var res = await context.Connection().ExecuteAsync(sql, new { Id = id });
        return res > 0
            ? new Response<bool>(HttpStatusCode.OK, "User deleted")
            : new Response<bool>(HttpStatusCode.NotFound, "User not found");
    }
}