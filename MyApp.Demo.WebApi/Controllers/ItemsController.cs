using Microsoft.AspNetCore.Mvc;
using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IItemsService _itemsService;
        public ItemsController(IItemsService itemsService)
        {
            _itemsService=itemsService;
        }
        [HttpPost("add")]
        public IActionResult Add(Item item)
        {
            var result = _itemsService.Add(item);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Item item)
        {
            var result = _itemsService.Update(item);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int itemId)
        {
            var result = _itemsService.Delete(itemId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}

