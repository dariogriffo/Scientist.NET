using Microsoft.AspNetCore.Mvc;
using ScientistApp.Models;
using ScientistApp.Services;

namespace ScientistApp.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : Controller
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    [Route("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        User user = await _usersRepository.GetById(id);
        return Ok(user);
    }
}
