using System.Linq;

using MysticChronicles.PCL.Transports.Global;
using MysticChronicles.PCL.Transports.Internal;
using MysticChronicles.WebAPI.DataLayer.Entities;

namespace MysticChronicles.WebAPI.BusinessLayer.Managers {
    public class AuthenticationManager : BaseManager {
        public AuthenticationManager() : base(null) { }

        public ReturnSet<BaseManagerConstructorItem> GetBaseManagerConstructorItemFromToken(string token) {
            using (var eFactory = new EntityFactory()) {
                var user = eFactory.Users.FirstOrDefault(a => a.Token == token);

                if (user == null) {
                    return null;
                }

                return new ReturnSet<BaseManagerConstructorItem>(new BaseManagerConstructorItem {
                    UserGUID = user.GUID
                });
            }
        }
    }
}