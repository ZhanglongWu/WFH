namespace Wicresoft.WFH.Api
{
    using System.Web;
    using System.Net.Http;
    using System.ServiceModel.Channels;

    public static class RequestExtension
    {
        public static string GetIpAddress(this HttpRequestMessage request)
        {
            if (request == null) return "0.0.0.0";

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                var prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];

                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return "0.0.0.0";
            }
        }
    }
}