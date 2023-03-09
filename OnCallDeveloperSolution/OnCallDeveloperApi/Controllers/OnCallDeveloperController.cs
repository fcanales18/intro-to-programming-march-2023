﻿
namespace OnCallDeveloperApi.Controllers;

public class OnCallDeveloperController : ControllerBase
{
    //GET /oncalldeveloper -> 200 Ok
    [HttpGet("/oncalldeveloper")]
    public ActionResult GetOnCallDeveloper()
    {
        var response = new GetOnCallDeveloperResponse("Mike N.", "555-1212", "mike@aol.com");
        return Ok(response); // 200 status code
    }
}
