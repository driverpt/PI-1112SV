using System.ComponentModel.DataAnnotations;

namespace FollowMyTv.WebApp.Models
{
    public class ProposalsAddModel
    {
        [Required]
        [Display(Name="Show Name")]
        public string ShowName;
    }
}