using System;
using System.Linq;

using MysticChronicles.PCL.Enums;
using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.Internal;
using MysticChronicles.PCL.Transports.PlayerProfile;
using MysticChronicles.WebAPI.DataLayer.Entities;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class PlayerProfileManager : BaseManager {
        public PlayerProfileManager(BaseManagerConstructorItem constructorItem) : base(constructorItem) { }

        public ReturnSet<PlayerProfileResponseItem> GetProfile() {
            try {
                using (var eFactory = new EntityFactory()) {
                    var profile = eFactory.PlayerProfiles.FirstOrDefault(a => a.UserGUID == UserGUID);

                    if (profile == null) {
                        return new ReturnSet<PlayerProfileResponseItem>(ERROR_CODES.UNCATEGORIZED);
                    }

                    var response = new PlayerProfileResponseItem {
                        Experience = profile.Experience,
                        Level = profile.Level,
                        Credits = profile.Credits,
                        EventTurns = profile.EventTurns
                    };
                    
                    return new ReturnSet<PlayerProfileResponseItem>(response);
                }
            } catch (Exception ex) {
                return new ReturnSet<PlayerProfileResponseItem>(ex);
            }
        }
    }
}