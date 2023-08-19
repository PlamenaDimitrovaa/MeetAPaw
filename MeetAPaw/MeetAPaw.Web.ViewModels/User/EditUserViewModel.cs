
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.User;
namespace MeetAPaw.Web.ViewModels.User
{
    public class EditUserViewModel
    {
        public string Id { get; set; } = null!;

        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
    }
}
