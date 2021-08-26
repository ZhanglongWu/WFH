namespace Wicresoft.WFH.Api
{
    using System.Net;
    using System.Linq;
    using System.Web.Http;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Net.Http.Headers;

    public class AddChallengeOnUnauthorizedResult : IHttpActionResult
    {
        public IHttpActionResult InnerResult { get; }
        public AuthenticationHeaderValue Challenge { get; }

        public AddChallengeOnUnauthorizedResult(AuthenticationHeaderValue challenge, IHttpActionResult innerResult)
        {
            this.Challenge = challenge;
            this.InnerResult = innerResult;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = await InnerResult.ExecuteAsync(cancellationToken);

            if (response.StatusCode != HttpStatusCode.Unauthorized) return response;

            if (response.Headers.WwwAuthenticate.All(h => h.Scheme != Challenge.Scheme))
            {
                response.Headers.WwwAuthenticate.Add(Challenge);
            }

            return response;
        }
    }
}