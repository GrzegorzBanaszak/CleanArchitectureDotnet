using BuberDinner.Api;
using BuberDinner.Application;
using BuberDinner.Infrastucture;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastucture(builder.Configuration);
}

var app = builder.Build();

{

    app.UseExceptionHandler("/error");


    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}


