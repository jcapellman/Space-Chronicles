using System;
using System.Linq;

using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.Internal;
using MysticChronicles.PCL.Transports.Ships;
using MysticChronicles.WebAPI.DataLayer.Entities;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class ShipManager : BaseManager {
        public ShipManager(BaseManagerConstructorItem constructorItem) : base(constructorItem) { }

        public ReturnSet<ShipProfileResponseItem> GetShip(Guid shipGUID) {
            try {
                using (var eFactory = new EntityFactory()) {
                    var ship = eFactory.Ships.FirstOrDefault(a => a.GUID == shipGUID);

                    if (ship == null) {
                        throw new Exception($"Ship with {shipGUID} GUID does not exist");
                    }

                    var responseItem = new ShipProfileResponseItem {
                        Name = ship.Name,
                        TextureName = ship.TextureName,
                        CargoSpace = ship.CargoSpace
                    };

                    return new ReturnSet<ShipProfileResponseItem>(responseItem);
                }
            } catch (Exception ex) {
                return new ReturnSet<ShipProfileResponseItem>(ex);
            }
        }
    }
}