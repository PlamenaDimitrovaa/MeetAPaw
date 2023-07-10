
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.Shelter;

namespace MeetAPaw.Data.Models
{
    public class Shelter
    {
        public Shelter()
        {
            this.PetsForAdoption = new HashSet<PetForAdoption>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        public ICollection<PetForAdoption> PetsForAdoption { get; set; }
    }
}
