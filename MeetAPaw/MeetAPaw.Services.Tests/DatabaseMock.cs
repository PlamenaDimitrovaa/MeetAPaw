
using MeetAPaw.Data;
using MeetAPaw.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetAPaw.Services.Tests
{
    public static class DatabaseMock
    {
        public static MeetAPawDbContext Instance
        {
            get
            {
                var dbContextOptions = new DbContextOptionsBuilder<MeetAPawDbContext>()
                    .UseInMemoryDatabase("MeetAPawInMemoryDb")
                    .Options;

                return new MeetAPawDbContext(dbContextOptions);
            }
        }
    }
}
