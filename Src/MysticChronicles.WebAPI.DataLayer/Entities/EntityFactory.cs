using System.Data.Entity;

using MysticChronicles.WebAPI.DataLayer.Entities.Objects;

namespace MysticChronicles.WebAPI.DataLayer.Entities {
    public class EntityFactory : DbContext {
        public virtual DbSet<Users> Users { get; set; }

        public virtual DbSet<PlayerProfiles> PlayerProfiles { get; set; }

        public EntityFactory() : base("Server=jcmns.database.windows.net;Database=mysticchronicles;user id=jcmns;password=mbs43v3R!") { }
    }
}