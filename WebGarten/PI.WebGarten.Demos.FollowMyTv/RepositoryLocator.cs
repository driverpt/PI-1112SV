using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.Demos.FollowMyTv.Repository;

namespace PI.WebGarten.Demos.FollowMyTv
{
    public class RepositoryLocator
    {
        private static readonly IRepository<User, string> UserRepo = UserMemoryRepository.Instance;
        public static IRepository<User, string> Users { get { return UserRepo; } }

        private static readonly IRepository<Show, string> ShowRepo = new BaseMemoryRepository<Show, string>();
        public static IRepository<Show, string> Shows { get { return ShowRepo; } }

        private static readonly IRepository<Permission, string> PermissionRepo = new BaseMemoryRepository<Permission, string>();
        public static IRepository<Permission, string> Permissions { get { return PermissionRepo; } }

        private static readonly IRepository<Proposal, int> ProposalRepo = new BaseMemoryRepository<Proposal, int>();
        public static IRepository<Proposal, int> Proposals { get { return ProposalRepo; } }
    }
}