using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowMyTv.Repository
{
    public interface IRepository<T,K>
    {
        IEnumerable<T> GetAll();
        T GetById(K id);
        IRepository<T, K> Add( K id, T obj );
    }
}