using Business.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShiftsController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftsController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _shiftService.GetAll();
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _shiftService.GetById(id);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("get-last-status-by-machineid")]
        public IActionResult GetLastStatusByMachineId(int shiftId)
        {
            var result = _shiftService.GetLastStatusByMachineId(shiftId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Shift shift)
        {
            var result = _shiftService.Add(shift);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] Shift shift)
        {
            var result = _shiftService.Update(shift);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Shift shift)
        {
            var result = _shiftService.Delete(shift);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}
