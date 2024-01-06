
using LiveCasino.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LiveCasino.Service
{
    public interface IAdminService
    {
        public Task<IEnumerable<Admin>> GetAdmin();
        public Task<Admin> GetAdminById(int Id);

        public Task<bool> DeleteAdminById(int Id);

        public Task<IActionResult> AddAdmin(Admin admin);

        public Task<IActionResult> UpdateAdmin(Admin admin);

    }
}
