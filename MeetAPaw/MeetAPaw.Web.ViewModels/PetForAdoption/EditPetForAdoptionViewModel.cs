
using MeetAPaw.Web.ViewModels.PetType;
using MeetAPaw.Web.ViewModels.Shelter;
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.PetForAdoption;

namespace MeetAPaw.Web.ViewModels.PetForAdoption
{
    public class EditPetForAdoptionViewModel
    {
        public EditPetForAdoptionViewModel()
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
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        public bool IsAdopted { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int ShelterId { get; set; }

        public IEnumerable<ShelterViewModel> Shelters { get; set; }

        public IEnumerable<PetTypeViewModel> PetsTypes { get; set; }
    }
}
