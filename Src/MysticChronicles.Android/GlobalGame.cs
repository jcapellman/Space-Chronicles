using System.Collections.Generic;

using MysticChronicles.PCL.Transports.PlayerProfile;
using MysticChronicles.PCL.Transports.Ships;
using MysticChronicles.PCL.Transports.SolarSystem;

namespace MysticChronicles.Android {
    public static class GlobalGame {
        public static PlayerProfileResponseItem PlayerProfile;

        public static List<SolarSystemMapDefinitionResponseItem> CurrentSolarSystemItems
            => PlayerProfile.CurrentSolarSystemItems;

        public static string CurrentSolarSystem => PlayerProfile.CurrentSolarSystem;

        public static ShipProfileResponseItem PlayerShip => PlayerProfile.PlayerShip;
    }
}