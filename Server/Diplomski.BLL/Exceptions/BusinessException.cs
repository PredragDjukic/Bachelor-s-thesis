using System.Net;

namespace Diplomski.BLL.Exceptions
{
    public class BusinessException : Exception
    {
        public HttpStatusCode StatusCode;


        public BusinessException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
        {
            this.StatusCode = statusCode;
        }

    }
}
