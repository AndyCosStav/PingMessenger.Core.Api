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

        public DbSet<Participants> Participants { get; set; }

        public DbSet<PingUser> PingUsers { get; set; }

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


            builder.Entity<Participants>(entity =>
           {
               entity.HasKey(k => k.Id)
               .HasName("PrimaryKey_ParticipantsId");

               entity.HasOne(c => c.Conversation)
               .WithMany(p => p.Participants)
               .HasForeignKey(c => c.Conversation_Id);

               entity.HasOne(c => c.PingUser)
                    .WithMany(p => p.Participants)
                    .HasForeignKey(c => c.Conversation_Id);

           });




        }

    }
}
