using HotelManagerSystem.API.AuthBL.Managers;
using MediatR;

namespace HotelManagerSystem.API.Handlers;

public class EmailHandler : IRequestHandler<SendEmailCommand, Unit>
{
    private readonly EmailManager _emailManager;

    public EmailHandler(EmailManager emailManager)
    {
        _emailManager = emailManager;
    }

    public async Task<Unit> Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        var response = await _emailManager.SendToEmailAsync(request, cancellationToken);
        return response;
    }
}