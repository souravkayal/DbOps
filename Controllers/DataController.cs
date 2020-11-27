using Kargil.DB;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kargil.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        public readonly MessageContext _context;

        public MessageController(MessageContext context)
        {
            this._context = context;
        }


        [HttpPost]
        [Route("create")]
        public void Create(Message item)
        {
            _context.UserMessage.Add(item);
            _context.SaveChanges();
        }

        [HttpGet]
        [Route("get-all")]
        public IActionResult GetAll()
        {
            var result = _context.UserMessage.ToList();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            var message = _context.UserMessage.Where(f => f.id == id).FirstOrDefault();
            return message == null ? NotFound() : Ok(message);
        }

    }
}
