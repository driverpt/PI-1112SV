using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowMyTv.Model
{
    public class Show
    {
        public Show(string n, string d, List<Season> s)
        {
            Name = n;
            Description = d;
            Seasons = s;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Season> Seasons { get; set; }
    }
}