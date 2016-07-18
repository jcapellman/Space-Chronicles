using System;
using System.Collections.Generic;
using System.Linq;

using MysticChronicles.PCL.Enums;
using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.Internal;
using MysticChronicles.PCL.Transports.PlayerProfile;
using MysticChronicles.PCL.Transports.SolarSystem;
using MysticChronicles.WebAPI.DataLayer.Entities;

using Newtonsoft.Json;

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

                    var currentSolarSystem =
                        eFactory.SolarSystems.FirstOrDefault(a => a.GUID == profile.CurrentSolarSystemGUID);

                    var response = new PlayerProfileResponseItem {
                        Experience = profile.Experience,
                        Level = profile.Level,
                        Credits = profile.Credits,
                        EventTurns = profile.EventTurns,
                        CurrentSolarSystem = currentSolarSystem.Name,
                        CurrentSolarSystemItems = JsonConvert.DeserializeObject<List<SolarSystemMapDefinitionResponseItem>>(currentSolarSystem.MapDefinition)
                    };
                    
                    return new ReturnSet<PlayerProfileResponseItem>(response);
                }
            } catch (Exception ex) {
                return new ReturnSet<PlayerProfileResponseItem>(ex);
            }
        }
    }
}