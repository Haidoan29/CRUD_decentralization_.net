namespace _200124.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string fromEmail, string toEmail, string subject, string body);
    }
}
