using System;
using System.Collections.Generic;

namespace FollowMyTv.DomainLayer
{
    public class Season
    {
        public Season()
        {
            Episodes = new List<Episode>();
        }

        public int Number { get; set; }
        public string Name { get; set; }
        public DateTime Debut { get; set; }
        public DateTime Finale { get; set; }
        public List<Episode> Episodes { get; set; }
    }
}