using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PingMessenger.Data.Context
{
    public class PingContext : IdentityDbContext<IdentityUser>
    {

        public PingContext(DbContextOptions<PingContext> options)
             : base(options)
        {

        }

    }
}
