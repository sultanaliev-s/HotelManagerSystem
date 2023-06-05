using HotelManagerSystem.Models.Entities.ModelOwner;
using MediatR;

namespace HotelManagerSystem.API.Request;

public class GetOwnerByIdQuery : IRequest<OwnerViewModel>
{
    public string OwnerId { get; }

    public GetOwnerByIdQuery(string ownerId)
    {
        OwnerId = ownerId;
    }
}