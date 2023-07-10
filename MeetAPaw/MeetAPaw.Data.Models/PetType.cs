
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.PetType;

namespace MeetAPaw.Data.Models
{
    public class PetType
    {
        public PetType()
        {
            this.Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
