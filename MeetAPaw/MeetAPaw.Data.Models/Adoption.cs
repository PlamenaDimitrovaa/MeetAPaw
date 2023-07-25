
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeetAPaw.Data.Models
{
    public class Adoption
    {
        public int Id { get; set; }

        [Required]
        public Guid AdopterId { get; set; }

        [ForeignKey(nameof(AdopterId))]
        public virtual ApplicationUser Adopter { get; set; } = null!;

        public int PetForAdoptionId { get; set; }

        [ForeignKey(nameof(PetForAdoptionId))]
        public virtual PetForAdoption PetForAdoption { get; set; } = null!;

        public DateTime Date { get; set; }

        public string? MoreInformation { get; set; }

        public int ShelterId { get; set; }

        [ForeignKey(nameof(ShelterId))]
        public virtual Shelter Shelter { get; set; } = null!;

    }
}
