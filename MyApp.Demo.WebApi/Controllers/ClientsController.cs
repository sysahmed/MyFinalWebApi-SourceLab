using Microsoft.AspNetCore.Mvc;
using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private IClientsService _clientsService;
        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }
        [HttpPost("add")]
        public IActionResult Add(Client client)
        {
            var result = _clientsService.Add(client);
            if (result.Success)
            {

                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Client client)
        {
            var result = _clientsService.Update(client);
            if (result.Success)
            {

                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int clientsId)
        {
            var result = _clientsService.Delete(clientsId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
