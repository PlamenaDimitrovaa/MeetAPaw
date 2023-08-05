
namespace MeetAPaw.Web.ViewModels.Adopt
{
    public class AdoptPetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string PetType { get; set; } = null!;

        public int PetTypeId { get; set; }

        public string? Breed { get; set; }

        public string Shelter { get; set; } = null!;

        public bool IsAdopted { get; set; }

        public string AdopterId { get; set; }
    }
}
