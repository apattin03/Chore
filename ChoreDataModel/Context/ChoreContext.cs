
using ChoreDataModel.Model;
using Microsoft.EntityFrameworkCore;

namespace ChoreDataModel.Context
{
    public class ChoreContext : DbContext { 

    public ChoreContext(DbContextOptions<ChoreContext> options)
    : base(options)
    {
    }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<ChoreSprint> ChoreSprints { get; set; }

        
    }
}
