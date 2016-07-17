using System.Threading.Tasks;

using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.PlayerProfile;

namespace MysticChronicles.PCL.Handlers {
    public class PlayerProfileHandler : BaseHandler {
        public PlayerProfileHandler(string token) : base(token) { }

        protected override string BaseControllerName() => "PlayerProfile";

        public async Task<ReturnSet<PlayerProfileResponseItem>> GetProfile() => await GetAsync<ReturnSet<PlayerProfileResponseItem>>();
    }
}