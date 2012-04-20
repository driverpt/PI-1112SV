using PI.WebGarten.Demos.FollowMyTv.Domain.Repository;

namespace PI.WebGarten.Demos.FollowMyTv.Domain
{
    public class UserRepositoryLocator
    {
        private static readonly IUserRepository Repo = UserMemoryRepository.Instance;
        public static IUserRepository Instance { get { return Repo; } }
    }
}