using System.Security.Claims;
using HotelManagerSystem.API.AuthBL.CurrentModels;
using HotelManagerSystem.API.AuthBL.Managers;
using HotelManagerSystem.API.Handlers;
using HotelManagerSystem.API.Request;
using HotelManagerSystem.API.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagerSystem.API.AuthBL.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmailController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly EmailManager _emailManager;
    public EmailController(IMediator mediator, EmailManager emailManager)
    {
        _mediator = mediator;
        _emailManager = emailManager;
    }

    [HttpPost("send")]
    public async Task SendEmailAsync([FromBody] EmailRequest emailRequest, [FromServices] IMediator mediator)
    {
        await _mediator.Send(new SendEmailCommand(emailRequest));
    }

    [HttpPost("CheckCode")]
    public async Task<Response> CheckCodeAsync(CheckCodeRequest checkCodeRequest)
    {
        return await _mediator.Send(checkCodeRequest);
    }

    [HttpGet("getCurrentUserEmail")]
    public async Task<CurrentUserEmailResponse> GetCurrentUserEmailAsync()
    {
        ClaimsPrincipal currentUserClaims = User;
        return await _emailManager.GetCurrentUserEmailAsync(currentUserClaims);
    }

    [HttpPost("verifyEmail")]
    public async Task<Response> VerifyEmailAsync(VerifyEmailRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpPost("changeEmail")]
    public async Task<Response> ChangeEmailAsync(string email)
    {
        return await _emailManager.ChangeEmail(email);
    }

    [HttpPost("confirmChangeEmail")]
    public async Task<Response> ConfirmChangeEmailAsync(ChangeEmailRequest request)
    {
        return await _mediator.Send(request);
    }
}