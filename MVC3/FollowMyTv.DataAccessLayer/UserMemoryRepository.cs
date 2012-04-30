using System.Collections.Generic;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;

namespace FollowMyTv.DataAccessLayer
{
    public class UserMemoryRepository : BaseMemoryRepository<User, string>, IUserRepository
    {
        private static readonly IDictionary<string, User> Repo = new Dictionary<string, User>(); 

        protected UserMemoryRepository() : base(Repo){}

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

        public User GetByUsername(string username)
        {
            return GetById(username);
        }
    }
}