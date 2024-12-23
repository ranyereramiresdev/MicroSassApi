using MicroSassApi.Helpers.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IAuthenticationHelper, AuthenticationHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();
