using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LiveCasino.DLL.Context
{
    public class ClientContext : DbContext
    {

        public ClientContext(DbContextOptions<ClientContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bonus> Bonuses { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
