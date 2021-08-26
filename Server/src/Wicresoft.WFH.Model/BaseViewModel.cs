namespace Wicresoft.WFH.Model
{
    using System;

    public class BaseViewModel : IdentityViewModel
    {
        public DateTime? CreatedDateTime { get; set; }
        public UserViewModel CreatedUser { get; set; }

        public DateTime? LastUpdatedDateTime { get; set; }
        public UserViewModel LastUpdatedUser { get; set; }
    }
}
