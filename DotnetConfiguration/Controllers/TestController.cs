using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DotnetConfiguration.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TestController : ControllerBase
{
    private readonly SmtpOptions _options;

    public TestController(IOptionsSnapshot<SmtpOptions> options)
    {
        _options = options.Value;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(_options);
    }
}