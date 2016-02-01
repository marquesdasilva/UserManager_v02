using System;
using System.ComponentModel.DataAnnotations;
using UsersManager_v02_DAL.Entities;

namespace UsersManager_v02_UI_MVC.Models.ViewModels
{
    public class VMUserCreate
    {
        public User User { get; set; }

        [Required(ErrorMessage = "This is a required field")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public String ConfirmPassword { get; set; }

        public VMUserCreate()
        {
            User = new User();
            User.IsActive = true;

            ConfirmPassword = String.Empty;
        }
    }
}
