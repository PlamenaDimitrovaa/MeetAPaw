
namespace MeetAPaw.Common
{
    public static class EntityValidationConstants
    {
        public static class Pet
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 60;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 2000;

            public const int ImageUrlMaxLength = 2048;

            public const int BreedMinLength = 5;
            public const int BreedMaxLength = 50;

            public const int ColorMinLength = 3;
            public const int ColorMaxLength = 50;
        }

        public static class PetForAdoption
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 60;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;

            public const int DescriptionMinLength = 15;
            public const int DescriptionMaxLength = 2000;

            public const int ImageUrlMaxLength = 2048;

            public const int ColorMinLength = 3;
            public const int ColorMaxLength = 50;
        }

        public static class PetType
        {
            public const int NameMinLength = 20;
            public const int NameMaxLength = 50;
        }

        public static class Color
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 40;
        }

        public static class Shelter
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 100;

            public const int AddressMinLength = 5;
            public const int AddressMaxLength = 100;
        }

        public static class User
        {
            public const int FirstNameMinLength = 2;
            public const int FirstNameMaxLength = 15;

            public const int LastNameMinLength = 2;
            public const int LastNameMaxLength = 15;
        }

        public static class Adoption
        {
            public const int MoreInformationMaxLength = 2000;
            public const int MoreInformationMinLength = 10;
        }
    }
}
