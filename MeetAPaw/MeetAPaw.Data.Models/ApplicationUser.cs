
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static MeetAPaw.Common.EntityValidationConstants.User;

namespace MeetAPaw.Data.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
            this.OwnedPets = new HashSet<Pet>();
            this.PetsForAdoption = new HashSet<PetForAdoption>();
        }

        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Pet> OwnedPets { get; set; }

        [InverseProperty("User")]
        public ICollection<PetForAdoption> PetsForAdoptionAdded { get; set; }

        [InverseProperty("Adopter")]
        public virtual ICollection<PetForAdoption> PetsForAdoption { get; set; }
    }
}
