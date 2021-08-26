namespace Wicresoft.WFH.Data
{
    using System;

    [Serializable]
    public abstract class IdentityEntity
    {
        public virtual int Id { get; set; }
    }
}