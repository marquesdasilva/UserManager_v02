using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UsersManager_v02_IL.Languages;

namespace UsersManager_v02_DAL.Entities.Metadata
{
    public class ProfileRoleMetadata
    {
        public int Id { get; set; }

        [Display(ResourceType = typeof(Languages), Name = "Role")]
        public int RoleId { get; set; }

        [Display(ResourceType = typeof(Languages), Name = "Profile")]
        public int ProfileId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField")]
        [ForeignKey("UserCreatedBy")]
        [Display(ResourceType = typeof(Languages), Name = "CreatedBy")]
        public int CreatedBy { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField")]
        [Display(ResourceType = typeof(Languages), Name = "CreatedAt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM--dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("UserUpdatedBy")]
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

        public virtual User UserCreatedBy { get; set; }
        public virtual User UserUpdatedBy { get; set; }

        public virtual Role Role { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
