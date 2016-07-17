using System.Threading.Tasks;

using MysticChronicles.PCL.Transports.Global;

namespace MysticChronicles.PCL.Handlers {
    public class PlayerProfileHandler : BaseHandler {
        public PlayerProfileHandler(string token) : base(token) { }

        protected override string BaseControllerName() => "PlayerProfile";

        public async Task<ReturnSet<bool>> GetProfile() => await GetAsync<ReturnSet<bool>>();
    }
}