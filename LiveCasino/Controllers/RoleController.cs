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
    public class RoleController : ControllerBase
    {
        public readonly IRoleService _roleService;
        public RoleController(IRoleService context) 
        {
            _roleService = context;
        }

        [HttpGet]

        public async  Task<IEnumerable<Role>> GetRole() => await _roleService.GetRole();

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetRoleById(int Id)  //for getting role by id
        {
            var role = await _roleService.GetRoleById(Id);
            return role != null ? Ok(role) : NotFound();
        }

        [HttpDelete("{roleId}")]
        public async Task<bool> DeleteRoleById(int Id) // for deleting role
        {
            var admin = await _roleService.DeleteRoleById(Id);
            return true;
        }
        [HttpPost]

        public async Task<IActionResult> AddRole(Role role) //for adding role
        {
            var newRole = await _roleService.AddRole(role);
            return newRole != null ? Ok(newRole) : NotFound();
        }
    }
}
