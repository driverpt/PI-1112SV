using PI.WebGarten.Demos.FollowMyTv.Repository;

namespace PI.WebGarten.Demos.FollowMyTv
{
    public class UserRepositoryLocator
    {
        private static readonly IUserRepository Repo = UserMemoryRepository.Instance;
        public static IUserRepository Instance { get { return Repo; } }
    }
}