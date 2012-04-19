using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowMyTv.Model
{
    public class Show
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Season> Seasons { get; set; }
    }
}