using System.Collections.Generic;
using FollowMyTv.DomainLayer;
using FollowMyTv.DomainLayer.Repository;

namespace FollowMyTv.DataAccessLayer
{
    public class UserMemoryRepository : BaseMemoryRepository<User, string>, IUserRepository
    {
        private static readonly IDictionary<string, User> Repo = new Dictionary<string, User>(); 

        public UserMemoryRepository() : base(Repo){}

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
        
        public bool CreateUser(string username, string password, string email, Role role)
        {
            if ( Repo.ContainsKey(username))
            {
                return false;
            }

            User user = new User(username, password, email, role);
            Add(user);
            return true;
        }

        public bool ActivateUser(string username)
        {
            User user = GetByUsername(username);
            if ( user.IsActivated )
            {
                return false;
            }
            user.IsActivated = true;
            return true;
        }

        public bool SetUserRole(string username, Role role)
        {
            User user = GetByUsername(username);

            if ( user.Role.Equals(role) )
            {
                return false;
            }

            User newUser = new User(username, user.Password, user.Email, role);
            Repo[username] = newUser;
            return true;
        }

        public bool ChangePassword(string username, string newPassword)
        {
            User user = GetByUsername(username);
            user.Password = newPassword;
            return true;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return GetAll();
        }
    }
}