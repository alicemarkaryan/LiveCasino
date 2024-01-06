using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiveCasino.DLL
{
    public class Bonus
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public BonusType Type { get; set; }
    }
}
