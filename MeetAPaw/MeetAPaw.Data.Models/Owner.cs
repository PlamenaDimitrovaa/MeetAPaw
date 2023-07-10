
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.EntityValidationConstants.Owner;

namespace MeetAPaw.Data.Models
{
    public class Owner
    {
        public Owner()
        {
            this.Id = Guid.NewGuid();
            this.Pets = new HashSet<Pet>();
        }

        public Guid Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = null!;

        public Guid UserId { get; set; }

        public virtual ApplicationUser User { get; set; } = null!;

        public virtual ICollection<Pet> Pets { get; set; }
    }
}
