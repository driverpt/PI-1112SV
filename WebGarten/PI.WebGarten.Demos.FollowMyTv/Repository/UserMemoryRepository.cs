using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv.Repository
{
    public class UserMemoryRepository : BaseMemoryRepository<User, string>, IUserRepository
    {
        private static UserMemoryRepository Repo = new UserMemoryRepository();
        public static UserMemoryRepository Instance { get { return Repo; } }

        public User Authenticate(string username, string password)
        {
            var dbuser = GetById(username);
            if ( dbuser == null ) { return null; }
            return dbuser.Password.Equals(password) ? dbuser : null;
        }
    }
}