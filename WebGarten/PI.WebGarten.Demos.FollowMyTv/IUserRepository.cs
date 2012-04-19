using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.Demos.FollowMyTv.Repository;

namespace PI.WebGarten.Demos.FollowMyTv
{
    public interface IUserRepository : IRepository<User, string>
    {
        string CookieName { get; }
        bool IsValidUser(User user);
    }
}