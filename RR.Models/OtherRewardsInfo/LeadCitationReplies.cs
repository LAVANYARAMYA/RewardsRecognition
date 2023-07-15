using RR.Models.Rewards_Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Models.OtherRewardsInfo
{
     public class LeadCitationReplies
    {
        public int Id { get; set; }

        public int CampaignId { get; set; }

        public string NominatorId { get; set; }

        public string ReplierId { get; set; }

        public string ReplyCitation { get; set; }

        public LeadCitation? LeadCitation { get; set; }

        public Campaigns? Campaigns { get; set; }
    }
}
