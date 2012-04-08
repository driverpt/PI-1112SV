using System.Collections.Generic;
using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    class UserMemoryRepository : IUserRepository
    {
        private readonly IDictionary<int, User> _repo = new Dictionary<int, User>();
        private volatile int _cid = 0;

        public IEnumerable<User> GetAll()
        {
            return _repo.Values;
        }

        public User GetById(string username)
        {
            return _repo[0];
        }

        public void Add(User user)
        {
            user.Id = _cid;
            ++_cid;
            _repo.Add(user.Id, user);
        }

    }
}