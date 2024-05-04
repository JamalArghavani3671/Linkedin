using DatabaseSharding.Entities;
using DatabaseSharding.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseSharding.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync(
        [FromServices] IDictionary<string, IUserRepository> repositories,
        CreateUserRequest request)
    {
        // Define shardName for user - for example master
        var repository = repositories.FirstOrDefault(d => d.Key == request.ShardName.ToString()).Value;

        var user = new User()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            About = request.About
        };

        repository.Insert(user);
        await repository.SaveContextAsync();

        return Ok();
    }
}
