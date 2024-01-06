using LiveCasino.DLL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LiveCasino.Service;
using LiveCasino.DLL;
using System.Collections.Generic;
using LiveCasino.Service.Services;
using System.Threading.Tasks;

namespace LiveCasino.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusController : ControllerBase
    {
        public readonly IBonusService _bonusService;
        public BonusController(IBonusService context) 
        {
            _bonusService = context;
        }

        [HttpGet]

        public async  Task<IEnumerable<Bonus>> GetBonus() => await _bonusService.GetBonus();

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetBonusById(int Id)  //for getting bonus by id
        {
            var bonus = await _bonusService.GetBonusById(Id);
            return bonus != null ? Ok(bonus) : NotFound();
        }

        [HttpDelete("{bonusId}")]
        public async Task<bool> DeleteBonusById(int Id) // for deleting bonus
        {
            var admin = await _bonusService.DeleteBonusById(Id);
            return true;
        }
        [HttpPost]

        public async Task<IActionResult> AddBonus(Bonus bonus) //for adding bonus
        {
            var newBonus = await _bonusService.AddBonus(bonus);
            return newBonus != null ? Ok(newBonus) : NotFound();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBonus(Bonus bonus) //for updating bonus
        {
            var newBonus = await _bonusService.UpdateBonus(bonus);
            return newBonus != null ? Ok(newBonus) : NotFound();
        }
    }
}
