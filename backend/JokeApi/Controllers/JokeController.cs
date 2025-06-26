

using Microsoft.AspNetCore.Mvc;
using JokeApi.Services;
using JokeApi.Models;
namespace JokeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JokesController : ControllerBase
{
    private readonly JokeService _jokeService;

    public JokesController(JokeService jokeService)
    {
        _jokeService = jokeService;
    }

    [HttpGet("random")]
    public async Task<ActionResult<Joke>> GetRandomJoke()
    {
        
        var joke = await _jokeService.GetRandomJokeAsync();
        return Ok(joke);
    }
}