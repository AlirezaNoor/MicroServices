using Identity.API.GrpcServices;
using IdentityService.Application.DependecyInjection;
using IdentityService.Configuration;
using IdentiyService.Infrustructure.DependecyEnjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.DependecyEnjectionsMethod(builder.Configuration);
builder.Services.JWTConfigration(builder.Configuration);
builder.Services.UsermethodDependecy();
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting(); // UseRouting باید قبل از UseEndpoints فراخوانی شود
 
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<PermissionService>();
});

app.Run();
