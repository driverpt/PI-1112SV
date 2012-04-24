using FollowMyTv.DomainLayer.Interfaces;
using FollowMyTv.DomainLayer.Repository;

namespace FollowMyTv.DataAccessLayer
{
    public class AutoIncrementMemoryRepository<T> : BaseMemoryRepository<T, int> where T : IDomainModel<int>
    {
        private volatile int _currentId;

        public AutoIncrementMemoryRepository()
        {
            _currentId = 0;
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