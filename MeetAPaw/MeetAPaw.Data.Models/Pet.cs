
using MeetAPaw.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MeetAPaw.Common.EntityValidationConstants.Pet;

namespace MeetAPaw.Data.Models
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public int PetTypeId { get; set; }

        [ForeignKey(nameof(PetTypeId))]
        public PetType PetType { get; set; } = null!;

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

        public Guid OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public virtual Owner Owner { get; set; } = null!;
    }
}
