using System.Data.Entity;

using MysticChronicles.WebAPI.DataLayer.Entities.Objects;

namespace MysticChronicles.WebAPI.DataLayer.Entities {
    public class EntityFactory : DbContext {
        public virtual DbSet<Users> Users { get; set; }

        public EntityFactory() : base("name=MysticChronicles") { }
    }
}