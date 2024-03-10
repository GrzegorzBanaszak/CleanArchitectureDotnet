﻿using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Contrllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }


    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authenticationService.Register(request.FirstName,
                                                         request.LastName,
                                                         request.Email,
                                                         request.Password);

        var respons = new AuthenticationRespons(authResult.Id,
                                                authResult.FirstName,
                                                authResult.LastName,
                                                authResult.Email,
                                                authResult.Token);
        return Ok(respons);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {

        var authResult = _authenticationService.Login(request.Email, request.Password);

        var respons = new AuthenticationRespons(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.Token);

        return Ok(respons);
    }
}