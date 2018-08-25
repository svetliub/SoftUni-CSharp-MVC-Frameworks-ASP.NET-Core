namespace MagicOfSewing.Tests.Mocks
{
    using Microsoft.EntityFrameworkCore;
    using MagicOfSewing.Data;
    using System;

    public static class MockDbContext
    {
        public static MagicOfSewingDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<MagicOfSewingDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new MagicOfSewingDbContext(options);
        }
    }
}
