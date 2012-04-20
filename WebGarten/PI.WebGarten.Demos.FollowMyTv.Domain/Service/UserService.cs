using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.Service
{
    public static class UserService
    {
        public static void AddUser( User user )
        {
            RepositoryLocator.Users.Add(user);
        }
    }
}