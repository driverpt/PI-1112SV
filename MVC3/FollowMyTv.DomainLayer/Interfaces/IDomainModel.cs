namespace FollowMyTv.DomainLayer.Interfaces
{
    public interface IDomainModel<K>
    {
        K Id { get; set; }
    }
}