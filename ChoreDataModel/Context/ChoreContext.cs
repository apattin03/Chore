using System;
using System.Collections.Generic;
using System.Text;
using ChoreDataModel.Model;
using Microsoft.EntityFrameworkCore;

namespace ChoreDataModel.Context
{
    public class ChoreContext : DbContext
    {
        public virtual DbSet<Chore> Chores { get; set; }
        public virtual DbSet<Partner> Partners { get; set; }
        public virtual DbSet<ChoreSprint> ChoreSprints { get; set; }

        
    }
}
