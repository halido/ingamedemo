using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abp.Auditing;
using Abp.Authorization.Users;

namespace InGame.BestPractice.Web.Models.Account
{
    public class ResetPasswordViewModel:IValidatableObject
    {
        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string Email { get; set; }

        [Required]
        [DisableAuditing]
        [DataType(DataType.Password)]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DisableAuditing]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisableAuditing]
        public string Code { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Password != ConfirmPassword)
            {
                yield return new ValidationResult("The password and confirmation password do not match.");
            }
        }
    }
}