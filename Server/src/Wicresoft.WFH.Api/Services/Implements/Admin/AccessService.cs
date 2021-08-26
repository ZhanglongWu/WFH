namespace Wicresoft.WFH.Api.Services
{
    using System;
    using System.Threading.Tasks;

    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Repository;

    public class AccessService : IAccessService
    {
        private readonly IAccessRepository _accessRepository;

        public AccessService(IAccessRepository accessRepository)
        {
            this._accessRepository = accessRepository;
        }

        public async Task CreateAccessEventAsync(string path, int? userId, string ip)
        {
            await this._accessRepository.CreateAsync(new AccessEvent()
            {
                IpAddress = ip,
                Path = path,
                UserId = userId,
                YYYYMMDD = DateTime.UtcNow.ToString("YYYY-MM-DD"),
                Year = DateTime.UtcNow.Year,
                Month = DateTime.UtcNow.Month,
                Days = DateTime.UtcNow.Day,
                CreatedDateTime = DateTime.UtcNow,
                Comment = string.Empty
            });

            await this._accessRepository.SaveAsync();
        }
    }
}