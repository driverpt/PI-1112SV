using System;
using System.Collections.Generic;
using FollowMyTv.DomainLayer;

namespace FollowMyTv.DataAccessLayer
{
    public class GuidActivationRepository : BaseMemoryRepository<Activation, Guid>
    {
        protected GuidActivationRepository(IDictionary<Guid, Activation> repo) : base(repo) {}
    }
}