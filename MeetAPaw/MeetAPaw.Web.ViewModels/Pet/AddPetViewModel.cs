

using MeetAPaw.Web.ViewModels.PetType;

namespace MeetAPaw.Web.ViewModels.Pet
{
    public class AddPetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Breed { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Gender { get; set; }

        public string DateOfBirth { get; set; }

        public int PetTypeId { get; set; }

        public ICollection<PetTypeViewModel> PetsTypes { get; set; }

    }
}
