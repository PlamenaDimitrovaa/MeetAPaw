﻿
namespace MeetAPaw.Web.ViewModels.PetForAdoption
{
    public class PetForAdoptionProfileViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public string Color { get; set; }

        public string? Breed { get; set; }

        public string PetType { get; set; }

        public string? Address { get; set; }

        public string Shelter { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }
    }
}
