using Microsoft.AspNetCore.Mvc;
using PetConnect.API.Contracts;
using PetConnect.Domain;
using PetConnect.Infrastructure;

namespace PetConnect.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{ 
    private readonly ApplicationContext _dbContext;

    public PostController(ApplicationContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }
}
