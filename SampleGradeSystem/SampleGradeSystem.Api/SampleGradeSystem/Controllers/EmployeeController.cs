using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleGradeSystem.Data.UnitOfWork.Interfaces;
using SampleGradeSystem.Models.Special;
using SampleGradeSystem.Services;

namespace SampleGradeSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SalaryService _salaryService;

        public EmployeeController(SalaryService salaryService)
        {
            _salaryService = salaryService;
        }


        [HttpPost("{id}/salary/calculate")]
        public async Task<ActionResult<Result>> CalculateSalary(int id, decimal storeAmount = 0, decimal positionAmount = 0)
        {
            Result<decimal> result = await _salaryService.CalculateSalaryByEmployeeIdAsync(id, storeAmount, positionAmount);
            if (result.IsSuccess) return Ok(result.Value);
            return BadRequest(result.Error);

        }
    }
}
