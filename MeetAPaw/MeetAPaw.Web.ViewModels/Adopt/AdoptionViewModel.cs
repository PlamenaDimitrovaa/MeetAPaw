
using System.ComponentModel.DataAnnotations;

namespace MeetAPaw.Web.ViewModels.Adopt
{
    public class AdoptionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string AdopterId { get; set; }

        public string Adopter { get; set; }
        public int PetForAdoptionId { get; set; }

        public string Pet { get; set; }
        public string Date { get; set; }

        public string? MoreInformation { get; set; }

        public int ShelterId { get; set; }
    }
}
