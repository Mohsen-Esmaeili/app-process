using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hahn.ApplicationProcess.July2021.Domain.Models;
using Hahn.ApplicationProcess.July2021.Domain.Services;

namespace Hahn.ApplicationProcess.July2021.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private readonly IAssetService _service;

        public AssetController(ILogger<AssetController> logger, IAssetService service)
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
        public IActionResult Post([FromBody] PostAssetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _service.Post(request);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PutAssetRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _service.Put(request);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete([FromQuery] DeleteAssetRequest request)
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
