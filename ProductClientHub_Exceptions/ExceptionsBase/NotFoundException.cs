using System.Net;

namespace ProductClientHub_Exceptions.ExceptionsBase
{
    public class NotFoundException : ProductClientHubException
    {
        public NotFoundException(string ErrorMessage) : base(ErrorMessage)
        {
        }

        public override List<string> GetErrors() => [Message];

        public override HttpStatusCode GetHttpStatusCode() => HttpStatusCode.NotFound;
        
    }
}
