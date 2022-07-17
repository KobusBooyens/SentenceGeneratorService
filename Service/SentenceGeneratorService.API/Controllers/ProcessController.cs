using System.ComponentModel.DataAnnotations;
using Application;
using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SentenceGeneratorService.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProcessController : ControllerBase
  {
    private readonly IWordTypeRepositoryAsync _wordTypeRepositoryAsync;
    private readonly IWordLibraryRepositoryAsync _wordLibraryRepositoryAsync;
    private readonly IConstructedSentenceRepositoryAsync _constructedSentenceRepositoryAsync;

    public ProcessController(IWordTypeRepositoryAsync wordTypeRepositoryAsync, IWordLibraryRepositoryAsync wordLibraryRepositoryAsync, IConstructedSentenceRepositoryAsync constructedSentenceRepositoryAsync)
    {
      _wordTypeRepositoryAsync = wordTypeRepositoryAsync;
      _wordLibraryRepositoryAsync = wordLibraryRepositoryAsync;
      _constructedSentenceRepositoryAsync = constructedSentenceRepositoryAsync;
    }


    [HttpGet("SayHello")]
    public ActionResult SayHello()
    {
      return Ok("Hello from the ProcessController");
    }

    [HttpGet("GetWordTypeRepositories")]
    public async Task<ActionResult<WordTypeDto[]>> GetWordTypeRepositories()
    {
      try
      {
        var result = await _wordTypeRepositoryAsync.GetAllWordTypes();
        return result;
      }
      catch (Exception ex)
      {
        return BadRequest($"An error occurred while processing the request. Details: {ex.Message}.");
      }
    }

    [HttpGet("GetWordLibraryByWordType")]
    public async Task<ActionResult<string[]>> GetWordLibraryByWordType([Required]string wordType)
    {
      try
      {
        return await _wordLibraryRepositoryAsync.GetByWordType(wordType);
      }
      catch (Exception ex)
      {
        return BadRequest($"An error occurred while processing the request. Details: {ex.Message}.");
      }
    }

    [HttpPost("AddConstructedSentence")]
    public async Task<ActionResult> AddConstructedSentence([Required][FromBody] string sentence)
    {
      try
      {
        await _constructedSentenceRepositoryAsync.AddSentence(sentence);
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest($"An error occurred while processing the request. Details: {ex.Message}.");
      }
    }

    [HttpGet("GetAllConstructedSentences")]
    public async Task<ActionResult<ConstructedSentenceDto[]>> GetConstructedSentence()
    {
      try
      {
        return await _constructedSentenceRepositoryAsync.GetAll();
      }
      catch (Exception ex)
      {
        return BadRequest($"An error occurred while processing the request. Details: {ex.Message}.");
      }
    }
  }
}
