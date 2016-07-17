using System;

using MysticChronicles.PCL.Transports.Internal;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class BaseManager {
        private readonly BaseManagerConstructorItem _constructorItem;

        public Guid UserGUID => _constructorItem.UserGUID;

        public BaseManager(BaseManagerConstructorItem constructorItem) {
            _constructorItem = constructorItem;
        }
    }
}