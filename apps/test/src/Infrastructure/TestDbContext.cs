using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Test.Infrastructure;

public class TestDbContext : IdentityDbContext<IdentityUser>
{
    public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options) { }
}
