namespace Wicresoft.WFH.Api
{
    using Newtonsoft.Json;

    public class Result<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public ErrorCode ErrorCode { get; set; }

        public T Data { get; set; }
    }
}