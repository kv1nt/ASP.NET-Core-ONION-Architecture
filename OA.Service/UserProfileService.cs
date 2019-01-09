using OA.Data;
using OA.Repo;

namespace OA.Service
{
    public class UserProfileService : IUserProfileService
    {
        private IRepository<UserProfile> _userProfileReposiory;

        public UserProfileService(IRepository<UserProfile> userProfileReposiory)
        {
            _userProfileReposiory = userProfileReposiory;
        }

        public UserProfile GetUserProfile(long id)
        {
            return _userProfileReposiory.Get(id);
        }
    }
}
