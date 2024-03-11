using BuberDinner.Application.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string email, string password)
    {



        return new AuthenticationResult(Guid.NewGuid(), "Jan", "Kowalski", email, "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {

        //Check if user already exist

        //Create user

        //Create JWT token
        Guid userId = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationResult(userId, firstName, lastName, email, token);
    }
}
