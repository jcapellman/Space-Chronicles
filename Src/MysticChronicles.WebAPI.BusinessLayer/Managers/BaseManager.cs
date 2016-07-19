using System;

using MysticChronicles.PCL.Transports.Internal;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class BaseManager {
        internal readonly BaseManagerConstructorItem ConstructorItem;

        public Guid UserGUID => ConstructorItem.UserGUID;

        public BaseManager(BaseManagerConstructorItem constructorItem) {
            ConstructorItem = constructorItem;
        }
    }
}