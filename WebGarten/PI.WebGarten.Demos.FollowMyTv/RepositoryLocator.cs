using PI.WebGarten.Demos.FollowMyTv.Model;
using PI.WebGarten.Demos.FollowMyTv.Repository;

namespace PI.WebGarten.Demos.FollowMyTv
{
    public class RepositoryLocator
    {
        private static readonly IRepository<User, string> UserRepo = new BaseMemoryRepository<User, string>();
        public static IRepository<User, string> Users { get { return UserRepo; } }

        private static readonly IRepository<Show, string> ShowRepo = new BaseMemoryRepository<Show, string>();
        public static IRepository<Show, string> Shows { get { return ShowRepo; } }

        private static readonly IRepository<Permission, string> PermissionRepo = new BaseMemoryRepository<Permission, string>();
        public static IRepository<Permission, string> Permissions { get { return PermissionRepo; } }


        //private static readonly IRepository<User, string> ProposalRepo = new BaseMemoryRepository<User, string>();
        //public static IRepository<Proposal, string> Proposals { get { return ProposalRepo; } }
    }
}