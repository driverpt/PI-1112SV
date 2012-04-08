using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv
{
    static class ResolveUri
    {
        public static string For(User user)
        {
            return string.Format("/user/{0}", user.Id);
        }

        public static string ForUsers()
        {
            return "/users";
        }
    }
}