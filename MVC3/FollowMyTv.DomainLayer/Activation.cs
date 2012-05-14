using System;
using FollowMyTv.DomainLayer.Interfaces;

namespace FollowMyTv.DomainLayer
{
    public class Activation : IDomainModel<Guid>
    {
        private Guid _guid;

        public Guid Id
        {
            get { return _guid; }
            set { _guid = value; }
        }

        public string Username { get; set; }

        public bool IsUsed { get; set; }
    }
}