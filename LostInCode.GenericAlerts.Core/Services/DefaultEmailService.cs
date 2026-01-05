using LostInCode.GenericAlerts.Core.Interfaces;
using System.Threading.Tasks;

namespace LostInCode.GenericAlerts.Core.Services;

public class DefaultEmailService : IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body)
    {
        // TODO: Implement email sending logic (SMTP, SendGrid, etc.)
        // For now, just log or no-op
        return Task.CompletedTask;
    }
}
