

using LearningResourcesApi.Domain;

namespace LearningResourcesApi.Controllers;

public class LearningResourcesController : ControllerBase
{
    private readonly LearningResourcesDataContext _context;

    public LearningResourcesController(LearningResourcesDataContext context)
    {
        _context = context;
    }

    [HttpPost("/learning-resources")]
    public async Task<ActionResult<LearningResourceSummaryItem>> AddResources(
        [FromBody] LearningResourcesCreateRequest request)
    {
        // Validate it.. If it doesn't meet the invariants, return a 400.
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        // Add it to the database.
        //   - turn the request -> Domain.LearningResourcesEntity
        var entity = new LearningResourcesEntity
        {
            // "Mapping" - AutoMapper
            Name = request.Name,
            Description = request.Description,
            Link = request.Link,
            WhenCreated = DateTime.Now
        };
        //   - tell our DataContext about it.
        _context.LearningResources.Add(entity);
        //   - tell the DataContext to save the data.
        await _context.SaveChangesAsync(); // Releases the thread. Don't hang out here, take someone else's order, we'll let you know when its done. Then if data is ready, then Order Up!
        // Return a Success Status Code*
        //   - With a copy of the brand new entity
        var response = new LearningResourceSummaryItem(entity.Id.ToString(), entity.Name, entity.Description, entity.Link);
        return Ok(response);

    }


    [HttpGet("/learning-resources")]
    public async Task<ActionResult<LearningResourcesResponse>> GetLearningResources(CancellationToken token)
    {
        var data = await _context.LearningResources
            .Where(item => item.WhenRemoved == null)
            .Select(item => new LearningResourceSummaryItem(
                item.Id.ToString(), item.Name, item.Description, item.Link))
            .ToListAsync(token);

        var response = new LearningResourcesResponse(data);
        return Ok(response);
    }
}