using System;
using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowMyTv.Domain.DomainModels
{
    public class Season
    {
        private readonly List<Episode> _episodes; 

        public Season()
        {
            _episodes = new List<Episode>();
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Finale { get; set; }
        public List<Episode> Episodes { get { return _episodes; } }
    }
}