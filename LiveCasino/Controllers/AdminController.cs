using LiveCasino.DLL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using LiveCasino.Service;
using LiveCasino.DLL;
using System.Collections.Generic;

namespace LiveCasino.Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public readonly IAdminService _adminService;
        public AdminController(IAdminService admin) 
        {
            _adminService = admin;
        }

        
        [HttpGet]
        public async Task<IEnumerable<Admin>> GetAdmin() => await _adminService.GetAdmin(); //for getting all admin


        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetAdminById(int Id) //for getting admin by id
        {
            var admin = await _adminService.GetAdminById(Id);
            return admin != null ? Ok(admin) : NotFound();
        }


        [HttpDelete("{adminId}")]
        public async Task<bool> DeleteAdminById(int Id) //for deleting admin by id
        {
            var admin = await _adminService.DeleteAdminById(Id);
            return true;
        }

        [HttpPost]

        public async Task<IActionResult> AddAdmin(Admin admin) //for adding admin
        {
            var newAdmin = await _adminService.AddAdmin(admin);
            return newAdmin!= null ? Ok(newAdmin) : NotFound();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAdmin(Admin admin) //for updating admin
        {
            var newAdmin = await _adminService.UpdateAdmin(admin);
            return newAdmin != null ? Ok(newAdmin) : NotFound();
        }
    }
}
