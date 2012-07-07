using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FollowMyTv.WebApp.Models
{
    public class ShowModel
    {
        [Required]
        [Display( Name = "Show Name" )]
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class SeasonModel
    {
        [Required]
        public string ShowName { get; set; }

        [Required]
        [Display( Name = "Season Number" )]
        public int Number { get; set; }

        [Display( Name = "Season Name" )]
        public string Name { get; set; }

        [DataType( DataType.Date )]
        [DisplayFormat( ConvertEmptyStringToNull = true, ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}" )]
        public DateTime? Debut { get; set; }

        [DataType( DataType.Date )]
        [DisplayFormat( ConvertEmptyStringToNull = true, ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}" )]
        public DateTime? Finale { get; set; }
    }

    public class EpisodeModel
    {
        [Required]
        public string ShowName { get; set; }

        [Required]
        public int SeasonNumber { get; set; }

        [Required]
        [Display( Name = "Episode Name" )]
        public string Name { get; set; }

        [Required]
        [Display( Name = "Episode Number" )]
        public int Number { get; set; }

        [Required]
        [Display( Name = "Duration in minutes" )]
        public int Duration { get; set; }

        [Display( Name = "Episode Synopsis" )]
        public string Synopsis { get; set; }

        public int Score { get; set; }
    }
}