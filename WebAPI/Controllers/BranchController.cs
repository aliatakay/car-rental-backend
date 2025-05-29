using CarRental.Business.Abstract;
using CarRental.Data.Contracts.Entities;
using CarRental.Data.Contracts.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _branchService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _branchService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost("add")]
        public IActionResult Add(Branch branch)
        {
            var result = _branchService.Add(branch);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("delete")]
        public IActionResult Delete(Branch branch)
        {
            var result = _branchService.Delete(branch);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("update")]
        public IActionResult Update(Branch branch)
        {
            var result = _branchService.Update(branch);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}