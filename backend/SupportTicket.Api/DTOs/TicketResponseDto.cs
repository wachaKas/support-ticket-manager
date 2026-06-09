namespace SupportTicket.Api.DTOs;

public class TicketResponseDto
{
    public int Id { get; set; }

    public string CustomerEmail { get; set; } = string.Empty;

    public string Subject { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public string Priority { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}