
using LiveCasino.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LiveCasino.Service
{
    public interface IBonusService
    {
        public Task<IEnumerable<Bonus>> GetBonus();
        public Task<Bonus> GetBonusById(int Id);

        public  Task<bool> DeleteBonusById(int Id);
        public  Task<IActionResult> AddBonus(Bonus bonus);

        public Task<IActionResult> UpdateBonus(Bonus bonus);
    }
}
