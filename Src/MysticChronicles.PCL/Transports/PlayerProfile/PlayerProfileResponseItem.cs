using System.Collections.Generic;
using System.Runtime.Serialization;

using MysticChronicles.PCL.Transports.Ships;
using MysticChronicles.PCL.Transports.SolarSystem;

namespace MysticChronicles.PCL.Transports.PlayerProfile {
    [DataContract]
    public class PlayerProfileResponseItem {
        [DataMember]
        public int Level { get; set; }

        [DataMember]
        public int Experience { get; set; }

        [DataMember]
        public int Credits { get; set; }

        [DataMember]
        public int EventTurns { get; set; }

        [DataMember]
        public string CurrentSolarSystem { get; set; }

        [DataMember]
        public List<SolarSystemMapDefinitionResponseItem> CurrentSolarSystemItems { get; set; }

        [DataMember]
        public ShipProfileResponseItem PlayerShip { get; set; }
    }
}