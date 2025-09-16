using Dotnet.Homeworks.Mailing.API.Dto;
using Dotnet.Homeworks.Mailing.API.Services;
using Dotnet.Homeworks.Shared.MessagingContracts.Email;
using MassTransit;

namespace Dotnet.Homeworks.Mailing.API.Consumers;

public class EmailConsumer(
    IMailingService mailingService,
    ILogger<EmailConsumer> logger) : IEmailConsumer
{
    public async Task Consume(ConsumeContext<SendEmail> context)
    {
        var msg = context.Message;
        logger.LogInformation($"Received message from email service: {msg.ReceiverEmail} - {msg.Subject}");
        await mailingService.SendEmailAsync(new EmailMessage(msg.ReceiverEmail, msg.Subject, msg.Content));
    }
}