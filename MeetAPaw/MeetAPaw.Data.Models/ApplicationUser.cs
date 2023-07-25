
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public virtual ICollection<Pet> OwnedPets { get; set; }

        [InverseProperty("User")]
        public ICollection<PetForAdoption> PetsForAdoptionAdded { get; set; }

        [InverseProperty("Adopter")]
        public virtual ICollection<PetForAdoption> PetsForAdoption { get; set; }
    }
}
