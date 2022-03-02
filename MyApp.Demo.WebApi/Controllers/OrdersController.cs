using Microsoft.AspNetCore.Mvc;
using MyApp.Demo.Business.Abstract;
using MyApp.Demo.DataAccess.Abstract;
using MyApp.Demo.Entities.Concrete;

namespace MyApp.Demo.WebApi.Controllers
{

    [Route("Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IConfiguration _config { get; }
        private const string queueName = "add-orders";
        private string connectionString;
        private IOrdersService _ordersService;
        private IAzureDal _azureDal;
        private IOrdersDal _ordersDal;
        public OrdersController(IConfiguration config, IAzureDal azureDal, IOrdersService ordersService,IOrdersDal orderDal)
        {
            _ordersService = ordersService;
            _azureDal = azureDal;
            _config = config;
            _ordersDal=orderDal;
            connectionString = _config.GetSection("AzureQueueString").Value;
        }

        [HttpGet("getlistbyordersdate")]
        public IActionResult GetListByOrdersDate(Order order)
        {
            var result = _ordersService.GetByOrderDate(order);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getlistbyclientid")]
        public IActionResult GetListByClientsId(int clientId)
        {
            var result = _ordersDal.GetOrderDetails(clientId);
            if (result!=null)
            {
                return Ok(result);
            }
            return BadRequest("Error Request!");
        }
        [HttpGet("getlistbyclient")]
        public IActionResult GetListByClients(int clientId)
        {
            var result = _ordersService.GetListByClient(clientId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("add")]
        public IActionResult Add(Order order)
        {
            var result = _ordersService.Add(order);
            if (result.Success)
            {
                _azureDal.AddAzureMessage(order, connectionString, queueName);
                return Ok(result.Message);
            };
            return BadRequest(result.Message);
        }
        [HttpPut("update")]
        public IActionResult Update(Order order)
        {
            var result = _ordersService.Update(order);
            if (result.Success)
            {
                _azureDal.AddAzureMessage(order, connectionString, queueName);
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int orderId)
        {
            var result = _ordersService.Delete(orderId);
            if (result.Success)
            {
                _azureDal.AddAzureMessage((Order)result, connectionString, queueName);
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
