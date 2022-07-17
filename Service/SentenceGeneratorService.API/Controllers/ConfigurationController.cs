using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SentenceGeneratorService.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ConfigurationController : ControllerBase
  {
    private readonly IWordTypeRepositoryAsync _wordTypeRepositoryAsync;

    public ConfigurationController(IWordTypeRepositoryAsync wordTypeRepositoryAsync)
    {
      _wordTypeRepositoryAsync = wordTypeRepositoryAsync;
    }

    [HttpGet("SeedData")]
    public async Task<ActionResult> SeedData()
    {
      await _wordTypeRepositoryAsync.SeedData();
      return Ok();
    }
  }
}
