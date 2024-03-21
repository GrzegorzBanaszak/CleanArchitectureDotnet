using ErrorOr;

namespace BuberDinner.Domain;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredential => Error.Validation(
            code: "Auth.InvalidCred",
            description: "Invalid credentials.");
    }
}
