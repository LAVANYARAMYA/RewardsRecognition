using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.OtherRewardsInfo;

namespace RR.RewardsWebApi.Controllers.OtherRewardsInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadCitationController:ControllerBase
    {
        private readonly DataBaseAccess dataBaseAccess;
        public LeadCitationController(DataBaseAccess dataBaseAccess) { this.dataBaseAccess = dataBaseAccess; }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<LeadCitation>>> GetLeadCitation()
        {
            var query = (from a in dataBaseAccess.LeadCitation
                         join b in dataBaseAccess.LeadCitationReplies on a.NominatorId equals b.NominatorId
                         where b.CampaignId == 2

                         select new { NominatorId = a.NominatorId, ReplierId = b.ReplierId, Comment = b.ReplyCitation }).ToList();

            return Ok(query);
        }

        [HttpGet]
        [Route("{NominatorId}/{CampaignId}")]
        public async Task<ActionResult<LeadCitation>> Get([FromRoute] string NominatorId, int CampaignId)
        {
                       var query = (from a in dataBaseAccess.LeadCitation
                         join b in dataBaseAccess.LeadCitationReplies on a.Id equals b.LeadCitation.Id
                         where b.NominatorId == NominatorId && b.CampaignId == CampaignId

                         select new { NominatorId = a.NominatorId, ReplierId = b.ReplierId, Comment = b.ReplyCitation }).ToList();

            return Ok(query);


        }
    }
}
