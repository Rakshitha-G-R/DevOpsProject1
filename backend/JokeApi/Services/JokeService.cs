using MongoDB.Driver;
using JokeApi.Models;

namespace JokeApi.Services;

public class JokeService{
    private readonly IMongoCollection<Joke> _jokes;

    public JokeService(IMongoDatabase database){
        _jokes=database.GetCollection<Joke>("jokes");
    }

    public async Task<Joke> GetRandomJokeAsync(){
        var jokes = await _jokes.Find(_=>true).ToListAsync();
        var random = new Random().Next(jokes.Count);
        return jokes[random];
    }
}