
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using static MeetAPaw.Common.EntityValidationConstants.PetForAdoption;
using MeetAPaw.Web.ViewModels.Shelter;
using MeetAPaw.Web.ViewModels.PetType;

namespace MeetAPaw.Web.ViewModels.PetForAdoption
{
    public class AddPetForAdoptionViewModel
    {
        public AddPetForAdoptionViewModel()
        {
            this.Shelters = new HashSet<ShelterViewModel>();
            this.PetsTypes = new HashSet<PetTypeViewModel>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        public int PetTypeId { get; set; }

        public string? Breed { get; set; }

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string DateOfBirth { get; set; } = null!;

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public bool IsAdopted { get; set; }

        [Required]
        public int ShelterId { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        public IEnumerable<ShelterViewModel> Shelters { get; set; }

        public IEnumerable<PetTypeViewModel> PetsTypes { get; set; }

    }
}
