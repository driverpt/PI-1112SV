using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv.Repository
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        bool TryAuthenticate(string username, string password, out User user);
    }
}