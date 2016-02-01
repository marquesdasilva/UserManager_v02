using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UsersManager_v02_DAL.Entities.Metadata;

namespace UsersManager_v02_DAL.Entities
{
    [MetadataType(typeof(UserMetadata))]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAdress { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Profile> ProfilesCreatedBy { get; set; }
        public virtual ICollection<Profile> ProfilesUpdatedBy { get; set; }

        public virtual ICollection<Role> RolesCreatedBy { get; set; }
        public virtual ICollection<Role> RolesUpdatedBy { get; set; }

        public virtual ICollection<ProfileRole> ProfileRolesCreatedBy { get; set; }
        public virtual ICollection<ProfileRole> ProfileRolesUpdatedBy { get; set; }

        public virtual ICollection<Department> DepartmentCreatedBy { get; set; }
        public virtual ICollection<Department> DepartmentUpdatedBy { get; set; }

        public virtual ICollection<Access> AccessCreatedBy { get; set; }
        public virtual ICollection<Access> AccessUpdatedBy { get; set; }
        public virtual ICollection<Access> Accesses { get; set; }

        //public virtual User RootUserCreatedBy { get; set; }
        //public virtual ICollection<User> UserCreatedBy { get; set; }
        //public virtual User RootUserUpdatedBy { get; set; }
        //public virtual ICollection<User> UserUpdatedBy { get; set; }
    }
}
