using LiveCasino.DLL;
using LiveCasino.DLL.Context;
using LiveCasino.Logs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;

namespace LiveCasino.Service
{
 
    public class ClientService : ControllerBase,IClientService
    {
        Log logger = new Log();
        public readonly ClientContext _context;

        public ClientService(ClientContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Client>> GetClient() => await _context.Clients.ToListAsync();

        [HttpGet("{id:int}")]

        public async Task<Client> GetClientById(int Id)
        {
            try
            {
                var client = await _context.Clients.FindAsync(Id); //Getting client by id
                return client;
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Log for Live casino client doesn't exist{ex}");
                throw;
            }
        }


        [HttpDelete("{clientId:int}")]
        public async Task<bool> DeleteClientById(int Id)  //Deleting client by id
        {
            try
            {
                var client = await _context.Clients.FindAsync(Id);

                if (client != null)
                {
                    _context.Clients.Remove(client); // Delete the client from the database
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
                logger.LogMessage($"Error deleting client: {ex}");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddClient([FromBody] Client client) //add client in database
        {
            try
            {
                var clientdb =  await _context.Clients.FindAsync(client.Id);

                if (clientdb == null)
                {
                    var newClient = new Client
                    {
                        Id = client.Id,
                        FirstName = client.FirstName,
                        LastName = client.LastName,
                        BirthDate = client.BirthDate,
                        Email = client.Email,
                        PhoneNumber = client.PhoneNumber,
                        Country = client.Country,
                        UserName = client.UserName,
                        AccountBalance = 0
                    };

                    _context.Clients.Add(newClient);
                    await _context.SaveChangesAsync();


                    return Ok(newClient);
                }
                else
                {
                    return BadRequest("Invalid client data");
                }
            }
            catch (Exception ex)
            {
                logger.LogMessage($"Error adding client: {ex}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateClient(Client client)
        {
            var db = await _context.Clients.FindAsync(client.Id);

            if (db == null)
                throw new Exception("Client doesn't exist");

            var updatedClient = new Client
            {
                Email   = client.Email,
                PhoneNumber = client.PhoneNumber,
                Country = client.Country
            };
            return Ok(updatedClient);
        }
    }
}