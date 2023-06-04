using MediatR;

namespace HotelManagerSystem.API.Request;

public class DeleteOwnerCommand : IRequest<bool>
{
    public string OwnerId { get; }

    public DeleteOwnerCommand(string ownerId)
    {
        OwnerId = ownerId;
    }
}