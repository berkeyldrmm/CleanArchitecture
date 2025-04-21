using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Options;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace CleanArchitecture.Infrastructure.Services;

public class MailService : IMailService
{
    private readonly SmtpOptions _smtpOptions;
    private readonly RegisterEmailOptions _registerEmailOptions;
    private readonly ConfirmationEmailOptions _confirmationEmailOptions;

    public MailService(IOptions<SmtpOptions> smtpOptions, IOptions<RegisterEmailOptions> registerEmailOptions, IOptions<ConfirmationEmailOptions> confirmationEmailOptions)
    {
        _smtpOptions = smtpOptions.Value;
        _registerEmailOptions = registerEmailOptions.Value;
        _confirmationEmailOptions = confirmationEmailOptions.Value;
    }

    public async Task SendEmailAsync(string recieverEmail, string receiverNameSurname, string subject, string title, string body)
    {
        using MimeMessage mimeMessage = new MimeMessage();
        MailboxAddress mailboxAddressFrom = new MailboxAddress(title, _smtpOptions.SenderEmail);
        MailboxAddress mailboxAddressTo = new MailboxAddress(receiverNameSurname, recieverEmail);
        mimeMessage.From.Add(mailboxAddressFrom);
        mimeMessage.To.Add(mailboxAddressTo);

        BodyBuilder bodyBuilder = new BodyBuilder();
        bodyBuilder.TextBody = body;
        mimeMessage.Body = bodyBuilder.ToMessageBody();
        mimeMessage.Subject = subject;

        using SmtpClient client = new SmtpClient();
        await client.ConnectAsync(_smtpOptions.Host, _smtpOptions.Port, _smtpOptions.Ssl);
        await client.AuthenticateAsync(_smtpOptions.SenderEmail, _smtpOptions.ApplicationCode);
        await client.SendAsync(mimeMessage);
        await client.DisconnectAsync(true);
    }

    public async Task SendConfirmationEmail(string recieverEmail, string receiverNameSurname, string userId, string token)
    {
        string confirmation_url = $"{_confirmationEmailOptions.ConfirmEmailBaseLink}?userId={userId}&confirmationtoken={token}";
        string body = $"{_confirmationEmailOptions.Body} \n {confirmation_url}";
        await SendEmailAsync(recieverEmail, receiverNameSurname, _confirmationEmailOptions.Subject, _confirmationEmailOptions.Title, body);
    }

    public async Task SendRegistrationEmail(string recieverEmail, string receiverNameSurname)
    {
        await SendEmailAsync(recieverEmail, receiverNameSurname, _registerEmailOptions.Subject, _registerEmailOptions.Title, _registerEmailOptions.Body);
    }
}
