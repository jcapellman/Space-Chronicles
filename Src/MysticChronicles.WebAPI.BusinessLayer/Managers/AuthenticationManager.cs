using System;

using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.Internal;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class AuthenticationManager : BaseManager {
        public AuthenticationManager() : base(null) { }

        public ReturnSet<BaseManagerConstructorItem> GetBaseManagerConstructorItemFromToken(string token) {
            return new ReturnSet<BaseManagerConstructorItem>(new BaseManagerConstructorItem {
                UserGUID = Guid.NewGuid()
            });
        }
    }
}