using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RR.DataBaseConnect;
using RR.Models.Rewards_Campaigns;
using RR.Services.RequestClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RR.Services
{
    public class CampaignServices
    {
        private readonly DataBaseAccess dataBaseAccess;

        public CampaignServices()
        {

        }

        public CampaignServices(DataBaseAccess dataBaseAccess)
        {
            this.dataBaseAccess = dataBaseAccess;
        }
        public async Task<ActionResult<IEnumerable<Campaigns>>> GetCampaign()
        {
            var result = await dataBaseAccess.Campaigns.ToListAsync();

            result.ForEach(x => x.RewardTypes = dataBaseAccess.RewardType.FirstOrDefault(y => y.Id == x.RewardId));

            return result;
        }

        public async Task<ActionResult<Campaigns>> AddCampaign(RequestCampaign requestCampaign)
        {
            Campaigns campaign = new Campaigns();

            campaign.StartDate = requestCampaign.StartDate;
            campaign.EndDate = requestCampaign.EndDate;
            campaign.CampaignName = requestCampaign.CampaignName;
            campaign.RewardId = requestCampaign.RewardId;

            RewardType rewardType = dataBaseAccess.RewardType.FirstOrDefault(x => x.Id == requestCampaign.RewardId);
            campaign.RewardTypes = rewardType;

            await dataBaseAccess.Campaigns.AddAsync(campaign);

            await dataBaseAccess.SaveChangesAsync();

            return campaign;
        }
    }
}
