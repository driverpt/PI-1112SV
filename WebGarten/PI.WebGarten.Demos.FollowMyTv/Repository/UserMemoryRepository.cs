using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv.Repository
{
    public class UserMemoryRepository : BaseMemoryRepository<User, string>, IUserRepository
    {
        private static readonly UserMemoryRepository Repo = new UserMemoryRepository();
        public static UserMemoryRepository Instance { get { return Repo; } }

        public User Authenticate(string username, string password)
        {
            var dbuser = GetById(username);
            if ( dbuser == null ) { return null; }
            return dbuser.Password.Equals(password) ? dbuser : null;
        }

        public bool TryAuthenticate(string username, string password, out User user)
        {
            user = Authenticate(username, password);
            return user != null;
        }
    }
}