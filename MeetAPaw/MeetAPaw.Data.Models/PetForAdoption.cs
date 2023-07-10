
using MeetAPaw.Data.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.PetForAdoption;

namespace MeetAPaw.Data.Models
{
    public class PetForAdoption
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public int PetTypeId { get; set; }

        [ForeignKey(nameof(PetTypeId))]
        public virtual PetType PetType { get; set; } = null!;

        public string? Breed { get; set; }

        [Required]
        [MaxLength(ColorMaxLength)]
        public string Color { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public PetGender Gender { get; set; }

        public bool IsAdopted { get; set; }

        public int ShelterId { get; set; }

        [ForeignKey(nameof(ShelterId))]
        public virtual Shelter Shelter { get; set; } = null!;
    }
}
