
using MeetAPaw.Web.ViewModels.Pet;

namespace MeetAPaw.Services.Data.Models.Pet
{
    public class AllPetsFilteredAndPagesServiceModel
    {
        public AllPetsFilteredAndPagesServiceModel()
        {
            this.Pets = new HashSet<PetViewModel>();
        }
        public int TotalPetsCount { get; set; }

        public IEnumerable<PetViewModel> Pets { get; set; }
    }
}
