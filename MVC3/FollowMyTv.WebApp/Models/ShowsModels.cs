using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowMyTv.WebApp.Models
{
    public class ShowModel
    {
        [Required]
        [Display(Name = "Show Name")]
        public string Name { get; set; }

        public IEnumerable<SeasonModel> Seasons { get; set; }
    }

    public class SeasonModel
    {
        [Required]
        [Display( Name = "Season Number" )]
        public int Number { get; set; }
        [Required]
        [Display( Name = "Season Name" )]
        public string Name { get; set; }

        public IEnumerable<EpisodeModel> Episodes { get; set; }
    }

    public class EpisodeModel
    {
        [Required]
        [Display( Name = "Episode Name" )]
        public string Name { get; set; }

        [Required]
        [Display( Name = "Episode Number" )]
        public int Number { get; set; }

        [Display( Name = "Episode Synopsis" )]
        public string Synopsis { get; set; }
    }
}