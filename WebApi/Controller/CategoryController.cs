using Microsoft.AspNetCore.Mvc;
using RabbitMQApi.Models;
using RabbitMQApi.RabbitMQ;
using RabbitMQApi.Services;

namespace RabbitMQApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly IRabitMQProducer _rabitMQProducer;
        public CategoryController(IRabitMQProducer rabitMQProducer)
        {
            _rabitMQProducer = rabitMQProducer;
        }
        [HttpGet("list")]
        public object List()
        {
            var rs = new object();
            _rabitMQProducer.SendProductMessage(rs);
            return rs;
        }
    }
}
