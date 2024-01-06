using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LiveCasino.DLL.Context
{
    public class RoleContext : DbContext
    {

        public RoleContext(DbContextOptions<ClientContext> options) : base(options) { }

        public DbSet<Role> Roles { get; set; }
    }
}
