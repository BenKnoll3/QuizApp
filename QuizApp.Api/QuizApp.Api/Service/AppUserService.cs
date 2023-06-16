<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;

namespace QuizApp.Api.Service;

public class AppUserService
{
    private readonly AppDbContext _db;
    public AppUserService(AppDbContext db) 
    {
        _db = db;
    }

    public async Task<AppUser> GetAppUserAsync(string userName)
    {
        var user = await _db.Users
            .Where(u => u.UserName == userName)
            .Include(u => u.Decks)
            .FirstOrDefaultAsync();
        if (user != null)
        {
            return user;
        }
        throw new ArgumentException("user with userName not found");
    }
    public async Task<AppUser> GetAppUserIdAsync(string userId)
    {
        var user = await _db.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Decks)
            .ThenInclude(c => c.Cards)
            .FirstOrDefaultAsync();
        if (user != null)
        {
            return user;
        }
        throw new ArgumentException("user with userName not found");
    }
}

=======
﻿using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Data;

namespace QuizApp.Api.Service;

public class AppUserService
{
    private readonly AppDbContext _db;
    public AppUserService(AppDbContext db) 
    {
        _db = db;
    }

    public async Task<AppUser> GetAppUserAsync(string userName)
    {
        var user = await _db.Users
            .Where(u => u.UserName == userName)
            .Include(u => u.Decks)
            .FirstOrDefaultAsync();
        if (user != null)
        {
            return user;
        }
        throw new ArgumentException("user with userName not found");
    }
    public async Task<AppUser> GetAppUserIdAsync(string userId)
    {
        var user = await _db.Users
            .Where(u => u.Id == userId)
            .Include(u => u.Decks)
            .ThenInclude(c => c.Cards)
            .FirstOrDefaultAsync();
        if (user != null)
        {
            return user;
        }
        throw new ArgumentException("user with userName not found");
    }
}

>>>>>>> main
