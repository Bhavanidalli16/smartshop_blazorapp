using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartShop.AuthApi.Data;
using SmartShop.Shared;

namespace SmartShop.AuthApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AuthDbContext _context;

    public UsersController(AuthDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetUsers()
    {
        var users = await _context.Users.ToListAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult<User>> RegisterUser(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return Ok(user);
    }
}