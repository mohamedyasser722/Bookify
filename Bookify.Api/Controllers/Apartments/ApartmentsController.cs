using Bookify.Application.Apartments.SearchApartments;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Apartments;
[ApiController]
[Route("api/apartments")]
public class ApartmentsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;
    [HttpGet]
    public async Task<IActionResult> SearchApartments(DateOnly StartDate, DateOnly EndDate, CancellationToken cancellationToken)
    {
        var query = new SearchApartmentsQuery(StartDate, EndDate);

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result.Value);
    }
}
