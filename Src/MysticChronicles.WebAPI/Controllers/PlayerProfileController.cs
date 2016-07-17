using Microsoft.AspNetCore.Mvc;

using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.PlayerProfile;
using MysticChronicles.WebAPI.BusinessLayer.Managers;

namespace MysticChronicles.WebAPI.Controllers {
    public class PlayerProfileController : BaseController {
        [HttpGet]
        public ReturnSet<PlayerProfileResponseItem> Get() => new PlayerProfileManager(BASE_MANAGER).GetProfile();
    }
}