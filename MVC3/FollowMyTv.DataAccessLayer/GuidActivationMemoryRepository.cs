using System;
using System.Collections.Generic;
using FollowMyTv.DomainLayer;

namespace FollowMyTv.DataAccessLayer
{
    public class GuidActivationMemoryRepository : BaseMemoryRepository<Activation, Guid>
    {
        private static IDictionary<Guid, Activation> Repo = new Dictionary<Guid, Activation>();
        public GuidActivationMemoryRepository() : base(Repo) {}
    }
}