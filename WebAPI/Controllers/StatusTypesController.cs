using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusTypesController : ControllerBase
    {
        private readonly IStatusTypeService _statusTypeService;

        public StatusTypesController(IStatusTypeService statusTypeService)
        {
            _statusTypeService = statusTypeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _statusTypeService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _statusTypeService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] StatusType statusType)
        {
            var result = _statusTypeService.Add(statusType);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] StatusType statusType)
        {
            var result = _statusTypeService.Update(statusType);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] StatusType statusType)
        {
            var result = _statusTypeService.Delete(statusType);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
