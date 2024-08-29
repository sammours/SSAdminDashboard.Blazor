namespace SSAdminDashboard.Domain.Mails;

using System.ComponentModel.DataAnnotations;
public class Mail : IEntity
{
    public long Id { get; set; }
    [Required]
    public string Sender { get; set; } = string.Empty;
    [Required]
    public string Subject { get; set; } = string.Empty;
    [Required]
    public string Body { get; set; } = string.Empty;
    [Required]
    public MailFolder Folder { get; set; } = MailFolder.Inbox;
    [Required]
    public DateTime Date { get; set; }
    public string Avatar { get; set; } = string.Empty;
    public bool IsRead { get; set; } = false;
    [Required]
    [EmailAddress]
    public string From { get; set; } = string.Empty;
}
