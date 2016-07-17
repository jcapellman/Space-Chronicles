﻿using System.Linq;
using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.Internal;
using MysticChronicles.PCL.Transports.PlayerProfile;
using MysticChronicles.WebAPI.DataLayer.Entities;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class PlayerProfileManager : BaseManager {
        public PlayerProfileManager(BaseManagerConstructorItem constructorItem) : base(constructorItem) { }

        public ReturnSet<PlayerProfileResponseItem> GetProfile() {
            using (var eFactory = new EntityFactory()) {
                var response = new PlayerProfileResponseItem();

                response.Experience = 0;
                response.Level = 1;

                return new ReturnSet<PlayerProfileResponseItem>(response);
            }
        }
    }
}