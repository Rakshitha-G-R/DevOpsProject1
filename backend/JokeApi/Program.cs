

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

app.UseHttpsRedirection();
// app.UseCors(cors=>cors.WithOrigins("Frontend URL").AllowAnyMethod().AllowAnyHeader());
app.UseCors(cors=>cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

// app.UseAuthorization();
app.MapControllers();

app.Run();