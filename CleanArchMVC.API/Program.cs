using CleanArchMVC.Domain.Account;
using CleanArchMVC.Infra.Ioc;
using Microsoft.AspNetCore.Mvc.Formatters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJwt(builder.Configuration);
builder.Services.AddInfrastructureSwagger();

builder.Services.AddControllers(
    options => options.OutputFormatters.RemoveType<StringOutputFormatter>()
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());


SeedUserRoles(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedUserRoles(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.CreateScope())
    {
        var seed = serviceScope.ServiceProvider
                               .GetService<ISeedUserRoleInitial>();
        seed?.SeedUsers();
        seed?.SeedRoles();
    }
}
