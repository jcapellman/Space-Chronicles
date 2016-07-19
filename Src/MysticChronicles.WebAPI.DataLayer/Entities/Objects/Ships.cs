using System;
using System.ComponentModel.DataAnnotations;

namespace MysticChronicles.WebAPI.DataLayer.Entities.Objects {
    public class Ships {
        [Key]
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TextureName { get; set; }

        public int HP { get; set; }

        public int ShieldStrength { get; set; }

        public int CargoSpace { get; set; }

        public int Cost { get; set; }
    }
}