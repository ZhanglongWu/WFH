namespace Wicresoft.WFH.Model
{
    using System;

    public class PermissionViewModel : IdentityViewModel, IEquatable<PermissionViewModel>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public OptionViewModel ToOptionViewModel()
        {
            return new OptionViewModel() { Id = this.Id, Name = this.Name };
        }

        public bool Equals(PermissionViewModel other)
        {
            if (ReferenceEquals(null, other)) return false;

            if (ReferenceEquals(this, other)) return true;

            return this.Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;


            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;

            return Equals((PermissionViewModel)obj);
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(PermissionViewModel left, PermissionViewModel right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PermissionViewModel left, PermissionViewModel right)
        {
            return !Equals(left, right);
        }
    }
}
