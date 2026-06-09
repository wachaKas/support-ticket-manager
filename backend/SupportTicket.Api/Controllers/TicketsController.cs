using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportTicket.Api.Data;
using SupportTicket.Api.Models;
using SupportTicket.Api.DTOs;
using SupportTicket.Api.Services;
using SupportTicket.Api.Enums;

namespace SupportTicket.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{

    private readonly ITicketService _ticketService;

    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;

    }

    [HttpGet]
    public async Task<ActionResult<PagedResultDto<TicketResponseDto>>> GetTickets(
        [FromQuery] TicketStatus? status,
        [FromQuery] TicketPriority? priority,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await _ticketService.GetTicketsAsync(
            status,
            priority,
            page,
            pageSize);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TicketResponseDto>> GetTicket(int id)
    {
        var ticket = await _ticketService.GetTicketByIdAsync(id);

        if (ticket == null)
        {
            return NotFound();
        }

        return Ok(ticket);
    }

    [HttpPost]
    public async Task<ActionResult<TicketResponseDto>> CreateTicket(CreateTicketDto dto)
    {
        var ticket = await _ticketService.CreateTicketAsync(dto);

        return CreatedAtAction(nameof(GetTicket), new { id = ticket.Id }, ticket);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTicket(int id, UpdateTicketDto dto)
    {
        var updated = await _ticketService.UpdateTicketAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateTicketStatus(int id, UpdateTicketStatusDto dto)
    {
        var updated = await _ticketService.UpdateTicketStatusAsync(id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTicket(int id)
    {
        var deleted = await _ticketService.DeleteTicketAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}