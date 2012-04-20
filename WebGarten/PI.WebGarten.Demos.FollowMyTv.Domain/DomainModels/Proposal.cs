using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels.Interfaces;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels
{
    public class Proposal : IDomainModel<int>
    {
        public int Id { get; set; }
        public Show Show { get; set; }
        public User User { get; set; }
    }
}