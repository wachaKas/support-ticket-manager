using Microsoft.EntityFrameworkCore;
using SupportTicket.Api.Data;
using SupportTicket.Api.DTOs;
using SupportTicket.Api.Models;
using AutoMapper;
using SupportTicket.Api.Enums;


namespace SupportTicket.Api.Services;

public class TicketService : ITicketService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public TicketService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResultDto<TicketResponseDto>> GetTicketsAsync(
        TicketStatus? status,
        TicketPriority? priority,
        int page,
        int pageSize)
    {
        if (page < 1)
        {
            page = 1;
        }

        if (pageSize < 1)
        {
            pageSize = 10;
        }

        if (pageSize > 100)
        {
            pageSize = 100;
        }

        var query = _context.Tickets.AsQueryable();

        if (status.HasValue)
        {
            query = query.Where(ticket => ticket.Status == status.Value);
        }

        if (priority.HasValue)
        {
            query = query.Where(ticket => ticket.Priority == priority.Value);
        }

        var totalCount = await query.CountAsync();

        var tickets = await query
            .OrderByDescending(ticket => ticket.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(ticket => _mapper.Map<TicketResponseDto>(ticket))
            .ToListAsync();

        return new PagedResultDto<TicketResponseDto>
        {
            Items = tickets,
            TotalCount = totalCount,
            Page = page,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize)
        };
    }

    public async Task<TicketResponseDto?> GetTicketByIdAsync(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket == null)
        {
            return null;
        }

        return _mapper.Map<TicketResponseDto>(ticket);
    }

    public async Task<TicketResponseDto> CreateTicketAsync(CreateTicketDto dto)
    {
        var ticket = _mapper.Map<Ticket>(dto);

        _context.Tickets.Add(ticket);
        await _context.SaveChangesAsync();

        return _mapper.Map<TicketResponseDto>(ticket);
    }

    public async Task<bool> UpdateTicketAsync(int id, UpdateTicketDto dto)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket == null)
        {
            return false;
        }

        _mapper.Map(dto, ticket);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateTicketStatusAsync(int id, UpdateTicketStatusDto dto)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket == null)
        {
            return false;
        }

        ticket.Status = dto.Status;

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteTicketAsync(int id)
    {
        var ticket = await _context.Tickets.FindAsync(id);

        if (ticket == null)
        {
            return false;
        }

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();

        return true;
    }

}