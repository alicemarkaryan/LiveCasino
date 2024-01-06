
using LiveCasino.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LiveCasino.Service
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetClient();
        public Task<Client> GetClientById(int Id);

        public  Task<bool> DeleteClientById(int Id);
        public  Task<IActionResult> AddClient(Client client);

        public Task<IActionResult> UpdateClient(Client client);
    }
}
