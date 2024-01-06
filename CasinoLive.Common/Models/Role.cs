using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCasino.DLL
{
    public class Role
    {
        public int Id {  get; set; }
        public  List<Permission> Type { get; set; }
    }
}
