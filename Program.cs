using MicroSassApi.Helpers.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
// Configure the HTTP request pipeline.

app.Run();
