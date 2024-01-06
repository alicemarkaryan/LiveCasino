using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LiveCasino.DLL.Context
{
    public class AdminContext : DbContext
    {

        public AdminContext(DbContextOptions<AdminContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
    }
}
