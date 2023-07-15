using Microsoft.AspNetCore.Mvc;
using RR.DataBaseConnect;
using RR.Models.PeerToPeerInfo;
using RR.Services;
using RR.Services.RequestClasses;

namespace RR.RewardsWebApi.Controllers.PeerToPeerInfo
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeerToPeerController:ControllerBase
    {
        private readonly DataBaseAccess dataBaseAccess;
        public PeerToPeerServices PeerToPeerServices;
        public PeerToPeerController(DataBaseAccess dataBaseAccess)
        {
            PeerToPeerServices = new PeerToPeerServices(dataBaseAccess);
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PeerToPeer>>> GetPeerToPeer()
        {
           

            var res = await PeerToPeerServices.GetPeerToPeerAsync();

            return Ok(res);

        }

        [HttpGet]
        [Route("{NominatorId}")]

        public async Task<ActionResult<PeerToPeer>> Get([FromRoute] string NominatorId)
        {
            
                var result = await PeerToPeerServices.Get(NominatorId);
                return Ok(result);
            
           

        }



        [HttpPost]

        public async Task<ActionResult<PeerToPeer>> AddPeerToPeerNominees(RequestPeerToPeer requestPeerToPeer)
        {


            var res = await PeerToPeerServices.AddPeerToPeerNominees(requestPeerToPeer);
            return Ok(res);

        }

       /* public bool IsAvailableNominatorId(string NominatorId)
        {
            return (dataBaseAccess.PeerToPeer?.Any(x => x.NominatorId.Equals(NominatorId))).GetValueOrDefault();

        }*/
    }
}
