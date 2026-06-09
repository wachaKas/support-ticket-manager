using SupportTicket.Api.DTOs;
using SupportTicket.Api.Enums;

namespace SupportTicket.Api.Services;

public interface ITicketService
{
    Task<PagedResultDto<TicketResponseDto>> GetTicketsAsync(
        TicketStatus? status,
        TicketPriority? priority,
        int page,
        int pageSize);

    Task<TicketResponseDto?> GetTicketByIdAsync(int id);

    Task<TicketResponseDto> CreateTicketAsync(CreateTicketDto dto);

    Task<bool> UpdateTicketAsync(int id, UpdateTicketDto dto);

    Task<bool> UpdateTicketStatusAsync(int id, UpdateTicketStatusDto dto);

    Task<bool> DeleteTicketAsync(int id);
}