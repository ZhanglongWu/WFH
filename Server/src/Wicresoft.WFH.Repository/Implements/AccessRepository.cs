namespace Wicresoft.WFH.Repository
{
    using System;
    using System.Linq;
    using System.Data.Entity;
    using System.Threading.Tasks;
    using System.Linq.Expressions;
    using System.Collections.Generic;

    using Wicresoft.WFH.Data;

    public class AccessRepository : BaseRepository<AccessEvent>, IAccessRepository
    {
        public AccessRepository(IWorkFromHomeEntities dbContext) : base(dbContext)
        {
        }
    }
}
