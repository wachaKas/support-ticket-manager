using System.ComponentModel.DataAnnotations;
using SupportTicket.Api.Enums;

namespace SupportTicket.Api.DTOs;

public class CreateTicketDto
{
    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; } = string.Empty;

    [Required]
    [MaxLength(200)]
    public string Subject { get; set; } = string.Empty;

    [Required]
    [MaxLength(2000)]
    public string Message { get; set; } = string.Empty;

    [Required]
    public TicketPriority Priority { get; set; }
}