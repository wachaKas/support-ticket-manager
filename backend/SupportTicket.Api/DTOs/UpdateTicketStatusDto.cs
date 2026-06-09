using System.ComponentModel.DataAnnotations;
using SupportTicket.Api.Enums;

namespace SupportTicket.Api.DTOs;

public class UpdateTicketStatusDto
{
    [Required]
    public TicketStatus Status { get; set; }
}