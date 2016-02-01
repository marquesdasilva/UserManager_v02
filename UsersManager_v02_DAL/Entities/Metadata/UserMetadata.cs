using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UsersManager_v02_IL.Languages;

namespace UsersManager_v02_DAL.Entities.Metadata
{
    public class UserMetadata
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField", AllowEmptyStrings = false)]
        [MaxLength(250, ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "MaxLenght250")]
        [Display(ResourceType = typeof(Languages), Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "MaxLenght100")]
        [Display(ResourceType = typeof(Languages), Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField", AllowEmptyStrings = false)]
        [MaxLength(100, ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "MaxLenght100")]
        [Display(ResourceType = typeof(Languages), Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField", AllowEmptyStrings = false)]
        [MaxLength(200, ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "MaxLenght200")]
        [Display(ResourceType = typeof(Languages), Name = "EmailAdress")]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }

        //[ForeignKey("RootUserCreatedBy")]
        [Display(ResourceType = typeof(Languages), Name = "CreatedBy")]
        public int CreatedBy { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(Languages), Name = "CreatedAt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        //[ForeignKey("RootUserUpdatedBy")]
        [Display(ResourceType = typeof(Languages), Name = "UpdatedBy")]
        public int? UpdatedBy { get; set; }

        [Display(ResourceType = typeof(Languages), Name = "UpdatedAt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM--dd}", ApplyFormatInEditMode = true)]
        public DateTime? UpdatedAt { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField")]
        [DefaultValue("true")]
        [Display(ResourceType = typeof(Languages), Name = "IsActive")]
        public bool IsActive { get; set; }

        [InverseProperty("UserCreatedBy")]
        public virtual ICollection<Profile> ProfilesCreatedBy { get; set; }
        [InverseProperty("UserUpdatedBy")]
        public virtual ICollection<Profile> ProfilesUpdatedBy { get; set; }

        [InverseProperty("UserCreatedBy")]
        public virtual ICollection<Role> RolesCreatedBy { get; set; }
        [InverseProperty("UserUpdatedBy")]
        public virtual ICollection<Role> RolesUpdatedBy { get; set; }

        [InverseProperty("UserCreatedBy")]
        public virtual ICollection<ProfileRole> ProfileRolesCreatedBy { get; set; }
        [InverseProperty("UserUpdatedBy")]
        public virtual ICollection<ProfileRole> ProfileRolesUpdatedBy { get; set; }

        [InverseProperty("UserCreatedBy")]
        public virtual ICollection<Department> DepartmentCreatedBy { get; set; }
        [InverseProperty("UserUpdatedBy")]
        public virtual ICollection<Department> DepartmentUpdatedBy { get; set; }

        [InverseProperty("UserCreatedBy")]
        public virtual ICollection<Access> AccessCreatedBy { get; set; }
        [InverseProperty("UserUpdatedBy")]
        public virtual ICollection<Access> AccessUpdatedBy { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Access> Accesses { get; set; }
    }
}
