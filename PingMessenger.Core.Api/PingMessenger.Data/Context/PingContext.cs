using Microsoft.EntityFrameworkCore;
using PingMessenger.Models;

namespace PingMessenger.Data.Context
{
    public class PingContext : DbContext
    {

        public PingContext(DbContextOptions<PingContext> options)
             : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


        }

        public DbSet<User> Users { get; set; }

    }
}
