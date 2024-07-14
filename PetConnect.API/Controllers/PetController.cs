using Microsoft.AspNetCore.Mvc;
using PetConnect.API.Contracts;
using PetConnect.Infrastructure;

namespace PetConnect.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase
{ 
    private readonly PetConnectDbContext _dbContext;

    public PetController(PetConnectDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }



    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePetRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }
}
