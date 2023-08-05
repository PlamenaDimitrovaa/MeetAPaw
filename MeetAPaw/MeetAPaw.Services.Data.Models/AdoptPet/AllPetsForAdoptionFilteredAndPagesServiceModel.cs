
using MeetAPaw.Web.ViewModels.Adopt;
using MeetAPaw.Web.ViewModels.Pet;

namespace MeetAPaw.Services.Data.Models.AdoptPet
{
    public class AllPetsForAdoptionFilteredAndPagesServiceModel
    {
        public AllPetsForAdoptionFilteredAndPagesServiceModel()
        {
            this.Pets = new HashSet<AdoptPetViewModel>();
        }
        public int TotalPetsCount { get; set; }

        public IEnumerable<AdoptPetViewModel> Pets { get; set; }
    }
}
