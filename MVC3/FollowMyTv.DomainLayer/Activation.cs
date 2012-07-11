using System;
using FollowMyTv.DomainLayer.Interfaces;

namespace FollowMyTv.DomainLayer
{
    public class Activation : IDomainModel<Guid>
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public bool IsUsed { get; set; }
    }
}