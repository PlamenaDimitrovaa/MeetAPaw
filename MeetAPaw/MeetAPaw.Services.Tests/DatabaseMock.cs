using MeetAPaw.Data;
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
