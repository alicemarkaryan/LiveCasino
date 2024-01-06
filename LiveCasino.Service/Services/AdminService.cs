using LiveCasino.DLL;
using LiveCasino.DLL.Context;
using LiveCasino.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LiveCasino.Service.Services
{

    public class AdminService : ControllerBase, IAdminService
    {
        Log logger = new Log();
        public readonly AdminContext _context;

        public AdminService(AdminContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Admin>> GetAdmin() => await _context.Admins.ToListAsync(); //for getting all admin

        [HttpGet("{id:int}")]

        public async Task<Admin> GetAdminById(int Id) //for getting admin by id
        {
            try
            {
                var admin = await _context.Admins.FindAsync(Id);
                return admin;
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Log for Live casino admin doesn't exist {ex}");
                throw;
            }
        }

        public async Task<bool> DeleteAdminById(int Id)
        {
            try
            {
                var admin = await _context.Admins.FindAsync(Id);

                if (admin != null)
                {
                    _context.Admins.Remove(admin); // delete the admin from the db
                    await _context.SaveChangesAsync(); //  saves the changes to the database
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error deleting admin: {ex}");
                throw;
            }
        }


        [HttpPost]
        public async Task<IActionResult> AddAdmin([FromBody] Admin admin) //add admin in database
        {
            try
            {
                var admindb = await _context.Admins.FindAsync(admin.Id);

                if (admindb == null)
                {
                    var newAdmin = new Admin
                    {
                        Id = admin.Id,
                        Email = admin.Email,
                        FirstName = admin.FirstName,
                        LastName = admin.LastName,
                        Role = admin.Role,
                        UserName = admin.UserName
                    };

                    _context.Admins.Add(newAdmin);
                    await _context.SaveChangesAsync();


                    return Ok(newAdmin);
                }
                else
                {
                    return BadRequest("Invalid admin amount");
                }
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error adding admin: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateAdmin(Admin admin)
        {
            var db = await _context.Admins.FindAsync(admin.Id);

            if (db == null)
                throw new Exception("admin doesn't exist");

            var updatedAdmi = new Admin
            {
               
                Email = admin.Email,
                UserName = admin.UserName
                
            };
            return Ok(updatedAdmi);
        }
    }
}