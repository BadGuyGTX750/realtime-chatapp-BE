

using chatapp.Dtos;
using Microsoft.EntityFrameworkCore;

namespace chatapp.Data
{
    public class Entities : DbContext
    {

        public Entities(DbContextOptions<Entities> options) : base(options) { }

        public DbSet<Message> messages { get; set; }

        public DbSet<Conversation> conversations { get; set; }

        public DbSet<GroupMember> groupMembers { get; set; }

        public DbSet<Contact> contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conversation>()
                .HasMany(u => u.messages)
                .WithOne(u => u.conversation)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Conversation>()
                .HasMany(u => u.group_members)
                .WithOne(u => u.conversation)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Contact>()
                .HasMany(u => u.group_members)
                .WithOne(u => u.contact)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
