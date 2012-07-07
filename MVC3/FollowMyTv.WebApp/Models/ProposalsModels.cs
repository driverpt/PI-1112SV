using System.ComponentModel.DataAnnotations;

namespace FollowMyTv.WebApp.Models
{
    public class ProposalModel : ShowModel
    {
        [Required]
        public int ProposalId;
    }
}