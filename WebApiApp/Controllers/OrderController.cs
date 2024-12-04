using Application;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace WebApiApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IServer _server;

        public OrderController(IServer server)
        {
            _server = server;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TakeOrder([FromBody] OrderRequest request)
        {
            var output = _server.TakeOrder(request.Period.Replace(" ", ""), request.Dishes.Replace(" ", ""));
            return Ok(output);
        }

        [HttpGet]
        public string  Get()
        {
            return "Api is Running...";
        }

    }
}
