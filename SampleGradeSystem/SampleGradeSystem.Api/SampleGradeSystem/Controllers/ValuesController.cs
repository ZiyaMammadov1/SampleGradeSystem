using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleGradeSystem.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public ActionResult<Result> get()
    {
        var result =  Result.Failure("asd");
        return BadRequest(result.Error);
        //return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
