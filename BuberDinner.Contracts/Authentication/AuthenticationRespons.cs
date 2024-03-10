﻿namespace BuberDinner.Contracts.Authentication;

public record AuthenticationRespons(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);
