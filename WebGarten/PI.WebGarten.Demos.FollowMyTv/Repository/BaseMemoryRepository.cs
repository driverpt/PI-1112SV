using System;
using System.Collections.Generic;
using PI.WebGarten.Demos.FollowMyTv.Controller;

namespace PI.WebGarten.Demos.FollowMyTv.Repository
{
    class BaseMemoryRepository<T,K> : IRepository<T,K>
    {
        private readonly IDictionary<K, T> _repo;
 
        public BaseMemoryRepository()
        {
            _repo = new Dictionary<K, T>();
        } 

        public IEnumerable<T> GetAll()
        {
            return _repo.Values;
        }

        public T GetById(K id)
        {
            T obj = default(T);
            _repo.TryGetValue(id, out obj);
            return obj;
        }

        public IRepository<T, K> Add( K id, T obj )
        {
            if( obj == null )
            {
                throw new NullReferenceException();
            }
            _repo.Add( id, obj );
            return this;
        }
    }
}