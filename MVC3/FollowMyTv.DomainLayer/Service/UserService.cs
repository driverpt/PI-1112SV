using FollowMyTv.DomainLayer.Repository;
using Microsoft.Practices.Unity;

namespace FollowMyTv.DomainLayer.Service
{
    public class UserService
    {
        private readonly IRepository<User, string> Repo;

        [InjectionConstructor]
        public UserService( [Dependency] IRepository<User, string> repository )
        {
            Repo = repository;
        }

        public void AddUser( User user )
        {
            Repo.Add(user);
        }
    }
}