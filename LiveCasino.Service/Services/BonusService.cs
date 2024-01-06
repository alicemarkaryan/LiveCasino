using LiveCasino.DLL;
using LiveCasino.DLL.Context;
using LiveCasino.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;

namespace LiveCasino.Service
{
 
    public class BonusService : ControllerBase,IBonusService
    {
        Log logger = new Log();
        public readonly BonusContext _context;

        public BonusService(BonusContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bonus>> GetBonus() => await _context.Bonuses.ToListAsync();

        [HttpGet("{id:int}")]

        public async Task<Bonus> GetBonusById(int Id)
        {
            try
            {
                var bonus = await _context.Bonuses.FindAsync(Id); //Getting bonus by id
                return bonus;
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Log for Live casino bonus doesn't exist{ex}");
                throw;
            }
        }


        [HttpDelete("{bonusId:int}")]
        public async Task<bool> DeleteBonusById(int Id)  //Deleting bonus by id
        {
            try
            {
                var bonus = await _context.Bonuses.FindAsync(Id);

                if (bonus != null)
                {
                    _context.Bonuses.Remove(bonus); // Delete the bonus from the database
                    await _context.SaveChangesAsync(); // saves the changes to the database
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error deleting bonus: {ex}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBonus([FromBody] Bonus bonus) //add bonus in database
        {
            try
            {
                var bonusdb =  await _context.Bonuses.FindAsync(bonus.Id);

                if (bonusdb == null)
                {
                    var newBonus = new Bonus
                    {
                        Id = bonus.Id,
                        Amount = bonus.Amount,
                        Type = bonus.Type,
                     
                    };

                    _context.Bonuses.Add(newBonus);
                    await _context.SaveChangesAsync();


                    return Ok(newBonus);
                }
                else
                {
                    return BadRequest("Invalid bonus amount");
                }
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error adding bouns: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateBonus(Bonus bonus)
        {
            var db = await _context.Bonuses.FindAsync(bonus.Id);

            if (db == null)
                throw new Exception("Bonus doesn't exist");

            var updatedBonus = new Bonus
            {
                Id = bonus.Id,
                Amount = bonus.Amount,
                Type = bonus.Type,
            };
            return Ok(updatedBonus);
        }
    }
}