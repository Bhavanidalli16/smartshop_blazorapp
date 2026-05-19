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
    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(User loginUser)
    {
        var user = await _context.Users.FirstOrDefaultAsync(
            u => u.Email == loginUser.Email &&
                 u.Password == loginUser.Password);

        if (user == null)
        {
            return Unauthorized("Invalid Email or Password");
        }

        return Ok(user);
    }
}