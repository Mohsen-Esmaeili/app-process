using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Delete;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Post;
using Hahn.ApplicationProcess.July2021.Domain.Models.User.Put;
using Hahn.ApplicationProcess.July2021.Domain.Services.Interfaces;

namespace Hahn.ApplicationProcess.July2021.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IUserService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _service.Get();
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _service.Post(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PutUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _service.Put(request);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _service.Delete(request);
            return Ok();
        }
    }
}
