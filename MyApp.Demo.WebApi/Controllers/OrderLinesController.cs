using Microsoft.AspNetCore.Mvc;
using MyApp.Demo.Business.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        IOrderLinesService _orderLinesService;
        public OrderLinesController(IOrderLinesService orderLinesService)
        {
            _orderLinesService=orderLinesService;
        }
        [HttpPost("add")]
        public IActionResult Add(OrderLine orderLine)
        {
            var result = _orderLinesService.Add(orderLine);
            if (result.Success)
            { 
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(OrderLine orderLine)
        {
            var result = _orderLinesService.Update(orderLine);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int orderLineId)
        {
            var result = _orderLinesService.Delete(orderLineId);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
