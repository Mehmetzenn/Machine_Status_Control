using Business.Abstract;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public MachinesController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _machineService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _machineService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Machine machine)
        {
            var result = _machineService.Add(machine);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Machine machine)
        {
            var result = _machineService.Update(machine);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Machine machine)
        {
            var result = _machineService.Delete(machine);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

    }
}
