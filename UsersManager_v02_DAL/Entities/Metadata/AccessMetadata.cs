using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UsersManager_v02_IL.Languages;

namespace UsersManager_v02_DAL.Entities.Metadata
{
    public partial class AccessMetadata
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        [Display(ResourceType = typeof(Languages), Name = "User")]
        public int UserId { get; set; }

        [Display(ResourceType = typeof(Languages), Name = "Department")]
        public int DepartmentId { get; set; }

        [Display(ResourceType = typeof(Languages), Name = "Profile")]
        public int ProfileId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Languages), ErrorMessageResourceName = "RequiredField")]
        [DefaultValue("false")]
        [Display(ResourceType = typeof(Languages), Name = "IsGlobal")]
        public bool IsGlobal { get; set; }

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

        public virtual User User { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual Department Deparment { get; set; }

        public virtual User UserCreatedBy { get; set; }
        public virtual User UserUpdatedBy { get; set; }
    }

}
