
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class UserController(DataContext dataContext) :BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        List<AppUser?> users = await dataContext.AppUsers.ToListAsync();
        return Ok(users);
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(int id)
    {
        AppUser? user = await dataContext.AppUsers.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}