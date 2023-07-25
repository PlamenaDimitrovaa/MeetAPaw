
using MeetAPaw.Web.ViewModels.PetType;
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.Pet;

namespace MeetAPaw.Web.ViewModels.Pet
{
    public class EditPetViewModel
    {
        public EditPetViewModel()
        {
            this.PetsTypes = new HashSet<PetTypeViewModel>();
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [StringLength(BreedMaxLength)]
        public string? Breed { get; set; }

        [Required]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(ColorMaxLength, MinimumLength = ColorMinLength)]
        public string Color { get; set; } = null!;

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "{0:mm/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; } = null!;

        [Required]
        public string OwnerId { get; set; } = null!;

        public int PetTypeId { get; set; }

        public IEnumerable<PetTypeViewModel> PetsTypes { get; set; }
    }
}
