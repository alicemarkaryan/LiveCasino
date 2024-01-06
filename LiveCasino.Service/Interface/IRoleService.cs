
using LiveCasino.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LiveCasino.Service
{
    public interface IRoleService
    {
        public Task<IEnumerable<Role>> GetRole();
        public Task<Role> GetRoleById(int Id);

        public  Task<bool> DeleteRoleById(int Id);
        public  Task<IActionResult> AddRole(Role role);
        public Task<IActionResult> UpdateRole(Role role);
    }
}
