using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.Repository
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        bool TryAuthenticate(string username, string password, out User user);
        User GetByUsername(string username);
    }
}