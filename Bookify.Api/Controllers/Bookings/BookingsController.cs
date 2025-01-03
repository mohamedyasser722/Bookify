﻿using Bookify.Application.Bookings.GetBooking;
using Bookify.Application.Bookings.ReserveBooking;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers.Bookings;
[ApiController]
[Route("api/bookings")]
public class BookingsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;
    [HttpGet("{Id:guid}")]
    public async Task<IActionResult> GetBookings(Guid Id, CancellationToken cancellationToken)
    {
        var query = new GetBookingQuery(Id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> ReserveBooking(ReserveBookingRequest request, CancellationToken cancellationToken)
    {
        var command = new ReserveBookingCommand(request.ApartmentId, request.UserId, request.StartDate, request.EndDate);

        var result = await _sender.Send(command, cancellationToken);

        if(result.IsFailure)
            return BadRequest(result.Error);

        return CreatedAtAction(nameof(GetBookings), new { Id = result.Value }, result.Value);
    }

}
