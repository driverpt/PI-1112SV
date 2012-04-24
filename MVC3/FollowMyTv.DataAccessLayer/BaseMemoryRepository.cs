using System;
using System.Collections.Generic;
using FollowMyTv.DomainLayer.Interfaces;
using FollowMyTv.DomainLayer.Repository;

namespace FollowMyTv.DataAccessLayer
{
    public class BaseMemoryRepository<T, K> : IRepository<T, K> where T : IDomainModel<K>
    {
        protected readonly IDictionary<K, T> _repo;

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

        public virtual IRepository<T, K> Add(T obj)
        {
            return Add(obj.Id, obj);
        }

        public IRepository<T, K> Add(K id, T obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException();
            }
            _repo.Add(id, obj);
            return this;
        }
    }
}