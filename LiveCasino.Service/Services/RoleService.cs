using LiveCasino.DLL;
using LiveCasino.DLL.Context;
using LiveCasino.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;

namespace LiveCasino.Service
{
 
    public class RoleService : ControllerBase,IRoleService
    {
        Log logger = new Log();
        public readonly RoleContext _context;

        public RoleService(RoleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetRole() => await _context.Roles.ToListAsync();

        [HttpGet("{id:int}")]

        public async Task<Role> GetRoleById(int Id)
        {
            try
            {
                var role = await _context.Roles.FindAsync(Id); //Getting role by id
                return role;
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Log for Live casino role doesn't exist{ex}");
                throw;
            }
        }


        [HttpDelete("{roleId:int}")]
        public async Task<bool> DeleteRoleById(int Id)  //Deleting role by id
        {
            try
            {
                var role = await _context.Roles.FindAsync(Id);

                if (role != null)
                {
                    _context.Roles.Remove(role); // Delete the role from the database
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
                logger.LogMessage($"Error deleting role: {ex}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody]Role role) //add role in database
        {
            try
            {
                var roledb =  await _context.Roles.FindAsync(role.Id);

                if (roledb == null)
                {
                    var newRole = new Role
                    {
                        Id = role.Id,
                        Type = role.Type

                    };

                    _context.Roles.Add(newRole);
                    await _context.SaveChangesAsync();


                    return Ok(newRole);
                }
                else
                {
                    return BadRequest("Invalid role data");
                }
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error adding role: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateRole(Role role)
        {
            var entity = await _context.Roles.FindAsync(role.Id);

            if (entity == null)
                throw new Exception("Role doesn't exist");

            var updatedRole = new Role
            {
                Type = role.Type
            };
            return Ok(updatedRole);
        }
    }
}