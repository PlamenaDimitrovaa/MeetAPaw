
namespace MeetAPaw.Web.ViewModels.PetForAdoption
{
    public class PetForAdoptionProfileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Color { get; set; } = null!;

        public string? Breed { get; set; }

        public string PetType { get; set; } = null!;

        public string? Address { get; set; }

        public string Shelter { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string User { get; set; } = null!;
    }
}
