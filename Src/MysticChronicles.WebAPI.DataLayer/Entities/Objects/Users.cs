using System;

namespace MysticChronicles.WebAPI.DataLayer.Entities.Objects {
    public class Users {
        public Guid GUID { get; set; }

        public DateTimeOffset Modified { get; set; }

        public DateTimeOffset Created { get; set; }

        public bool Active { get; set; }

        public string Token { get; set; }

        public string DisplayName { get; set; }
    }
}