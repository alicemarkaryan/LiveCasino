using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LiveCasino.DLL.Context
{
    public class BonusContext : DbContext
    {

        public BonusContext(DbContextOptions<BonusContext> options) : base(options) { }
        
        public DbSet<Bonus> Bonuses { get; set; }
    }
}
