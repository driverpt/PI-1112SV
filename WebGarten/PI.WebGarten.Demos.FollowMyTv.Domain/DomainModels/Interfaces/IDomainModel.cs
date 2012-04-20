namespace PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels.Interfaces
{
    public interface IDomainModel<K>
    {
        K Id { get; set; }
    }
}