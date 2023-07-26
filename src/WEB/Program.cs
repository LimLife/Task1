using WEB.Middleware;
using Infrastructure;
using Application.Services;
using Application.Interfaces;
using Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IRepository, Repository>();
builder.Services.AddTransient<AddData>();
builder.Services.AddMvc();

builder.Services.AddCors(op =>
{ op.AddPolicy("Client", build => build.WithOrigins("http://localhost:3000")); });

builder.Services.AddDbContext<DBData>();

builder.Services.AddControllers();


var app = builder.Build();
app.UseMiddleware<DatabaseInitializationMiddleware>();

app.UseHttpsRedirection();
app.UseCors("Client");
app.UseRouting().UseEndpoints(e=>e.MapControllers());

app.Run();
