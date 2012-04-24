using System.Collections.Generic;
using FollowMyTv.DomainLayer.Interfaces;

namespace FollowMyTv.DomainLayer.Repository
{
    public interface IRepository<T, K> where T: IDomainModel<K>
    {
        IEnumerable<T> GetAll();
        T GetById(K id);
        IRepository<T, K> Add( T obj );
    }
}