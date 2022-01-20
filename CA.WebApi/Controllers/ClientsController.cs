using CA.Core.Domain;
using CA.Manager.Interfaces;
using CA.Manager.Validator;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClientManager _clienteManager;

        public ClientsController(IClientManager clienteManager)
        {
            this._clienteManager = clienteManager;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clienteManager.GetClientesAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _clienteManager.GetClienteAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Client cliente)
        {
            ClientValidator validator = new ClientValidator();
            var validation = validator.Validate(cliente);
            
            if (validation.IsValid)
            {
                var clientInserted = await _clienteManager.InsertClienteAsync(cliente);

                return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
            }
            else
            {
                return BadRequest(validation.ToString());
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Client cliente)
        {
            var clientUpdated = await _clienteManager.UpdateClienteAsync(cliente);
            if (clientUpdated == null) return NotFound();
            
            return Ok(clientUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteManager.DeleteClienteAsync(id);
            
            return NoContent();
        }
    }
}
