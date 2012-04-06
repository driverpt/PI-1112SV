using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowMyTv.Model
{
    class Series
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Season> Seasons { get; set; }
    }
}
