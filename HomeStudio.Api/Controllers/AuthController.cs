using HomeStudio.Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace HomeStudio.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
 private readonly AppDbContext _db;
 private readonly ILogger<AuthController> _logger;

 public AuthController(AppDbContext db, ILogger<AuthController> logger)
 {
     _db = db;
     _logger = logger;
 }

 [HttpGet("me")]
 [Authorize]
 public async Task<IActionResult> Me()
    {
        var uid = User.FindFirst("user_id")?.Value;
        if (uid == null)
        {
            return Unauthorized();
        }
        var user = await _db.Users.FirstOrDefaultAsync(u => u.GoogleId == uid);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);      
    }
    
}