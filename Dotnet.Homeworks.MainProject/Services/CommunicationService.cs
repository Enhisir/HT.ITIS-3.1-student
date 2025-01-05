using Dotnet.Homeworks.Shared.MessagingContracts.Email;
using MassTransit;

namespace Dotnet.Homeworks.MainProject.Services;

public class CommunicationService(
    IPublishEndpoint publisher,
    ILogger<CommunicationService> logger) : ICommunicationService
{
    public async Task SendEmailAsync(SendEmail sendEmailDto)
    {
        await publisher.Publish(sendEmailDto);
        logger.LogInformation($"Sent email {sendEmailDto.ReceiverEmail}: {sendEmailDto.ReceiverName}");
    }
}