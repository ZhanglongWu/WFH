namespace Wicresoft.WFH.Api
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Wicresoft.WFH.Core;
    using Wicresoft.WFH.Model;
    using Wicresoft.WFH.Repository;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public UserViewModel GetByEmail(string email)
        {
            var entity = this._userRepository.GetUserByEmail(email, UserQuery.GetAllNavigation());

            return entity?.ToViewModel();
        }

        public async Task<UserViewModel> GetByIdentityAsync(string identity)
        {
            return await this.GetByEmailAsync(identity);
        }

        public async Task<PagedData<UserViewModel>> QueryAsync(UserQuery context)
        {
            context.IncludeAll();

            var query = await this._userRepository.QueryAsync(context);

            return new PagedData<UserViewModel>()
            {
                Total = query.Total,
                Items = query.Items.Select(item => item.ToViewModel())
            };
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            return (await this._userRepository.GetByIdAsync(id, UserQuery.GetAllNavigation()))?.ToViewModel();
        }

        public async Task<UserViewModel> GetByEmailAsync(string email)
        {
            var entity = await this._userRepository.GetUserByEmailAsync(email, UserQuery.GetAllNavigation());

            return entity?.ToViewModel();
        }

        public async Task<UserViewModel> CreateAsync(UserViewModel model, int operatorId)
        {
            var entity = model.ToEntity(operatorId);

            await this._userRepository.CreateAsync(entity);
            await this._userRepository.UpdateRoleAsync(model.Roles?.Select(item => item.Id));
            await this._userRepository.UpdatePermissionAsync(model.Permissions?.Select(item => item.Id));

            return (await this._userRepository.SaveAsync()).ToViewModel();
        }

        public async Task<UserViewModel> UpdateAsync(UserViewModel model, int operatorId)
        {
            var entity = await this._userRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                throw new EntityNotFoundException($@"未找到 xxxx");
            }

            var newEntity = model.MergeEntity(entity, operatorId);

            await this._userRepository.UpdateAsync(newEntity);
            await this._userRepository.UpdateRoleAsync(model.Roles?.Select(item => item.Id));
            await this._userRepository.UpdatePermissionAsync(model.Permissions?.Select(item => item.Id));

            return (await this._userRepository.SaveAsync()).ToViewModel();
        }

        public async Task DeleteAsync(int id, int operatorId)
        {
            await this._userRepository.DeleteAsync(id, operatorId);
            await this._userRepository.SaveAsync();
        }

        public async Task<UserViewModel> LoginAsync(string email, string password)
        {
            var entity = await this._userRepository.GetUserByEmailAsync(email, UserQuery.GetAllNavigation());

            if (entity?.Password != password.MD5())
            {
                throw new LoginException($@"账号密码错误");
            }

            return entity.ToViewModel();
        }

        public async Task<bool> ChangePasswordAsync(int userId, PasswordEditModel model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            if (string.IsNullOrEmpty(model.Password)) throw new ArgumentException("New Password cannot be empty");

            if (model.ConfirmPassword != model.Password) throw new ArgumentException("Password confirmation doesn't match the password");

            var entity = await this._userRepository.GetByIdAsync(userId);

            if (entity == null) throw new EntityNotFoundException("Cannot found User");

            entity.Password = model.Password.MD5();
            entity.LastUpdateDateTime = DateTime.UtcNow;
            entity.LastUpdatedUserId = userId;

            await this._userRepository.UpdateAsync(entity);
            await this._userRepository.SaveAsync();

            return true;
        }
    }
}