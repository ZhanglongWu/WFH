namespace Wicresoft.WFH.Api
{
    using System.Threading.Tasks;

    using Wicresoft.WFH.Model;
    using Wicresoft.WFH.Repository;

    public interface IUserService
    {
        UserViewModel GetByEmail(string email);
        Task<UserViewModel> GetByIdentityAsync(string identity);
        Task<PagedData<UserViewModel>> QueryAsync(UserQuery context);
        Task<UserViewModel> GetByIdAsync(int id);
        Task<UserViewModel> GetByEmailAsync(string email);
        Task<UserViewModel> CreateAsync(UserViewModel model, int operatorId);
        Task<UserViewModel> UpdateAsync(UserViewModel model, int operatorId);
        Task DeleteAsync(int id, int operatorId);
        Task<UserViewModel> LoginAsync(string email, string password);

        Task<bool> ChangePasswordAsync(int userId, PasswordEditModel model);
    }
}
