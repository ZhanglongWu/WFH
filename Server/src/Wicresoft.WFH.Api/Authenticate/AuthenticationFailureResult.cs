namespace Wicresoft.WFH.Api
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Threading;
    using System.Threading.Tasks;

    public class AuthenticationFailureResult : IHttpActionResult
    {
        public string ReasonPhrase { get; }
        public HttpRequestMessage Request { get; }

        public AuthenticationFailureResult(string reasonPhrase, HttpRequestMessage request)
        {
            this.ReasonPhrase = reasonPhrase;
            this.Request = request;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return await Task.FromResult(this.Execute());
        }

        private HttpResponseMessage Execute()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Forbidden)
            {
                RequestMessage = Request,
                ReasonPhrase = ReasonPhrase
            };

            return response;
        }
    }
}