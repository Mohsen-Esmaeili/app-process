using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hahn.ApplicationProcess.July2021.Domain.Models;
using Hahn.ApplicationProcess.July2021.Domain.Services;

namespace Hahn.ApplicationProcess.July2021.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAssetController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserAssetService _service;

        public UserAssetController(ILogger<UserController> logger, IUserAssetService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IActionResult GetByUserId([FromQuery] GetUserAssetByUserIdRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _service.GetByUserId(request);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostUserAssetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _service.Post(request);
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteUserAssetRequest request)
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
