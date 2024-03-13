using BuberDinner.Application;
using BuberDinner.Infrastucture;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastucture(builder.Configuration);
    // builder.Services.AddControllers(opt => opt.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();
    // builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build();

{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.Map("/error", (HttpContext context) =>
    {
        Exception? exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Results.Problem();
    });

    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}


