namespace SupportTicket.Api.Models;
using SupportTicket.Api.Enums;

public class Ticket
{
    public int Id { get; set; }

    public string CustomerEmail { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public TicketStatus Status { get; set; }

    public TicketPriority Priority { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}