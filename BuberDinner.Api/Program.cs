using BuberDinner.Api.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastucture;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastucture(builder.Configuration);
    builder.Services.AddControllers();
    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();

{

    app.UseExceptionHandler("/error");


    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}


