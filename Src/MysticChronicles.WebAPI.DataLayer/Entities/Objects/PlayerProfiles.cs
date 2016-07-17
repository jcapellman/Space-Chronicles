using System;
using System.ComponentModel.DataAnnotations;

namespace MysticChronicles.WebAPI.DataLayer.Entities.Objects {
    public class PlayerProfiles {
        [Key]
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public int Experience { get; set; }

        public int Level { get; set; }

        public Guid UserGUID { get; set; }

        public int Credits { get; set; }

        public int EventTurns { get; set; }
    }
}