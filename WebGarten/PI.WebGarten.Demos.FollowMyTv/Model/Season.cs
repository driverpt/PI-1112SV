using System;
using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowMyTv.Model
{
    class Season
    {
        public string Name { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Finale { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}