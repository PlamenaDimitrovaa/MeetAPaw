
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.PetForAdoption;
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.Shelter;

namespace MeetAPaw.Web.ViewModels.Shelter
{
    public class ShelterProfileViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required(AllowEmptyStrings = false)]
        public string ImageUrl { get; set; } = null!;

        public virtual ICollection<PetForAdoptionViewModel> PetsForAdoption { get; set; }

        public virtual ICollection<AdoptionViewModel> Adoptions { get; set; }

    }
}
