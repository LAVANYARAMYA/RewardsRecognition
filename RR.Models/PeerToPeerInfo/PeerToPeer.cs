using RR.Models.EmployeeInfo;
using RR.Models.PeerToPeerInfo;
using RR.Models.Rewards_Campaigns;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Models.PeerToPeerInfo
{
    public class PeerToPeer
    {
        [Key]
        public int Id { get; set; }
        public string NominatorId { get; set; }

        public string? AwardCategory { get; set; }

        public int? Month { get; set; }

        public string? Citation { get; set; }

        public string? NomineeId { get; set; }

        public int CampaignId { get; set; }

        public Employee? Employee { get; set; }

        public Campaigns? Campaigns { get; set; }

        public PeerToPeerResults? PeerToPeerResults { get; set; }
    }
}
