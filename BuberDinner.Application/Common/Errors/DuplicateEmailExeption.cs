using System.Net;

namespace BuberDinner.Application.Common.Errors;

public class DuplicateEmailExeption : Exception, IServiceExeption
{
    public HttpStatusCode StatusCode => HttpStatusCode.Conflict;
    public string ErrorMessage => "Email already exist";
}
