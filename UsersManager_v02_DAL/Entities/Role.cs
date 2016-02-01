using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UsersManager_v02_DAL.Entities.Metadata;

namespace UsersManager_v02_DAL.Entities
{
    [MetadataType(typeof(RoleMetadata))]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual User UserCreatedBy { get; set; }
        public virtual User UserUpdatedBy { get; set; }

        public virtual ICollection<ProfileRole> ProfileRoles { get; set; }
    }
}
