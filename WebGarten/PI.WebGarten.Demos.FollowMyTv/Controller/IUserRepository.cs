using System.Collections.Generic;
using PI.WebGarten.Demos.FollowMyTv.Model;

namespace PI.WebGarten.Demos.FollowMyTv.Controller
{
    interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetById( string username );
        void Add( User user );
    }
}