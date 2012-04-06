using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    class UserController
    {
        private readonly IUserRepository _repo;
        public UserController()
        {
            
        }
    }

    interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById( string username );
        void Add( User user );
    }

    class UserMemoryRepository : IUserRepository
    {
        private readonly IDictionary<int, User> _repo = new Dictionary<int, User>();
        private int _cid = 0;


        public IEnumerable<User> GetAll()
        {

            throw new NotImplementedException();
        }

        public User GetById(string username)
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            
        }

    }
}
