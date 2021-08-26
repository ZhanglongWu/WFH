namespace Wicresoft.WFH.Api
{
    using System.Threading.Tasks;
    using System.Collections.Generic;

    using Wicresoft.WFH.Model;

    public interface IAccessService
    {
        Task CreateAccessEventAsync(string path, int? userId, string ip);
    }
}
