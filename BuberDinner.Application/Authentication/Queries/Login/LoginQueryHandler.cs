using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //1. Validate the user exist
        if (_userRepository.GetUserByEmail(request.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredential;
        }
        //2. Validate the password is correct
        if (user.Password != request.Password)
        {
            return Errors.Authentication.InvalidCredential;

        }

        //3. Create JWT token
        var token = _jwtTokenGenerator.GenerateToken(user);


        return new AuthenticationResult(
            user,
            token);
    }
}
