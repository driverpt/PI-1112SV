using System.Security.Principal;
using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.Demos.FollowMyTv.Repository;

namespace PI.WebGarten.Demos.FollowMyTv
{
    public class UserMemoryRepository : BaseMemoryRepository<User, string>, IUserRepository
    {
        private const string COOKIE_AUTH_NAME = "PI_AUTH";
        public string CookieName
        {
            get { return COOKIE_AUTH_NAME; }
        }

        public bool IsValidUser(User user)
        {
            var DbUser = GetById(user.Identity.Name);
            return user.Password == DbUser.Password;
        }
    }
}