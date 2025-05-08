using Business.Abstract;
using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineStatusesController : ControllerBase
    {
        private readonly IMachineStatusService _machineStatusService;

        public MachineStatusesController(IMachineStatusService machineStatusService)
        {
            _machineStatusService = machineStatusService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _machineStatusService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _machineStatusService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] MachineStatus machineStatus)
        {
            var result = _machineStatusService.Add(machineStatus);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] MachineStatus machineStatus)
        {
            var result = _machineStatusService.Update(machineStatus);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] MachineStatus machineStatus)
        {
            var result = _machineStatusService.Delete(machineStatus);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("detail")]
        public IActionResult GetByMachineIdAndDate(int machineId, DateTime date)
        {
            var result = _machineStatusService.GetByMachineIdAndDate(machineId, date);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("currentshift")]
        public IActionResult GetByCurrentShift()
        {
           var result = _machineStatusService.GetByCurrentShift();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("statusdetail")]
        public IActionResult GetStatusDetail()
        {
            var result = _machineStatusService.GetStatusDetail();
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
