

using JokeApi.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

var mongoClient=new MongoClient(builder.Configuration["MongoDB:ConnectionString"]);
var mongoDatabase=mongoClient.GetDatabase(builder.Configuration["MongoDB:DatabaseName"]);

builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);
builder.Services.AddSingleton<JokeService>();

builder.Services.AddControllers();

builder.Services.AddCors();

var app=builder.Build();

app.UseCors(cors=>cors.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
// app.UseCors(cors=>cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();