using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JokeApi.Models;

public class Joke
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id {get; set;}
    
    [BsonElement("text")]
    public string Text{get;set;}
}