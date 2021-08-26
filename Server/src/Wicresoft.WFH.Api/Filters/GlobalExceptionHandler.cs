namespace Wicresoft.WFH.Api
{
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http.Results;
    using System.Web.Http.ExceptionHandling;

    public class GlobalExceptionHandler : ExceptionHandler
    {
        public override async Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var errorMessage = @"An error occured, please contact your admin for more details.";

            var response = context.Request.CreateResponse(HttpStatusCode.InternalServerError,
                new
                {
                    Message = errorMessage
                });

            response.Headers.Add("X-Error", errorMessage);

            context.Result = new ResponseMessageResult(response);

            await base.HandleAsync(context, cancellationToken);
        }
    }
}