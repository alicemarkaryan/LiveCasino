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
    public class ClientController : ControllerBase
    {
        public readonly IClientService _clientService;
        public ClientController(IClientService context) 
        {
            _clientService = context;
        }

        [HttpGet]

        public async  Task<IEnumerable<Client>> GetClient() => await _clientService.GetClient();

        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetClientById(int Id)  //for getting client by id
        {
            var client = await _clientService.GetClientById(Id);
            return client != null ? Ok(client) : NotFound();
        }

        [HttpDelete("{clientId}")]
        public async Task<bool> DeleteClientById(int Id) // for deleting client
        {
            var admin = await _clientService.DeleteClientById(Id);
            return true;
        }
        [HttpPost]

        public async Task<IActionResult> AddClient(Client client) //for adding client
        {
            var newClient = await _clientService.AddClient(client);
            return newClient != null ? Ok(newClient) : NotFound();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateClient(Client client) //for updating client
        {
            var newClient = await _clientService.UpdateClient(client);
            return newClient != null ? Ok(newClient) : NotFound();
        }
    }
}
