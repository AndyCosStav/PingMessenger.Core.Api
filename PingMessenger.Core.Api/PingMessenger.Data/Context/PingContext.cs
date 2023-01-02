using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PingMessenger.Models.Models;

namespace PingMessenger.Data.Context
{
    public class PingContext : IdentityDbContext<IdentityUser>
    {

        public PingContext(DbContextOptions<PingContext> options)
             : base(options)
        {

        }

        public DbSet<Conversation> Conversations { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<PingUser> PingUsers { get; set; }
        public DbSet<AddressBook> AddressBook {get;set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Conversation>()
                .HasKey(c => c.Id)
                .HasName("PrimaryKey_ConversationId");

            builder.Entity<Message>(entity =>
            {
                entity.HasKey(K => K.Id)
                .HasName("PrimaryKey_MessageId");

                entity.HasOne(c => c.Conversation)
                .WithMany(m => m.Messages)
                .HasForeignKey(c => c.Conversation_Id);

            });


        }

    }
}
