using System.Net;

namespace ProductClientHub_Exceptions.ExceptionsBase
{
    public abstract class ProductClientHubException :  SystemException
    {
        public ProductClientHubException(string ErrorMessage) : base(ErrorMessage)
        {
            
        }

        public abstract List<string> GetErrors();
        public abstract HttpStatusCode GetHttpStatusCode();
    }
}
