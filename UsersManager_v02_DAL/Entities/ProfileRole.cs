using System;
using System.ComponentModel.DataAnnotations;
using UsersManager_v02_DAL.Entities.Metadata;

namespace UsersManager_v02_DAL.Entities
{
    [MetadataType(typeof(ProfileRoleMetadata))]
    public class ProfileRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int ProfileId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual User UserCreatedBy { get; set; }
        public virtual User UserUpdatedBy { get; set; }

        public virtual Role Role { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
