using System.Collections.Generic;
using PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels.Interfaces;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.Repository
{
    public interface IRepository<T, K> where T: IDomainModel<K>
    {
        IEnumerable<T> GetAll();
        T GetById(K id);
        IRepository<T, K> Add( T obj );
    }
}