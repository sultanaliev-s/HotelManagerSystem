using HotelManagerSystem.API.Request;
using MediatR;

namespace HotelManagerSystem.API.Handlers;

public class SendEmailCommand : IRequest
{
    public EmailRequest EmailRequest { get; }

    public SendEmailCommand(EmailRequest emailRequest)
    {
        EmailRequest = emailRequest;
    }
}
