using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "GetOk")]
    [HttpHead(Name = "HeadOk")]
    [HttpDelete(Name = "DeleteOk")]
    [HttpOptions(Name = "OptionsOk")]
    [HttpPatch(Name = "PatchOk")]
    [HttpPost(Name = "PostOk")]
    [HttpPut(Name = "PutOk")]
    public IActionResult Respond()
    {
        return Ok();
    }
}