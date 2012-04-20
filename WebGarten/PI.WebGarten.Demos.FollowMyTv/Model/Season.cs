using System;
using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowMyTv.Model
{
    public class Season
    {
        public Season(string name, DateTime debut, DateTime finale, List<Episode> episodes)
        {
            Name = name;
            Debut = debut;
            Finale = finale;
            Episodes = episodes;
        }

        public string Name { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Finale { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}