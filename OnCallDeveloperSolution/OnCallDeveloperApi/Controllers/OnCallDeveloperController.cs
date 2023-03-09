
namespace OnCallDeveloperApi.Controllers;

public class OnCallDeveloperController : ControllerBase
{
    //GET /oncalldeveloper -> 200 Ok
    [HttpGet("/oncalldeveloper")]
    public ActionResult GetOnCallDeveloper()
    {
        return Ok(); // 200 status code
    }
}
