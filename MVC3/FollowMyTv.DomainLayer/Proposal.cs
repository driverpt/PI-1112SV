using FollowMyTv.DomainLayer.Interfaces;

namespace FollowMyTv.DomainLayer
{
    public class Proposal : IDomainModel<int>
    {
        public Proposal()
        {
            Status = ProposalStatus.Created;
        }
        public int Id { get; set; }
        public Show Show { get; set; }
        public User User { get; set; }
        public ProposalStatus Status { get; set; }
    }

    public enum ProposalStatus
    {
        Created = 1
      , Accepted = 2
      , Rejected = 4
    }
}