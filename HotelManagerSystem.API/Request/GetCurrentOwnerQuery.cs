using System.Security.Claims;
using HotelManagerSystem.Models.Entities.ModelOwner;
using MediatR;

namespace HotelManagerSystem.API.Request;

public class GetCurrentOwnerQuery : IRequest<OwnerViewModel>
{
    public ClaimsPrincipal UserClaims { get; }

    public GetCurrentOwnerQuery(ClaimsPrincipal userClaims)
    {
        UserClaims = userClaims;
    }
}