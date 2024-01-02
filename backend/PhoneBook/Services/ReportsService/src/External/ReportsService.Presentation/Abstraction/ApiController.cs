using Microsoft.AspNetCore.Mvc;

namespace ReportsService.Presentation.Abstraction;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiController : ControllerBase
{

}