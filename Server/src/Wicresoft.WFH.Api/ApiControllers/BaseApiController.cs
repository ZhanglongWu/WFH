namespace Wicresoft.WFH.Api
{
    using System;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected IHttpActionResult SetBadResult(Exception message)
        {
            return Ok(new Result<object>() { IsSuccess = false, Message = message.ToString(), Data = null });
        }

        protected IHttpActionResult SetWarningResult<T>(T content, string message)
        {
            return Ok(new Result<T>() { IsSuccess = false, Message = message, Data = content });
        }

        protected IHttpActionResult SetOkResult<T>(T content)
        {
            return Ok(new Result<T>() { Data = content, IsSuccess = true });
        }

        protected IHttpActionResult SetOkResult()
        {
            return Ok(new Result<object>() { IsSuccess = true, Data = null });
        }
    }
}
