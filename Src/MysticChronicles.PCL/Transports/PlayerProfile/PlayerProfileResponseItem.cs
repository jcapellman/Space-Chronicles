using System.Collections.Generic;

using MysticChronicles.PCL.Transports.SolarSystem;

namespace MysticChronicles.PCL.Transports.PlayerProfile {
    public class PlayerProfileResponseItem {
        public int Level { get; set; }

        public int Experience { get; set; }

        public int Credits { get; set; }

        public int EventTurns { get; set; }

        public string CurrentSolarSystem { get; set; }

        public List<SolarSystemMapDefinitionResponseItem> CurrentSolarSystemItems { get; set; }
    }
}