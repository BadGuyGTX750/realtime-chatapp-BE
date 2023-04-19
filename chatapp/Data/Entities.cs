

using chatapp.Dto;
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
    }
}
