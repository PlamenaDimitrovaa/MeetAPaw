using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using MeetAPaw.Services.Data;
using MeetAPaw.Services.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace MeetAPaw.Services.Tests
{
    [TestFixture]
    public class PetServiceTests : UnitTestsBase
    {
        private IPetService petService;

        [SetUp]
        public void Setup()
        {
            this.petService = new PetService(this.data);
        }

        //[Test]
        //public void GetPetByIdAsyncShouldReturnCorrectPet()
        //{
        //    var mock = new Mock<MeetAPawDbContext>()
        //    .Setup(db => db.Pets)
        //    .ReturnsDbSet(new List<Pet>()
        //    {

        //    });
        //}
    }
}