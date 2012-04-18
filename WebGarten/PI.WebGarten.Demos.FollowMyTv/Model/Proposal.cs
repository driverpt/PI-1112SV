namespace PI.WebGarten.Demos.FollowMyTv.Model
{
    public class Proposal
    {
        public long Id { get; set; }
        public Show Show { get; set; }
        public User User { get; set; }
    }
}