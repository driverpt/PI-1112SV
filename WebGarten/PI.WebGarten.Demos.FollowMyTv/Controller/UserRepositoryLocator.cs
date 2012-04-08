namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    class UserRepositoryLocator
    {
        private readonly static IUserRepository Repo = new UserMemoryRepository();
        public static IUserRepository Instance { get { return Repo; } }
    }
}