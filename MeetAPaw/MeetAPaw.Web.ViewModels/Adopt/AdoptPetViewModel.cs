﻿
namespace MeetAPaw.Web.ViewModels.Adopt
{
    public class AdoptPetViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string DateOfBirth { get; set; } = null!;

        public string PetType { get; set; } = null!;

        public string? Breed { get; set; }
    }
}
