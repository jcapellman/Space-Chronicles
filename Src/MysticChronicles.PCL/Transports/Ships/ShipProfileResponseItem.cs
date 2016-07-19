using System.Runtime.Serialization;

namespace MysticChronicles.PCL.Transports.Ships {
    public class ShipProfileResponseItem {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string TextureName { get; set; }

        [DataMember]
        public int CargoSpace { get; set; }
    }
}