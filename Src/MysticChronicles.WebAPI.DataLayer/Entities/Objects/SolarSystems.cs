using System;
using System.ComponentModel.DataAnnotations;

namespace MysticChronicles.WebAPI.DataLayer.Entities.Objects {
    public class SolarSystems {
        [Key]
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public string Name { get; set; }

        public string MapDefinition { get; set; }
    }
}