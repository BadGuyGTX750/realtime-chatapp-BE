

using Microsoft.EntityFrameworkCore;

namespace chatapp.Data
{
    public class Entities : DbContext
    {

        public Entities(DbContextOptions<Entities> options) : base(options) { }


    }
}
