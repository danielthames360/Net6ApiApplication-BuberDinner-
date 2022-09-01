using System.Net;

namespace BuberDinner.Application.Common.Errors
{
    public interface IServiceExpection
    {
        public HttpStatusCode StatusCode => HttpStatusCode.Conflict;

        public string ErrorMessage => "Email already exists.";
    }
}
