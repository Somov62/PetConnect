using Microsoft.AspNetCore.Mvc;
using PetConnect.API.Contracts;
using PetConnect.Domain;
using PetConnect.Infrastructure;

namespace PetConnect.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{ 
    private readonly PetConnectDbContext _dbContext;

    public PostController(PetConnectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }



    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }
}
