using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;
using QuizApp.Api.Dtos;

namespace QuizApp.Api.Service;

public class AppUserService
{
    private readonly AppDbContext _db;
    public AppUserService(AppDbContext db) 
    {
        _db = db;
    }

    public async Task<AppUser> GetAppUserAsync(string userId)
    {
        var user = await _db.Users.FindAsync(userId);
        if (user != null)
        {
            return user;
        }
        throw new ArgumentException("userId not found");
    }
}

