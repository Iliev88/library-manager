namespace Utilities.Model
{
    using System.Net;
    using System.Net.Http;

    public class ResponseModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public HttpResponseMessage HttpResponseMessage { get; set; }
    }
}
