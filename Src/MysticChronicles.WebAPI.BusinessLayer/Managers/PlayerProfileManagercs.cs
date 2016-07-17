﻿using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.Internal;
using MysticChronicles.PCL.Transports.PlayerProfile;
using MysticChronicles.WebAPI.DataLayer.Entities;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class PlayerProfileManagercs : BaseManager {
        public PlayerProfileManagercs(BaseManagerConstructorItem constructorItem) : base(constructorItem) { }

        public ReturnSet<PlayerProfileResponseItem> GetProfile() {
            using (var eFactory = new EntityFactory()) {
                return new ReturnSet<PlayerProfileResponseItem>();
            }
        }
    }
}