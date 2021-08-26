namespace Wicresoft.WFH.Data
{
    public class BaseEntity : IdentityEntity
    {
        public virtual bool IsActive { get; set; }
    }
}
