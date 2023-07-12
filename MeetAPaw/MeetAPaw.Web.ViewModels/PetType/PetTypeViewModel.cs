
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.PetType;

namespace MeetAPaw.Web.ViewModels.PetType
{
    public class PetTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

    }
}
