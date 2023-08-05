
using System.ComponentModel.DataAnnotations;
using static MeetAPaw.Common.GeneralApplicationConstants;

namespace MeetAPaw.Web.ViewModels.Adopt
{
    public class AllPetsForAdoptionQueryModel
    {
        public AllPetsForAdoptionQueryModel()
        {
            this.PetsTypes = new HashSet<string>();
            this.Pets = new HashSet<AdoptPetViewModel>();
            this.CurrentPage = DefaultPage;
            this.PetsPerPage = _PetsPerPage;
        }

        [Display(Name = "Pet types")]
        public string PetType { get; set; }

        [Display(Name = "Search")]
        public string? SearchString { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Pets per page")]
        public int PetsPerPage { get; set; }

        public int TotalPets { get; set; }

        public IEnumerable<string> PetsTypes { get; set; }

        public IEnumerable<AdoptPetViewModel> Pets { get; set; }
    }
}
