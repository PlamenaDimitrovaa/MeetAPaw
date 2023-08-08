
namespace MeetAPaw.Web.ViewModels.PetForAdoption
{
    public class PetForAdoptionViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string? Breed { get; set; }

        public int ShelterId { get; set; }

        public string DateOfBirth { get; set; }

        public int PetTypeId { get; set; }

        public string PetType { get; set; }
    }
}
