using BuberDinner.Application;
using BuberDinner.Infrastucture;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication().AddInfrastucture();
    builder.Services.AddControllers();

}

var app = builder.Build();

{
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}


