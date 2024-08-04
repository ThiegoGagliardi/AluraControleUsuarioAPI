using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AluraControleUsuarioAPI.Controller;

[ApiController]
[Route("[controller]")]
public class AcessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinimumAge")]
    public ActionResult Get()
    {
        return Ok("Acesso Permitido.");
    }
}