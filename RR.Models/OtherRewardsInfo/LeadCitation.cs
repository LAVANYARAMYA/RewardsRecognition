using RR.Models.Rewards_Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Models.OtherRewardsInfo
{
    public class LeadCitation
    {
        public int Id { get; set; }

        public string NominatorId { get; set; }

        public string Citation { get; set; }

        public Campaigns? Campaigns { get; set; }
    }
}
