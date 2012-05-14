using System.Collections.Generic;
using System.Linq;
using FollowMyTv.DomainLayer.Interfaces;
using FollowMyTv.DomainLayer.Repository;

namespace FollowMyTv.DataAccessLayer
{
    public class AutoIncrementMemoryRepository<T> : BaseMemoryRepository<T, int> where T : IDomainModel<int>
    {
        private volatile int _currentId;

        private static readonly IDictionary<int, T> Repo = new Dictionary<int, T>();

        public AutoIncrementMemoryRepository() : base(Repo)
        {
            _currentId = Repo.Keys.Count;
        }

        public override IRepository<T, int> Add(T obj)
        {
            int newId = ++_currentId;
            obj.Id = newId;
            _repo.Add(newId, obj);
            return this;
        }
    }
}